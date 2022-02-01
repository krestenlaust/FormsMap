using System.Drawing;
using System.Windows.Forms;

namespace LPSView
{
    public partial class StationConfigPrompt : Form
    {
        public StationConfigPrompt(string stationName, int stationID, Point location)
        {
            InitializeComponent();

            labelStationName.Text = stationName;
            StationID = stationID;
            LocationX = location.X;
            LocationY = location.Y;
        }

        public int StationID
        {
            get => (int)numericUpDownStationID.Value;
            private set => numericUpDownStationID.Value = value;
        }

        public int LocationX
        {
            get => (int)numericUpDownLocationX.Value;
            private set => numericUpDownLocationX.Value = value;
        }

        public int LocationY
        {
            get => (int)numericUpDownLocationY.Value;
            private set => numericUpDownLocationY.Value = value;
        }

        private void buttonSave_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
