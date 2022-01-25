using System;
using System.Windows.Forms;

namespace LearnmarkMap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool updatingProperty;

        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDownPanX.Minimum = -formsMap1.MapImage.Width + 100;
            numericUpDownPanY.Minimum = -formsMap1.MapImage.Height + 100;

            numericUpDownPanX.Maximum = 100;
            numericUpDownPanY.Maximum = 100;

            updatingProperty = true;
            formsMap1.ZoomFactor = (float)numericUpDownZoomFactor.Value;
            updatingProperty = false;
        }

        private void formsMap1_PanChanged(object sender, EventArgs e)
        {
            if (updatingProperty)
            {
                return;
            }

            numericUpDownPanX.Value = Math.Min(Math.Max(formsMap1.Pan.X, numericUpDownPanX.Minimum), numericUpDownPanX.Maximum);
            numericUpDownPanY.Value = Math.Min(Math.Max(formsMap1.Pan.Y, numericUpDownPanY.Minimum), numericUpDownPanY.Maximum);
        }

        private void formsMap1_ZoomFactorChanged(object sender, EventArgs e)
        {
            if (updatingProperty)
            {
                return;
            }

            numericUpDownZoomFactor.Value = Math.Min(Math.Max((decimal)formsMap1.ZoomFactor, numericUpDownZoomFactor.Minimum), numericUpDownZoomFactor.Maximum);
        }

        private void formsMap1_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDownPanX_ValueChanged(object sender, EventArgs e)
        {
            updatingProperty = true;
            formsMap1.Pan = new System.Drawing.Point((int)numericUpDownPanX.Value, formsMap1.Pan.Y);
            formsMap1.Refresh();
            updatingProperty = false;
        }

        private void numericUpDownPanY_ValueChanged(object sender, EventArgs e)
        {
            updatingProperty = true;
            formsMap1.Pan = new System.Drawing.Point(formsMap1.Pan.X, (int)numericUpDownPanY.Value);
            formsMap1.Refresh();
            updatingProperty = false;
        }

        private void numericUpDownZoomFactor_ValueChanged(object sender, EventArgs e)
        {
            updatingProperty = true;
            formsMap1.ZoomFactor = (float)numericUpDownZoomFactor.Value;
            formsMap1.Refresh();
            updatingProperty = false;
        }
    }
}
