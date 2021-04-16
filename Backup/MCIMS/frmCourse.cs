using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MCIMS
{
    public partial class frmCourse : Form
    {
        private string cosCode;
        private string optn;
        private string query;
        public frmCourse()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clean();
        }
        private void clean()
        {
            txtCourseName.Text = "";
            txtUnits.Text = "";
            txtDescription.Text = "";
            cboSemCode.Text = "";
            cboYoS.Text = "";
            if (cboCourseCode.Visible)
            {
                cboCourseCode.Text = "";
                cboCourseCode.Focus();
            }
            else
            {
                txtCourseCode.Text = "";
                txtCourseCode.Focus();
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cboSearchCriteria.Text = "All";
            txtSearchValue.Text = "All";
            cboSearchCriteria.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int units;
            string unt = txtUnits.Text.Trim().ToString();
            txtCourseCode.Text = txtCourseCode.Text.ToUpper();
            cboCourseCode.Text = cboCourseCode.Text.ToUpper();
            if (txtCourseCode.Text.Replace(" ", "") == "" && cboCourseCode.Visible ==false)
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCourseCode.Focus();
            }
            else if (cboCourseCode.Text.Replace(" ", "") == "" && cboCourseCode.Visible == true)
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCourseCode.Focus();
            }
            else if (txtCourseName.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCourseName.Focus();
            }
            else if (txtDescription.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDescription.Focus();
            }
            else if (cboSemCode.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboSemCode.Focus();
            }
            else if (cboYoS.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboYoS.Focus();
            }
            else if (txtUnits.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUnits.Focus();
            }
            else if (!int.TryParse(unt, out units))
            {
                MessageBox.Show("Invalid data!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUnits.Focus();
            }
            else
            {
                string msg = "";
                int op;
                if (cosCode == "")
                {
                    if (FindRecord(txtCourseCode.Text.ToString()) == false)
                    {

                   
                        query = "INSERT INTO course VALUES('" + txtCourseCode.Text.ToString() + "', '" + txtCourseName.Text.ToString() + "','" + txtDescription.Text + "', '" + cboSemCode.Text.ToString() + "','" + cboYoS.Text.ToString() + "',"+units+")";
                        msg = "Records have been successfully saved";
                        op = 0;
                    }
                    else
                    {


                        query = "UPDATE course SET Course_Code='" + txtCourseCode.Text.ToString() + "', Course_Name= '" + txtCourseName.Text.ToString() + "', Description='" + txtDescription.Text.ToString() + "', Semester='" + cboSemCode.Text.ToString() + "', Year_of_Study='"+ cboYoS.Text +"',Units="+units+" WHERE Course_Code='" + txtCourseCode.Text.ToString() + "'";
                        msg = "Records have been Successfully updated!";
                        op = 1;
                    }
                }
                else
                {
                    query = "UPDATE course SET Course_Code='" + cboCourseCode.Text.ToString() + "', Course_Name= '" + txtCourseName.Text.ToString() + "', Description='" + txtDescription.Text.ToString() + "',Semester='" + cboSemCode.Text.ToString() + "',Year_of_Study='" + cboYoS.Text + "',Units=" + units + " WHERE Course_Code='" + cosCode + "'";
                    msg = "Records have been Successfully updated!";
                    op = 1;
                }

                //open connection
                Conn connect = new Conn();
                connect.CloseConnection();
                if (connect.OpenConnection() == true)
                {
                    if (op == 0)
                    {
                        optn = "Are you sure you want to Insert these details?";
                        //optn = MessageBox.Show("Are you sure you want to Insert these details?", "MMUST CIMS", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    }
                    else
                    {
                        optn = optn = "Are you sure you want to update these details?";
                        //optn = MessageBox.Show("Are you sure you want to update these details?", "MMUST CIMS", MessageBoxButtons.YesNoMessageBoxIcon.Question);
                    }
                    if (MessageBox.Show(optn, "MMUST CIMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //create command and assign the query and connection from the constructor
                        MySqlCommand cmd = new MySqlCommand(query, connect.connection);

                        //Execute command
                        cmd.ExecuteNonQuery();

                        //close connection


                        clean();
                        MessageBox.Show(msg, "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                        clean();
                        MessageBox.Show("Changes not Effected!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    connect.CloseConnection();
                    GetCourses();


                }

            }
        }
        private bool FindRecord(string ccode)
        {
            Conn connect = new Conn();
            if (connect.OpenConnection() == true)
            {

                query = "SELECT * FROM course WHERE Course_Code='" + ccode + "'";
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                if (dataReader.Read())
                {
                    connect.CloseConnection();
                    return true;
                }
                else
                {
                    connect.CloseConnection();
                    return false;
                }
            }
            else
            {
                return true;
            }



        }
        private void frmCourse_Load(object sender, EventArgs e)
        {
            cboCourseCode.Visible = false;
            cosCode = "";
            GetCourses();
            groupBox56.Left = (this.ClientSize.Width - groupBox56.Width) / 2;
            groupBox56.Top = (this.ClientSize.Height - groupBox56.Height) / 2;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cboCourseCode.Visible == false)
            {
                MessageBox.Show("Select Records to Delete", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboCourseCode.Visible = true;
                cboCourseCode.Focus();
            }
            else if (cboCourseCode.Text.Replace(" ", "") == "" && cboCourseCode.Visible == true)
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCourseCode.Focus();
            }
            else if (txtCourseName.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCourseName.Focus();
            }
            else if (txtDescription.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDescription.Focus();
            }
            else if (cboSemCode.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboSemCode.Focus();
            }
            else if (cboYoS.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboYoS.Focus();
            }
            else
            {
                Conn connect = new Conn();
                connect.CloseConnection();
                if (connect.OpenConnection() == true)
                {
                    if (MessageBox.Show("Are you sure you want to delete these details?", "MMUST CIMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        query = "DELETE FROM course WHERE Course_Code='" + cboCourseCode.Text + "'";
                        //create command and assign the query and connection from the constructor
                        MySqlCommand cmd = new MySqlCommand(query, connect.connection);

                        //Execute command
                        cmd.ExecuteNonQuery();

                        //close connection

                        clean();

                        MessageBox.Show("Records Successfully Deleted!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        clean();
                        MessageBox.Show("Records Not Deleted!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    connect.CloseConnection();
                    GetCourses();

                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            cboCourseCode.Visible = true;
        }
        private void GetCourses()
        {
            Conn connect = new Conn();
            if (connect.OpenConnection() == true)
            {
                query = "SELECT * FROM course ORDER BY Course_Code ASC";
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                this.cboCourseCode.Items.Clear();
                while (dataReader.Read())
                {
                    if (dataReader["Course_Code"].ToString().Replace(" ", "") != "")
                    {
                        this.cboCourseCode.Items.Add(dataReader["Course_Code"].ToString());
                    }
                }
                connect.CloseConnection();



            }
        }

        private void cboSearchCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSearchCriteria.Text == "All")
            {
                txtSearchValue.Text = "All";
            }
            else
            {
                txtSearchValue.Text = "";
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (cboSearchCriteria.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboSearchCriteria.Focus();
            }
            else if (txtSearchValue.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSearchValue.Focus();
            }
            else
            {
                Conn connect = new Conn();
                if (connect.OpenConnection() == true)
                {
                    string searchval = "%" + txtSearchValue.Text + "%";
                    if (cboSearchCriteria.Text == "All")
                    {
                        query = "SELECT * FROM course ORDER BY Course_Code ASC";

                    }
                    else if (cboSearchCriteria.Text == "Course Code")
                    {
                        query = "SELECT * FROM course WHERE Course_Code LIKE '" + searchval + "' ORDER BY Course_Code ASC";

                    }
                    else if (cboSearchCriteria.Text == "Course Name")
                    {
                        query = "SELECT * FROM course WHERE Course_Name LIKE '" + searchval + "' ORDER BY Course_Code ASC";

                    }
                    else
                    {
                        MessageBox.Show("Invalid Criteria", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboSearchCriteria.Focus();
                    }


                    MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //Read the data and store them in the list
                    this.dataGridView1.Rows.Clear();
                    while (dataReader.Read())
                    {
                        if (dataReader["Course_Code"].ToString().Replace(" ", "") != "")
                        {
                            string[] row = new string[] { dataReader["Course_Code"].ToString(), dataReader["Course_Name"].ToString(), dataReader["Semester"].ToString(), dataReader["Year_of_Study"].ToString(),dataReader["Units"].ToString(), dataReader["Description"].ToString() };
                            dataGridView1.Rows.Add(row);
                        }

                    }


                    connect.CloseConnection();
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cboCourseCode.Visible = true;
            cboCourseCode.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            //txtCourseName.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            //txtDescription.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
            //cboSemCode.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();
            //cboYoS.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString();
            cosCode = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
        }

        private void cboCourseCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Conn connect = new Conn();
            if (connect.OpenConnection() == true)
            {

                query = "SELECT * FROM course WHERE Course_Code='" + cboCourseCode.Text.ToString() + "'";
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                if (dataReader.Read())
                {
                    cboCourseCode.Text = dataReader["Course_Code"].ToString();
                    cboSemCode.Text = dataReader["Semester"].ToString();
                    txtCourseName.Text = dataReader["Course_Name"].ToString();
                    txtDescription.Text = dataReader["Description"].ToString();
                    cboYoS.Text = dataReader["Year_of_Study"].ToString();
                    txtUnits.Text = dataReader["Units"].ToString();
                    cosCode = cboCourseCode.Text;
                }
                connect.CloseConnection();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cboCourseCode.Visible = false;
            cosCode = "";
            clean();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (cboSearchCriteria.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboSearchCriteria.Focus();
            }
            else if (txtSearchValue.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSearchValue.Focus();
            }
            else
            {
                Conn connect = new Conn();
                if (connect.OpenConnection() == true)
                {
                    string searchval = "%" + txtSearchValue.Text + "%";
                    if (cboSearchCriteria.Text == "All")
                    {
                        query = "SELECT * FROM course ORDER BY Course_Code ASC";

                    }
                    else if (cboSearchCriteria.Text == "Course Code")
                    {
                        query = "SELECT * FROM course WHERE Course_Code LIKE '" + searchval + "' ORDER BY Course_Code ASC";

                    }
                    else if (cboSearchCriteria.Text == "Course Name")
                    {
                        query = "SELECT * FROM course WHERE Course_Name LIKE '" + searchval + "' ORDER BY Course_Code ASC";

                    }
                    else
                    {
                        MessageBox.Show("Invalid Criteria", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboSearchCriteria.Focus();
                    }


                    MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //Read the data and store them in the list
                    this.dataGridView1.Rows.Clear();
                    while (dataReader.Read())
                    {
                        if (dataReader["Course_Code"].ToString().Replace(" ", "") != "")
                        {
                            string[] row = new string[] { dataReader["Course_Code"].ToString(), dataReader["Course_Name"].ToString(), dataReader["Semester"].ToString(), dataReader["Year_of_Study"].ToString(), dataReader["Units"].ToString(),dataReader["Description"].ToString() };
                            dataGridView1.Rows.Add(row);
                        }

                    }
                    connect.CloseConnection();
                    PrintDialog printDial = new PrintDialog();
                    printDial.Document = printDocument1;
                    printDial.UseEXDialog = true;
                    if (DialogResult.OK == printDial.ShowDialog())
                    {
                        printDocument1.DocumentName = "Course Details";
                        printDocument1.Print();
                    }
                }

            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.Width = dataGridView1.Width + 100;

            int totalRowHeight = dataGridView1.ColumnHeadersHeight;

            foreach (DataGridViewRow row in dataGridView1.Rows)
                totalRowHeight += row.Height;

            dataGridView1.Height = totalRowHeight;
            this.Height = dataGridView1.Height + 100;
            this.dataGridView1.ScrollBars = ScrollBars.None;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.BackgroundColor = Color.White;

            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);

            this.dataGridView1.Height = 113;
            this.dataGridView1.Width = 689;
            this.dataGridView1.ScrollBars = ScrollBars.Both;
            dataGridView1.BorderStyle = BorderStyle.FixedSingle;
            dataGridView1.BackgroundColor = Color.Gray;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString().ToString();
        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        

        

        
    }
}
