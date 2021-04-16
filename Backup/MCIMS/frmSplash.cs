using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MCIMS
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value = progressBar1.Value + 20;
                lblProgress.Text = "Loading please...." + progressBar1.Value + "%";
                if (progressBar1.Value == 100)
                {
                    

                    frmLogin frmlg = new frmLogin();
                    frmlg.Visible = true;
                    this.Hide();
                    

                }
            }
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            groupBox1.Left = (this.ClientSize.Width - groupBox1.Width) / 2;
            groupBox1.Top = (this.ClientSize.Height - groupBox1.Height) / 2;
        }
    }
}
