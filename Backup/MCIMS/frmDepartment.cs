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
    public partial class frmDepartment : Form
    {
        private string depCode;
        private string optn;
        private string query;
        public frmDepartment()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clean();
        }
        private void clean()
        {
            txtDepName.Text = "";
            txtDescription.Text = "";
            cboFacultyCode.Text = "";
            if (cboDepCode.Visible)
            {
                cboDepCode.Text = "";
                cboDepCode.Focus();
            }
            else
            {
                txtDepCode.Text = "";
                txtDepCode.Focus();
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
            txtDepCode.Text = txtDepCode.Text.ToUpper();
            cboDepCode.Text = cboDepCode.Text.ToUpper();
            if (txtDepCode.Text.Replace(" ", "") == "" && cboDepCode.Visible ==false)
            {
                MessageBox.Show("Ensure all fields are filled!","MMUST CIMS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                txtDepCode.Focus();
            }
            else if (cboDepCode.Text.Replace(" ", "") == "" && cboDepCode.Visible == true)
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboDepCode.Focus();
            }
            else if (txtDepName.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDepName.Focus();
            }
            else if (txtDescription.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDescription.Focus();
            }
            else if (cboFacultyCode.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboFacultyCode.Focus();
            }
            else
            {
                string msg = "";
                int op;
                if (depCode == "")
                {
                    if (FindRecord(txtDepCode.Text.ToString()) == false)
                    {


                        query = "INSERT INTO department VALUES('" + txtDepCode.Text.ToString() + "', '" + txtDepName.Text.ToString() + "', '" + txtDescription.Text.ToString() + "','" + cboFacultyCode.Text.ToString() + "')";
                        msg = "Records have been successfully saved";
                        op = 0;
                    }
                    else
                    {


                        query = "UPDATE department SET Department_Code='" + txtDepCode.Text.ToString() + "', Department_Name= '" + txtDepName.Text.ToString() + "', Description='" + txtDescription.Text.ToString() + "', Faculty_Code='" + cboFacultyCode.Text.ToString() + "' WHERE Department_Code='" + txtDepCode.Text.ToString() + "'";
                        msg = "Records have been Successfully updated!";
                        op = 1;
                    }
                }
                else
                {
                    query = "UPDATE department SET Department_Code='" + cboDepCode.Text.ToString() + "', Department_Name= '" + txtDepName.Text.ToString() + "', Description='" + txtDescription.Text.ToString() + "',Faculty_Code='" + cboFacultyCode.Text.ToString() + "' WHERE Department_Code='" + depCode + "'";
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
                    GetDepartments();


                }


            }
        }

        private void frmDepartment_Load(object sender, EventArgs e)
        {
            cboDepCode.Visible = false;
            depCode = "";
            GetDepartments();
            GetFaculties();
            groupBox56.Left = (this.ClientSize.Width - groupBox56.Width) / 2;
            groupBox56.Top = (this.ClientSize.Height - groupBox56.Height) / 2;
        }
        private bool FindRecord(string dcode)
        {
            Conn connect = new Conn();
            if (connect.OpenConnection() == true)
            {

                query = "SELECT * FROM department WHERE Department_Code='" + dcode + "'";
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
        private void btnEdit_Click(object sender, EventArgs e)
        {
            cboDepCode.Visible = true;
        }
        private void GetDepartments()
        {
            Conn connect = new Conn();
            if (connect.OpenConnection() == true)
            {
                query = "SELECT * FROM department ORDER BY Department_Code ASC";
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                this.cboDepCode.Items.Clear();
                while (dataReader.Read())
                {
                    if (dataReader["Department_Code"].ToString().Replace(" ", "") != "")
                    {
                        this.cboDepCode.Items.Add(dataReader["Department_Code"].ToString());
                    }
                }
                connect.CloseConnection();



            }
        }
        private void GetFaculties()
        {
            Conn connect = new Conn();
            if (connect.OpenConnection() == true)
            {
                query = "SELECT * FROM faculty ORDER BY Faculty_Code ASC";
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                this.cboFacultyCode.Items.Clear();
                while (dataReader.Read())
                {
                    if (dataReader["Faculty_Code"].ToString().Replace(" ", "") != "")
                    {
                        this.cboFacultyCode.Items.Add(dataReader["Faculty_Code"].ToString());
                    }
                }
                connect.CloseConnection();



            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cboDepCode.Visible == false)
            {
                MessageBox.Show("Select Records to Delete", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboDepCode.Visible = true;
                cboDepCode.Focus();
            }
            else if (cboDepCode.Text.Replace(" ", "") == "" && cboDepCode.Visible == true)
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboDepCode.Focus();
            }
            else if (txtDepName.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDepName.Focus();
            }
            else if (txtDescription.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDescription.Focus();
            }
            else if (cboFacultyCode.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboFacultyCode.Focus();
            }
            else
            {
                Conn connect = new Conn();
                connect.CloseConnection();
                if (connect.OpenConnection() == true)
                {
                    if (MessageBox.Show("Are you sure you want to delete these details?", "MMUST CIMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        query = "DELETE FROM department WHERE Department_Code='" + cboDepCode.Text + "'";
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
                    GetDepartments();

                }

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
                        query = "SELECT * FROM department ORDER BY Department_Code ASC";

                    }
                    else if (cboSearchCriteria.Text == "Faculty Code")
                    {
                        query = "SELECT * FROM department WHERE Faculty_Code LIKE '" + searchval + "' ORDER BY Department_Code ASC";

                    }
                    else if (cboSearchCriteria.Text == "Department Code")
                    {
                        query = "SELECT * FROM department WHERE Department_Code LIKE '" + searchval + "' ORDER BY Department_Code ASC";

                    }
                    else if (cboSearchCriteria.Text == "Department Name")
                    {
                        query = "SELECT * FROM department WHERE Department_Name LIKE '" + searchval + "' ORDER BY Department_Code ASC";

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
                        if (dataReader["Department_Code"].ToString().Replace(" ", "") != "")
                        {
                            string[] row = new string[] { dataReader["Department_Code"].ToString(), dataReader["Department_Name"].ToString(), dataReader["Description"].ToString(), dataReader["Faculty_Code"].ToString() };
                            dataGridView1.Rows.Add(row);
                        }

                    }


                    connect.CloseConnection();
                }

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cboDepCode.Visible = true;
            cboDepCode.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            txtDepName.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            txtDescription.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
            cboFacultyCode.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();
            depCode = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
           
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
        }

        private void cboDepCode_SelectedIndexChanged(object sender, EventArgs e)
        {

            Conn connect = new Conn();
            if (connect.OpenConnection() == true)
            {

                query = "SELECT * FROM department WHERE Department_Code='" + cboDepCode.Text.ToString() + "'";
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                if (dataReader.Read())
                {
                    cboDepCode.Text = dataReader["Department_Code"].ToString();
                    cboFacultyCode.Text = dataReader["Faculty_Code"].ToString();
                    txtDepName.Text = dataReader["Department_Name"].ToString();
                    txtDescription.Text = dataReader["Description"].ToString();
                    depCode = cboDepCode.Text;
                }
                connect.CloseConnection();
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cboDepCode.Visible = false;
            clean();
            depCode = "";
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
                        query = "SELECT * FROM department ORDER BY Department_Code ASC";

                    }
                    else if (cboSearchCriteria.Text == "Faculty Code")
                    {
                        query = "SELECT * FROM department WHERE Faculty_Code LIKE '" + searchval + "' ORDER BY Department_Code ASC";

                    }
                    else if (cboSearchCriteria.Text == "Department Code")
                    {
                        query = "SELECT * FROM department WHERE Department_Code LIKE '" + searchval + "' ORDER BY Department_Code ASC";

                    }
                    else if (cboSearchCriteria.Text == "Department Name")
                    {
                        query = "SELECT * FROM department WHERE Department_Name LIKE '" + searchval + "' ORDER BY Department_Code ASC";

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
                        if (dataReader["Department_Code"].ToString().Replace(" ", "") != "")
                        {
                            string[] row = new string[] { dataReader["Department_Code"].ToString(), dataReader["Department_Name"].ToString(), dataReader["Description"].ToString(), dataReader["Faculty_Code"].ToString() };
                            dataGridView1.Rows.Add(row);
                        }

                    }


                    connect.CloseConnection();
                    PrintDialog printDial = new PrintDialog();
                    printDial.Document = printDocument1;
                    printDial.UseEXDialog = true;
                    if (DialogResult.OK == printDial.ShowDialog())
                    {
                        printDocument1.DocumentName = "Department Details";
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
