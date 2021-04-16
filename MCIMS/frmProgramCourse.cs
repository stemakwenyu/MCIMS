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
    public partial class frmProgramCourse : Form
    {
        private string cosProgCode;
        private string optn;
        private string query;
        public frmProgramCourse()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clean();
        }
        private void clean()
        {
            cboCourseCode.Text = "";
            cboProgCode.Text = "";
            txtCourseProgCode.Text = "";
            cboYoS.Text = "";
            cboSemester.Text = "";
            if (cboCourseProgCode.Visible)
            {
                cboCourseProgCode.Text = "";
                cboCourseProgCode.Focus();
            }
            else
            {
                txtCourseProgCode.Text = "";
                cboCourseCode.Focus();
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cboSearchCriteria.Text ="All";
            txtSearchValue.Text = "All";
            cboSearchCriteria.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCourseProgCode.Text.Replace(" ", "") == "" && cboCourseProgCode.Visible ==false)
            {
                MessageBox.Show("Ensure all fields are filled!","MMUST CIMS",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCourseProgCode.Focus();
            }
            else if (cboCourseProgCode.Text.Replace(" ", "") == "" && cboCourseProgCode.Visible == true)
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboCourseProgCode.Focus();
            }
            else if (cboCourseCode.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboCourseCode.Focus();
            }
            else if (cboSemester.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboSemester.Focus();
            }
            else if (cboYoS.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboYoS.Focus();
            }
            else
            {
                string msg = "";
                int op;
                if (cosProgCode == "")
                {
                    if (FindRecord(txtCourseProgCode.Text.ToString()) == false)
                    {


                        query = "INSERT INTO program_course VALUES('" + txtCourseProgCode.Text.ToString() + "', '" + cboCourseCode.Text.ToString() + "','" + cboProgCode.Text + "', '" + cboSemester.Text.ToString() + "','" + cboYoS.Text.ToString() + "')";
                        msg = "Records have been successfully saved";
                        op = 0;
                    }
                    else
                    {


                        query = "UPDATE program_course SET ProgCourse_Code='" + txtCourseProgCode.Text.ToString() + "', Course_Code= '" + cboCourseCode.Text.ToString() + "', Program_Code='" + cboProgCode.Text.ToString() + "', Semester='" + cboSemester.Text.ToString() + "', Year_of_Study='" + cboYoS.Text + "' WHERE ProgCourse_Code='" + txtCourseProgCode.Text.ToString() + "'";
                        msg = "Records have been Successfully updated!";
                        op = 1;
                    }
                }
                else
                {
                    query = "UPDATE program_course SET ProgCourse_Code='" + cboCourseProgCode.Text.ToString() + "', Course_Code= '" + cboCourseCode.Text.ToString() + "', Program_Code='" + cboProgCode.Text.ToString() + "',Semester='" + cboSemester.Text.ToString() + "',Year_of_Study='" + cboYoS.Text + "' WHERE ProgCourse_Code='" + cosProgCode + "'";
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
                    GetProgCourses();


                }

            }
        }
        private bool FindRecord(string cpcode)
        {
            Conn connect = new Conn();
            if (connect.OpenConnection() == true)
            {

                query = "SELECT * FROM program_course WHERE ProgCourse_Code='" + cpcode + "'";
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
        private void cboProgCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCourseProgCode.Visible)
            {
                cboCourseProgCode.Text = cboProgCode.Text + "-" + cboCourseCode.Text;
            }
            else
            {
                txtCourseProgCode.Text = cboProgCode.Text + "-" + cboCourseCode.Text;
            }
        }

        private void frmProgramCourse_Load(object sender, EventArgs e)
        {
            cboCourseProgCode.Visible = false;
            cosProgCode = "";
            GetProgCourses();
            GetPrograms();
            GetCourses();
            groupBox56.Left = (this.ClientSize.Width - groupBox56.Width) / 2;
            groupBox56.Top = (this.ClientSize.Height - groupBox56.Height) / 2;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            cboCourseProgCode.Visible = true;
        }
        private void GetProgCourses()
        {
            Conn connect = new Conn();
            if (connect.OpenConnection() == true)
            {
                query = "SELECT * FROM program_course ORDER BY ProgCourse_Code ASC";
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                this.cboCourseProgCode.Items.Clear();
                while (dataReader.Read())
                {
                    if (dataReader["ProgCourse_Code"].ToString().Replace(" ", "") != "")
                    {
                        this.cboCourseProgCode.Items.Add(dataReader["ProgCourse_Code"].ToString());
                    }
                }
                connect.CloseConnection();



            }
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
        private void GetPrograms()
        {
            Conn connect = new Conn();
            if (connect.OpenConnection() == true)
            {
                query = "SELECT * FROM program ORDER BY Program_Code ASC";
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                this.cboProgCode.Items.Clear();
                while (dataReader.Read())
                {
                    if (dataReader["Program_Code"].ToString().Replace(" ", "") != "")
                    {
                        this.cboProgCode.Items.Add(dataReader["Program_Code"].ToString());
                    }
                }
                connect.CloseConnection();



            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            cboCourseProgCode.Visible = false;
            cosProgCode = "";
            clean();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cboCourseProgCode.Visible == false)
            {
                MessageBox.Show("Select Records to Delete", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboCourseProgCode.Visible = true;
                cboCourseProgCode.Focus();
            }
            else if (cboCourseProgCode.Text.Replace(" ", "") == "" && cboCourseProgCode.Visible == true)
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboCourseProgCode.Focus();
            }
            else if (cboCourseCode.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboCourseCode.Focus();
            }
            else if (cboSemester.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboSemester.Focus();
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
                        query = "DELETE FROM program_course WHERE ProgCourse_Code='" + cboCourseProgCode.Text + "'";
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
                    GetProgCourses();

                }
            }
        }

        private void cboCourseProgCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Conn connect = new Conn();
            if (connect.OpenConnection() == true)
            {

                query = "SELECT * FROM program_course WHERE ProgCourse_Code='" + cboCourseProgCode.Text.ToString() + "'";
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                if (dataReader.Read())
                {
                    cboCourseCode.Text = dataReader["Course_Code"].ToString();
                    cboSemester.Text = dataReader["Semester"].ToString();
                    cboProgCode.Text = dataReader["Program_Code"].ToString();
                    cboCourseProgCode.Text = dataReader["ProgCourse_Code"].ToString();
                    cboYoS.Text = dataReader["Year_of_Study"].ToString();
                    cosProgCode = cboCourseProgCode.Text;
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
                        query = "SELECT * FROM program_course ORDER BY ProgCourse_Code ASC";

                    }
                    else if (cboSearchCriteria.Text == "Course Code")
                    {
                        query = "SELECT * FROM program_course WHERE ProgCourse_Code LIKE '" + searchval + "' ORDER BY ProgCourse_Code ASC";

                    }
                    else if (cboSearchCriteria.Text == "Program Code")
                    {
                        query = "SELECT * FROM program_course WHERE ProgCourse_Code LIKE '" + searchval + "' ORDER BY ProgCourse_Code ASC";

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
                        if (dataReader["ProgCourse_Code"].ToString().Replace(" ", "") != "")
                        {
                            string[] row = new string[] { dataReader["ProgCourse_Code"].ToString(), dataReader["Course_Code"].ToString(), dataReader["Program_Code"].ToString(), dataReader["Semester"].ToString(), dataReader["Year_of_Study"].ToString() };
                            dataGridView1.Rows.Add(row);
                        }

                    }


                    connect.CloseConnection();
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cboCourseProgCode.Visible = true;
            cboCourseProgCode.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            cboCourseCode.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            cboProgCode.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
            cboSemester.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();
            cboYoS.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString();
            cosProgCode = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
        }

        private void cboCourseCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCourseProgCode.Visible)
            {
                cboCourseProgCode.Text = cboProgCode.Text + "-" + cboCourseCode.Text;
            }
            else
            {
                txtCourseProgCode.Text = cboProgCode.Text + "-" + cboCourseCode.Text;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
        }

        private void btnPostCourses_Click(object sender, EventArgs e)
        {
            string msg = "";
            Conn connect = new Conn();
            Conn connect1 = new Conn();
            Conn connect2 = new Conn();
            Conn connect3 = new Conn();
            Conn connect4 = new Conn();
            Conn connect5 = new Conn();
            string query1, query2, query3, query4, query5;
            connect.CloseConnection();
            if (connect.OpenConnection() == true)
            {
                query = "DELETE FROM courses_done";
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                //Execute command
                cmd.ExecuteNonQuery();
                //close connection
            }
            connect.CloseConnection();

            if (connect1.OpenConnection() == true)
            {

                query1 = "SELECT DISTINCT Program_Code FROM program_course ORDER BY Program_Code ASC";
                MySqlCommand cmd1 = new MySqlCommand(query1, connect1.connection);
                MySqlDataReader dataReader1 = cmd1.ExecuteReader();
                //Read the data and store them in the list
                while (dataReader1.Read())
                {
                    if (connect2.OpenConnection() == true)
                    {

                        query2 = "SELECT DISTINCT Year_of_Study FROM program_course WHERE Program_Code='" + dataReader1["Program_Code"].ToString() + "' ORDER BY Year_of_Study ASC";
                        MySqlCommand cmd2 = new MySqlCommand(query2, connect2.connection);
                        MySqlDataReader dataReader2 = cmd2.ExecuteReader();
                        while (dataReader2.Read())
                        {
                            if (connect3.OpenConnection() == true)
                            {

                                query3 = "SELECT DISTINCT Semester FROM program_course WHERE Year_of_Study='" + dataReader2["Year_of_Study"].ToString() + "' AND Program_Code='" + dataReader1["Program_Code"].ToString() + "' ORDER BY Course_Code ASC";
                                MySqlCommand cmd3 = new MySqlCommand(query3, connect3.connection);
                                MySqlDataReader dataReader3 = cmd3.ExecuteReader();
                                while (dataReader3.Read())
                                {
                                    if (connect4.OpenConnection() == true)
                                    {

                                        query4 = "SELECT * FROM program_course WHERE Semester='" + dataReader3["Semester"] + "' and  Year_of_Study='" + dataReader2["Year_of_Study"] + "' and Program_Code='" + dataReader1["Program_Code"].ToString() + "' ORDER BY Course_Code ASC";
                                        MySqlCommand cmd4 = new MySqlCommand(query4, connect4.connection);
                                        MySqlDataReader dataReader4 = cmd4.ExecuteReader();
                                        msg = "";
                                        while (dataReader4.Read())
                                        {
                                            msg = msg + " " + dataReader4["Course_Code"];

                                        }
                                        if (connect5.OpenConnection() == true)
                                        {
                                            query5 = "INSERT INTO courses_done(Program_Code,Academic_Year,Semester,Message) VALUES('" + dataReader4["Program_Code"].ToString() + "', '" + dataReader4["Year_of_Study"].ToString() + "', '" + dataReader4["Semester"].ToString() + "','" + msg + "')";

                                            MySqlCommand cmd5 = new MySqlCommand(query5, connect5.connection);

                                            //Execute command
                                            cmd5.ExecuteNonQuery();
                                        }
                                        connect5.CloseConnection();


                                    }
                                    connect4.CloseConnection();

                                }
                                //MessageBox.Show("Connection3");

                            }
                            connect3.CloseConnection();

                        }
                        //MessageBox.Show("Connection2");

                    }
                    connect2.CloseConnection();

                }
                //MessageBox.Show("Connection1");

            }
            connect1.CloseConnection();
            MessageBox.Show("Posting Complete!", "MMUST", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        query = "SELECT * FROM program_course ORDER BY ProgCourse_Code ASC";

                    }
                    else if (cboSearchCriteria.Text == "Course Code")
                    {
                        query = "SELECT * FROM program_course WHERE ProgCourse_Code LIKE '" + searchval + "' ORDER BY ProgCourse_Code ASC";

                    }
                    else if (cboSearchCriteria.Text == "Program Code")
                    {
                        query = "SELECT * FROM program_course WHERE ProgCourse_Code LIKE '" + searchval + "' ORDER BY ProgCourse_Code ASC";

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
                        if (dataReader["ProgCourse_Code"].ToString().Replace(" ", "") != "")
                        {
                            string[] row = new string[] { dataReader["ProgCourse_Code"].ToString(), dataReader["Course_Code"].ToString(), dataReader["Program_Code"].ToString(), dataReader["Semester"].ToString(), dataReader["Year_of_Study"].ToString() };
                            dataGridView1.Rows.Add(row);
                        }

                    }


                    connect.CloseConnection();
                    PrintDialog printDial = new PrintDialog();
                    printDial.Document = printDocument1;
                    printDial.UseEXDialog = true;
                    if (DialogResult.OK == printDial.ShowDialog())
                    {
                        printDocument1.DocumentName = "Program Course Details";
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

        

        

        
    }
}
