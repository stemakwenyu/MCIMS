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
    public partial class frmFaculty : Form
    {
        
        private string facCode;
        private string optn;
        private string query;
        public frmFaculty()
        {
            InitializeComponent();

        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clean();
        }
        private void clean()
        {
            txtFacultyName.Text = "";
            txtDescription.Text = "";
            if (cboFacultyCode.Visible)
            {
                cboFacultyCode.Text = "";
                cboFacultyCode.Focus();
            }
            else
            {
                txtFacultyCode.Text = "";
                txtFacultyCode.Focus();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchValue.Text = "All";
            cboSearchCriteria.Text = "All";
            cboSearchCriteria.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            txtFacultyCode.Text = txtFacultyCode.Text.ToUpper();
            cboFacultyCode.Text = cboFacultyCode.Text.ToUpper();
            if (txtFacultyCode.Text.Replace(" ", "") == "" && cboFacultyCode.Visible ==false)
            {
                MessageBox.Show("Ensure all fields are filled!","MMUST CIMS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                txtFacultyCode.Focus();
            }
            else if (cboFacultyCode.Text.Replace(" ", "") == "" && cboFacultyCode.Visible == true)
            {
                MessageBox.Show("Ensure all fields are filled!","MMUST CIMS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                cboFacultyCode.Focus();
            }
            else if (txtFacultyName.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!","MMUST CIMS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                txtFacultyName.Focus();
            }
            else if (txtDescription.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!","MMUST CIMS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                txtDescription.Focus();
            }
            else
            {

                string msg = "";
                int op;
                if (facCode == "")
                {
                    if (FindRecord(txtFacultyCode.Text.ToString()) == false)
                    {


                        query = "INSERT INTO faculty VALUES('" + txtFacultyCode.Text.ToString() + "', '" + txtFacultyName.Text.ToString() + "', '" + txtDescription.Text.ToString() + "')";
                        msg = "Records have been successfully saved";
                        op = 0;
                    }
                    else
                    {


                        query = "UPDATE faculty SET Faculty_Code='" + txtFacultyCode.Text.ToString() + "', Faculty_Name= '" + txtFacultyName.Text.ToString() + "', Description='" + txtDescription.Text.ToString() + "' WHERE Faculty_Code='" + txtFacultyCode.Text.ToString() + "'";
                        msg = "Records have been Successfully updated!";
                        op = 1;
                    }
                }
                else
                {
                    query = "UPDATE faculty SET Faculty_Code='" + cboFacultyCode.Text.ToString() + "', Faculty_Name= '" + txtFacultyName.Text.ToString() + "', Description='" + txtDescription.Text.ToString() + "' WHERE Faculty_Code='" + facCode + "'";
                    msg = "Records have been Successfully updated!";
                    op = 1;
                }

                //open connection
                Conn connect = new Conn();
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
                        MessageBox.Show(msg,"MMUST CIMS",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {

                        clean();
                        MessageBox.Show("Changes not Effected!", "MMUST CIMS",MessageBoxButtons.OK ,MessageBoxIcon.Information);
                    }
                    connect.CloseConnection();
                    GetFaculties();
                    
                    
                }
                

            }
        }
        private bool FindRecord(string fcode)
        {
            Conn connect = new Conn();
            if (connect.OpenConnection() == true)
            {

                query = "SELECT * FROM faculty WHERE Faculty_Code='" + fcode + "'";
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

        private void txtFacultyCode_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void frmFaculty_Load(object sender, EventArgs e)
        {
            facCode = "";
            GetFaculties();
            cboFacultyCode.Visible = false;
            groupBox56.Left = (this.ClientSize.Width - groupBox56.Width) / 2;
            groupBox56.Top = (this.ClientSize.Height - groupBox56.Height) / 2;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (cboSearchCriteria.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!","MMUST CIMS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                cboSearchCriteria.Focus();
            }
            else if (txtSearchValue.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!","MMUST CIMS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
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
                        query = "SELECT * FROM faculty ORDER BY Faculty_Code ASC";
                    
                    }
                    else if (cboSearchCriteria.Text == "Faculty Code")
                    {
                        query = "SELECT * FROM faculty WHERE Faculty_Code LIKE '"+ searchval  +"' ORDER BY Faculty_Code ASC";

                    }
                    else if (cboSearchCriteria.Text == "Faculty Name")
                    {
                        query = "SELECT * FROM faculty WHERE Faculty_Name LIKE '" + searchval + "' ORDER BY Faculty_Code ASC";

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
                    while(dataReader.Read())
                    {
                        if (dataReader["Faculty_Code"].ToString().Replace(" ", "") != "")
                        {
                            string[] row = new string[] { dataReader["Faculty_Code"].ToString(), dataReader["Faculty_Name"].ToString(), dataReader["Description"].ToString() };
                            dataGridView1.Rows.Add(row);
                        }
                        
                    }
                    

                    connect.CloseConnection();
                }

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cboFacultyCode.Visible = true;
            cboFacultyCode.Text=this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            txtFacultyName.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            txtDescription.Text =this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
            facCode = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
           
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            cboFacultyCode.Visible = true;
            

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

        private void cboFacultyCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Conn connect = new Conn();
            if (connect.OpenConnection() == true)
            {

                query = "SELECT * FROM faculty WHERE Faculty_Code='" + cboFacultyCode.Text.ToString() + "'";
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                if (dataReader.Read())
                {
                    txtFacultyName.Text = dataReader["Faculty_Name"].ToString();
                    txtDescription.Text = dataReader["Description"].ToString();
                    facCode = cboFacultyCode.Text;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cboFacultyCode.Visible == false)
            {
                MessageBox.Show("Select Records to Delete", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboFacultyCode.Visible = true;
                cboFacultyCode.Focus();
            }
            else if (cboFacultyCode.Text.Replace(" ", "") == "" && cboFacultyCode.Visible == true)
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboFacultyCode.Focus();
            }
            else if (txtFacultyName.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtFacultyName.Focus();
            }
            else if (txtDescription.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDescription.Focus();
            }
            else
            {
                Conn connect = new Conn();
                if (connect.OpenConnection() == true)
                {
                    if (MessageBox.Show("Are you sure you want to delete these details?", "MMUST CIMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        query = "DELETE FROM faculty WHERE Faculty_Code='" + cboFacultyCode.Text + "'";
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
                    GetFaculties();
                    
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cboFacultyCode.Visible = false;
            facCode = "";
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
                        query = "SELECT * FROM faculty ORDER BY Faculty_Code ASC";

                    }
                    else if (cboSearchCriteria.Text == "Faculty Code")
                    {
                        query = "SELECT * FROM faculty WHERE Faculty_Code LIKE '" + searchval + "' ORDER BY Faculty_Code ASC";

                    }
                    else if (cboSearchCriteria.Text == "Faculty Name")
                    {
                        query = "SELECT * FROM faculty WHERE Faculty_Name LIKE '" + searchval + "' ORDER BY Faculty_Code ASC";

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
                        if (dataReader["Faculty_Code"].ToString().Replace(" ", "") != "")
                        {
                            string[] row = new string[] { dataReader["Faculty_Code"].ToString(), dataReader["Faculty_Name"].ToString(), dataReader["Description"].ToString() };
                            dataGridView1.Rows.Add(row);
                        }

                    }
                    
                    connect.CloseConnection();
                    PrintDialog printDial = new PrintDialog();
                    printDial.Document = printDocument1;
                    printDial.UseEXDialog = true;
                    if (DialogResult.OK == printDial.ShowDialog())
                    {
                        printDocument1.DocumentName = "Faculty Details";
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

            Bitmap bm = new Bitmap(this.dataGridView1.Width,this.dataGridView1.Height );
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);

            this.dataGridView1.Height =113;
            this.dataGridView1.Width = 631;
            this.dataGridView1.ScrollBars = ScrollBars.Both;
            dataGridView1.BorderStyle = BorderStyle.FixedSingle;
            dataGridView1.BackgroundColor = Color.Gray;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime1.Text = DateTime.Now.ToLongTimeString().ToString();
        }

       

        

        

        
    }
}
