﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using log4net;
using MacAddressVendorLookup;
using Microsoft.VisualBasic;
using WifiFinderAlgorithm;
using static FormsMapController.FormsMap;

namespace LPSView
{
    public partial class FormLPSView : Form
    {
        TreeNode stationRootNode;
        TreeNode deviceRootNode;
        bool deviceAdded = false;
        ILog log;
        AddressMatcher addressMatcher;

        public FormLPSView()
        {
            InitializeComponent();
            log = LogManager.GetLogger(GetType());

            formsMap1.MarkerAdded += FormsMap1_MarkerAdded;

            var vendorInfoProvider = new MacVendorBinaryReader();
            using (var resourceStream = ManufBinResource.GetStream().Result)
            {
                vendorInfoProvider.Init(resourceStream).Wait();
            }

            addressMatcher = new AddressMatcher(vendorInfoProvider);
        }

        private void FormsMap1_MarkerAdded(object sender, EventArgs e)
        {
            MarkerAddedEventArgs eArg = (MarkerAddedEventArgs) e;

            if (deviceAdded)
            {
                return;
            }

            if (radioButtonPointerCreateStation.Checked)
            {
                // New marker is a station.
                Station nodeTag = new Station(eArg.NewMarker);

                string nodeText = $"Station {stationRootNode.Nodes.Count + 1}";

                TreeNode newNode = stationRootNode.Nodes.Add(nodeText);
                newNode.Tag = nodeTag;

                log.Debug($"Added station, ID: {nodeTag.ID}, Location: {nodeTag.MapMarker.Location.AbsoluteMap}, Nodetext: {nodeText}");
            }
            else
            {
                formsMap1.RemoveMarker(eArg.NewMarker);
            }
        }

        private void FormLPSView_Load(object sender, EventArgs e)
        {
            deviceRootNode = treeView1.Nodes[0];
            stationRootNode = treeView1.Nodes[1];

            treeView1.ExpandAll();

            deviceRootNode.Nodes.Clear();
            stationRootNode.Nodes.Clear();
        }

        private void buttonConfigure_Click(object sender, EventArgs e)
        {
            ConfigForm configForm = new ConfigForm();
            configForm.Show();
        }

        private void buttonStopDataPull_Click(object sender, EventArgs e)
        {
            timerPullData.Stop();
            toolStripStatusLabel.Text = "Stoppede dataindsamling";
        }

        private IEnumerable<Station> GetStations()
        {
            foreach (var item in stationRootNode.Nodes)
            {
                TreeNode node = (TreeNode)item;

                yield return (Station)node.Tag;
            }
        }

        private void buttonStartDataPull_Click(object sender, EventArgs e)
        {
            if (GetStations().Count() < 3)
            {
                toolStripStatusLabel.Text = "Ikke nok stationer";
                return;
            }

            timerPullData.Start();
            toolStripStatusLabel.Text = "Startede opsamling";
        }

        private void timerPullData_Tick(object sender, EventArgs e)
        {
            string result = QueryDatabase.GetRecentData();

            if (result is null)
            {
                return;
            }

            // Create dictionary of station coordinate by ID.
            Dictionary<byte, Coordinate> stationLookup = GetStations().ToDictionary(
                key => key.ID,
                element =>
                    new Coordinate(element.MapMarker.Location.AbsoluteMap.X, element.MapMarker.Location.AbsoluteMap.Y));

            // Get latest device information
            Dictionary<long, Dictionary<byte, byte>> deviceData = QueryDatabase.ParseDataString(result);

            // Translate device information into required target
            Dictionary<long, Receiver[]> deviceInformation;
            try
            {
                deviceInformation = deviceData.ToDictionary(
                    key => key.Key,
                    element =>
                        element.Value.Select(station => new Receiver(stationLookup[station.Key], station.Value)).Take(3).ToArray());
            }
            catch (KeyNotFoundException ex)
            {
                string errorMessage = $"Missing station by ID: {ex}";
                log.Error(errorMessage);
                MessageBox.Show(errorMessage);
                return;
            }

            var calculatedData = WifiDataThingy.GetDevicePositions(deviceInformation);

            deviceAdded = true;
            foreach ((string, WifiFinderAlgorithm.WifiFinderAlgorithm.Point) item in calculatedData)
            {
                string nodeKey = item.Item1;
                var position = new GraphicsPoint(new Point((int)item.Item2.X, (int)item.Item2.Y), GraphicsPoint.PointRelation.AbsoluteMap, formsMap1);

                int deviceNodeIndex = deviceRootNode.Nodes.IndexOfKey(nodeKey);
                if (deviceNodeIndex == -1)
                {
                    MapMarker newMarker = new MapMarker(position, MapIcons.PinpointDevice, false);
                    formsMap1.AddMarker(newMarker);

                    // New marker is a device.
                    Device nodeTag = new Device(newMarker, item.Item1);

                    PhysicalAddress macAddress = PhysicalAddress.Parse(item.Item1);
                    MacVendorInfo macInfo = addressMatcher.FindInfo(macAddress);
                    
                    string nodeText = $"({macInfo.Organization}) {item.Item1}";

                    TreeNode newNode = deviceRootNode.Nodes.Add(nodeKey, nodeText);
                    newNode.Tag = nodeTag;

                    log.Debug($"Added device, MAC: {nodeTag.MacAddress}, Location: {nodeTag.MapMarker.Location.AbsoluteMap}, Nodetext: {nodeText}");
                }
                else
                {
                    Device device = (Device)deviceRootNode.Nodes[deviceNodeIndex].Tag;

                    device.MapMarker.Location = position;
                }
            }

            deviceAdded = false;

            formsMap1.Refresh();
        }

