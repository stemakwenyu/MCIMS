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
    public partial class frmMain : Form
    {
        private int clr;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Height = this.MdiParent.Height;
            this.Width = this.MdiParent.Width;
            clr = 0;
            lblTitle3.Visible = false;
            lblUsername.Text = "Welcome " + Sessions.username;
            lblLoginTime.Text = "(Logged In: " + Sessions.loginTime + ")";
            groupBox1.Left = (this.ClientSize.Width - groupBox1.Width) / 2;
            groupBox1.Top = (this.ClientSize.Height - groupBox1.Height) / 2;
            lblTime.Left = groupBox1.Left;
            lblTime.Top = groupBox1.Top + groupBox1.Height;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString().ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (clr >= 5)
                clr = 0;

            if (clr == 0)
            {
                groupBox1.BackColor = Color.Magenta;
                lblTitle.BackColor = Color.Magenta;
                lblTitle2.BackColor = Color.Magenta;
                lblTitle3.BackColor = Color.Magenta;
                lblUsername.BackColor = Color.Magenta;
                lblLoginTime.BackColor = Color.Magenta;
                
            }
            else if (clr == 1)
            {
                groupBox1.BackColor = Color.SandyBrown;
                lblTitle.BackColor = Color.SandyBrown;
                lblTitle2.BackColor = Color.SandyBrown;
                lblTitle3.BackColor = Color.SandyBrown;
                lblUsername.BackColor = Color.SandyBrown;
                lblLoginTime.BackColor = Color.SandyBrown;
            }
            else if (clr == 2)
            {
                groupBox1.BackColor = Color.LightSteelBlue;
                lblTitle.BackColor = Color.LightSteelBlue;
                lblTitle2.BackColor = Color.LightSteelBlue;
                lblTitle3.BackColor = Color.LightSteelBlue;
                lblUsername.BackColor = Color.LightSteelBlue;
                lblLoginTime.BackColor = Color.LightSteelBlue;
            }
            else if (clr == 3)
            {
                groupBox1.BackColor = Color.Violet;
                lblTitle.BackColor = Color.Violet;
                lblTitle2.BackColor = Color.Violet;
                lblTitle3.BackColor = Color.Violet;
                lblUsername.BackColor = Color.Violet;
                lblLoginTime.BackColor = Color.Violet;
            }
            else
            {
                groupBox1.BackColor = Color.LightSkyBlue;
                lblTitle.BackColor = Color.LightSkyBlue;
                lblTitle2.BackColor = Color.LightSkyBlue;
                lblTitle3.BackColor = Color.LightSkyBlue;
                lblUsername.BackColor = Color.LightSkyBlue;
                lblLoginTime.BackColor = Color.LightSkyBlue;
            }
            clr++;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (lblTitle3.Visible == false)
            {
                lblTitle2.Visible = false;
                lblTitle3.Visible = true;
            }
            else
            {
                
                lblTitle3.Visible = false;
                lblTitle2.Visible = true;
            }
        }
    }
}
