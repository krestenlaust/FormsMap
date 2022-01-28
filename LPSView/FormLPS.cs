using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LPSView
{
    public partial class FormLPSView : Form
    {
        public FormLPSView()
        {
            InitializeComponent();
        }

        private void FormLPSView_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonConfigure_Click(object sender, EventArgs e)
        {
            ConfigForm configForm = new ConfigForm();
            configForm.Show();
        }
    }
}