        private void buttonSaveStations_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in GetStations())
            {
                sb.Append(item.MapMarker.Location.AbsoluteMap.X);
                sb.Append('.');
                sb.Append(item.MapMarker.Location.AbsoluteMap.Y);
                sb.Append(',');
            }

            string loadstring = Interaction.InputBox("Tekst streng?", "Stationer", sb.ToString());

            if (loadstring == sb.ToString())
            {
                return;
            }

            try
            {
                string[] points = loadstring.Split(',');

                List<Point> markerPoints = new List<Point>();
                foreach (var point in points)
                {
                    string[] xAndY = point.Split('.');
                    int x = int.Parse(xAndY[0]);
                    int y = int.Parse(xAndY[1]);

                    markerPoints.Add(new Point(x, y));
                }

                foreach (var item in stationRootNode.Nodes)
                {
                    TreeNode node = (TreeNode)item;
                    Station station = (Station)node.Tag;

                    formsMap1.RemoveMarker(station.MapMarker);
                }

                stationRootNode.Nodes.Clear();

                foreach (var point in markerPoints)
                {
                    formsMap1.AddDefaultMarker(
                        new GraphicsPoint(point, GraphicsPoint.PointRelation.AbsoluteMap, formsMap1),
                        true);
                }

                formsMap1.Refresh();
            }
            catch (FormatException)
            {
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is MapEntity mapEntity)
            {
                formsMap1.CenterMarker(mapEntity.MapMarker);
            }
        }

        private void treeView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
            {
                return;
            }

            TreeNode currentNode = treeView1.SelectedNode;
            if (currentNode.Tag is Station station)
            {
                formsMap1.RemoveMarker(station.MapMarker);
                stationRootNode.Nodes.Remove(currentNode);
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            if (e.Node.Tag is Station station)
            {
                StationConfigPrompt stationConfigPrompt = new StationConfigPrompt(
                    e.Node.Text,
                    station.ID,
                    station.MapMarker.Location.AbsoluteMap);

                if (stationConfigPrompt.ShowDialog() != DialogResult.Cancel)
                {
                    station.ID = (byte)stationConfigPrompt.StationID;
                    station.MapMarker.Location = new GraphicsPoint(
                        new Point(stationConfigPrompt.LocationX, stationConfigPrompt.LocationY),
                        GraphicsPoint.PointRelation.AbsoluteMap,
                        formsMap1);

                    formsMap1.CenterMarker(station.MapMarker);
                }
            }
        }

        private class Station : MapEntity
        {
            public Station(MapMarker mapMarker) : base(mapMarker)
            {
            }

            public byte ID { get; set; }
        }

        private class Device : MapEntity
        {
            public Device(MapMarker mapMarker, string macAddress) : base(mapMarker)
            {
                MacAddress = macAddress;
            }

            public string MacAddress { get; }
        }

        private class MapEntity
        {
            public MapMarker MapMarker { get; }

            public MapEntity(MapMarker mapMarker)
            {
                MapMarker = mapMarker;
            }
        }

        private void buttonRemoveDevices_Click(object sender, EventArgs e)
        {
            foreach (var item in deviceRootNode.Nodes)
            {
                TreeNode treeNode = (TreeNode)item;
                formsMap1.RemoveMarker(((Device)treeNode.Tag).MapMarker);
            }

            deviceRootNode.Nodes.Clear();
        }
    }
}
