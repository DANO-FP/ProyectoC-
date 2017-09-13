using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace APP_Admin
{
    public partial class frmPresentacion : Form
    {
        public frmPresentacion()
        {
            InitializeComponent();
        }

        private void tempoPre_Tick(object sender, EventArgs e)
        {
            tempoPre.Enabled = false;

            this.Hide();

            frmZona fz = new frmZona();
            fz.ShowDialog();
            
        }
    }
}
