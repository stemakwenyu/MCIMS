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
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
           
            frmMain main = new frmMain();
            main.MdiParent = this;
            
            main.Show();
           
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin frmlg = new frmLogin();
            frmlg.Visible = true;
            this.Dispose();
        }
        private void depMenu_Click(object sender, EventArgs e)
        {
            frmDepartment dep = new frmDepartment();
            dep.MdiParent = this;
            dep.Visible = true;
        }

        private void facultyMenu_Click(object sender, EventArgs e)
        {
            frmFaculty fc = new frmFaculty();
            fc.MdiParent = this;
            fc.Visible = true;
        }

        private void programMenu_Click(object sender, EventArgs e)
        {
            frmProgram prog = new frmProgram();
            prog.MdiParent = this;
            prog.Visible = true;
        }
        private void staffMenu_Click(object sender, EventArgs e)
        {
            frmStaff staff = new frmStaff();
            staff.MdiParent = this;
            staff.Visible = true;
        }

        private void courseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCourse cos = new frmCourse();
            cos.MdiParent = this;
            cos.Visible = true;
        }

        private void studentMenu_Click(object sender, EventArgs e)
        {
            frmStudent student = new frmStudent();
            student.MdiParent = this;
            student.Visible = true;
        }

        private void programCoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProgramCourse progcos = new frmProgramCourse();
            progcos.MdiParent = this;
            progcos.Visible = true;
        }

        private void loadingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoading ld = new frmLoading();
            ld.MdiParent = this;
            ld.Visible = true;
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutUs  abt = new AboutUs();
            abt.MdiParent = this;
            abt.Visible = true;
        }

        private void statusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        
    }
}
