using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormsMapController;
using Microsoft.VisualBasic;
using WifiFinderAlgorithm;

namespace LPSView
{
    public partial class FormLPSView : Form
    {
        TreeNode stationRootNode;
        TreeNode deviceRootNode;
        Dictionary<long, FormsMap.MapMarker> deviceMarkers = new Dictionary<long, FormsMap.MapMarker>();
        List<FormsMap.MapMarker> stationMarkers = new List<FormsMap.MapMarker>();
        Dictionary<TreeNode, FormsMap.MapMarker> markerByNode = new Dictionary<TreeNode, FormsMap.MapMarker>();
        bool addingDevice = false;

        public FormLPSView()
        {
            InitializeComponent();

            formsMap1.MarkerAdded += FormsMap1_MarkerAdded;
        }

        private void FormsMap1_MarkerAdded(object sender, EventArgs e)
        {
            FormsMap.MarkerAddedEventArgs eArg = (FormsMap.MarkerAddedEventArgs) e;
            
            if (radioButtonPointerCreateStation.Checked && !addingDevice)
            {
                stationMarkers.Add(eArg.NewMarker);

                markerByNode[stationRootNode.Nodes.Add($"Station {stationMarkers.Count}")] = eArg.NewMarker;
            }
            else
            {
                markerByNode[deviceRootNode.Nodes.Add($"Ny enhed: {deviceMarkers.Count}")] = eArg.NewMarker;
            }
        }

        private void FormLPSView_Load(object sender, EventArgs e)
        {
            deviceRootNode = treeView1.Nodes[0];
            stationRootNode = treeView1.Nodes[1];

            deviceRootNode.Nodes.Clear();
            stationRootNode.Nodes.Clear();
        }

        private void buttonConfigure_Click(object sender, EventArgs e)
        {
            ConfigForm configForm = new ConfigForm();
            configForm.Show();
        }

        private void buttonRemoveMarkers_Click(object sender, EventArgs e)
        {
            formsMap1.RemoveMarkers();
            stationRootNode.Nodes.Clear();
        }

        private void buttonRefreshData_Click(object sender, EventArgs e)
        {
            if (stationMarkers.Count < 3)
            {
                MessageBox.Show("Ikke nok stationer");
                return;
            }

            string result = QueryDatabase.GetRecentData();

            if (result is null)
            {
                return;
            }

            var deviceData = QueryDatabase.ParseDataString(result);

            Coordinate station1 = new Coordinate(stationMarkers[0].Location.AbsoluteMap.X, stationMarkers[0].Location.AbsoluteMap.Y);
            Coordinate station2 = new Coordinate(stationMarkers[1].Location.AbsoluteMap.X, stationMarkers[1].Location.AbsoluteMap.Y);
            Coordinate station3 = new Coordinate(stationMarkers[2].Location.AbsoluteMap.X, stationMarkers[2].Location.AbsoluteMap.Y);

            var calculatedData = WifiDataThingy.GetDevicePositions(deviceData, station1, station2, station3);

            addingDevice = true;
            foreach (var item in calculatedData)
            {
                var newPoint = new FormsMap.GraphicsPoint(new Point((int)item.Item2.X, (int)item.Item2.Y), FormsMap.GraphicsPoint.PointRelation.AbsoluteMap, formsMap1);
                if (deviceMarkers.TryGetValue(item.Item1, out FormsMap.MapMarker marker))
                {
                    marker.Location = newPoint;
                }
                else
                {
                    deviceMarkers[item.Item1] = formsMap1.AddDefaultMarker(newPoint, false);
                }
            }
            addingDevice = false;

            formsMap1.Refresh();
        }

        private void buttonSaveStations_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in stationMarkers)
            {
                sb.Append(item.Location.AbsoluteMap.X);
                sb.Append('.');
                sb.Append(item.Location.AbsoluteMap.Y);
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
                stationMarkers.Clear();
                formsMap1.RemoveMarkers();

                foreach (var point in points)
                {
                    string[] xAndY = point.Split('.');
                    int x = int.Parse(xAndY[0]);
                    int y = int.Parse(xAndY[1]);

                    stationMarkers.Add(formsMap1.AddDefaultMarker(new FormsMap.GraphicsPoint(new Point(x, y), FormsMapController.FormsMap.GraphicsPoint.PointRelation.AbsoluteMap, formsMap1), true));
                }
            }
            catch (Exception)
            {
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (markerByNode.TryGetValue(e.Node, out FormsMap.MapMarker marker))
            {
                formsMap1.CenterMarker(marker);
            }
        }

        private void treeView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
            {
                return;
            }

            if (markerByNode.TryGetValue(treeView1.SelectedNode, out FormsMap.MapMarker marker))
            {
                if (treeView1.SelectedNode.Parent == deviceRootNode)
                {

                }
                else if (treeView1.SelectedNode.Parent == stationRootNode)
                {

                }
            }
        }
    }
}
