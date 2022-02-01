using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WifiFinderAlgorithm;

namespace LPSView
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void buttonConnectDatabase_Click(object sender, EventArgs e)
        {
            QueryDatabase.ConnectDatabase(textBoxHostname.Text, 20_000);
        }

        private void buttonManualQuery_Click(object sender, EventArgs e)
        {
            //string result = QueryDatabase.GetRecentData();
            //devices = QueryDatabase.ParseDataString(result);
            //labelDataCollected.Text = devices.Count.ToString();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            /*
            Coordinate station1 = new Coordinate((float)numericUpDownStation1X.Value, (float)numericUpDownStation1Y.Value);
            Coordinate station2 = new Coordinate((float)numericUpDownStation2X.Value, (float)numericUpDownStation2Y.Value);
            Coordinate station3 = new Coordinate((float)numericUpDownStation3X.Value, (float)numericUpDownStation3Y.Value);

            StringBuilder sb = new StringBuilder();

            foreach (var item in devices)
            {
                sb.Append($"{item.Key:X2}: ");
                if (item.Value.Count < 3)
                {
                    sb.AppendLine($"Kun {item.Value.Count} station(er)");
                    continue;
                }

                var intersection = WifiFinderAlgorithm.WifiFinderAlgorithm.FindDevice(
                    new Receiver(station1, item.Value.ElementAt(0).Key),
                    new Receiver(station2, item.Value.ElementAt(1).Key),
                    new Receiver(station3, item.Value.ElementAt(2).Key));

                sb.AppendLine("lokation: " + intersection);
            }

            richTextBoxAlgoOutput.Text = sb.ToString();*/
        }
    }
}
