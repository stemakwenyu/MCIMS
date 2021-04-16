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
    public partial class frmLoading : Form
    {
        private string lodCode;
        private string optn;
        private string query;
        public frmLoading()
        {
            InitializeComponent();
        }

        private void frmLoading_Load(object sender, EventArgs e)
        {
            gboxSearch.Visible = false;
            cboLoadingCode.Visible = false;
            lodCode = "";
            GetLoadings();
            GetCourses();
            GetStaffs();
            groupBox56.Left = (this.ClientSize.Width - groupBox56.Width) / 2;
            groupBox56.Top = (this.ClientSize.Height - groupBox56.Height) / 2;
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            gboxSearch.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            gboxSearch.Visible = true;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cboSemesterSearch.Text = "";
            cboAcYrSearch.Text = "";
            cboSearchCriteria.Text = "All";
            txtSearchValue.Text = "All";
            cboSemester.Focus();
        }

        private void cboStaffName_SelectedIndexChanged(object sender, EventArgs e)
        {

            lblStaffNo.Text = GetStaffNo(cboStaffName.Text);
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clean();
        }
        private void clean()
        {
            cboSemester.Text = "";
            cboCourse.Text = "";
            txtVenue.Text = "";
            txtTime.Text = "";
            cboAcYr.Text = "";
            lblStaffNo.Text = "";
            cboStaffName.Text = "";
            if (cboLoadingCode.Visible)
            {
                cboLoadingCode.Text = "";
                cboLoadingCode.Focus();
            }
            else
            {
                txtLoadingCode.Text = "";
                txtLoadingCode.Focus();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtLoadingCode.Text.Replace(" ", "") == "" && cboLoadingCode.Visible==false)
            {
                MessageBox.Show("Ensure all fields are filled!","MMUST CIMS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                txtLoadingCode.Focus();
            }
            else if (cboLoadingCode.Text.Replace(" ", "") == "" && cboLoadingCode.Visible == true)
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtLoadingCode.Focus();
            }
            else if (cboCourse.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboCourse.Focus();
            }
            else if (txtVenue.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtVenue.Focus();
            }
            else if (txtTime.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTime.Focus();
            }
            else if (cboSemester.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboSemester.Focus();
            }
            else if (cboAcYr.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAcYr.Focus();
            }
            else if (cboStaffName.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboStaffName.Focus();
            }
            else
            {
                string msg = "";
                int op;
                if (lodCode == "")
                {
                    if (FindRecord(txtLoadingCode.Text.ToString()) == false)
                    {


                        query = "INSERT INTO loading VALUES('" + txtLoadingCode.Text.ToString() + "', '" + cboCourse.Text.ToString() + "','" + txtVenue.Text + "', '" + txtTime.Text.ToString() + "','" + cboSemester.Text.ToString() + "','" + cboAcYr.Text.ToString() + "','" + lblStaffNo.Text + "')";
                        msg = "Records have been successfully saved";
                        op = 0;
                    }
                    else
                    {


                        query = "UPDATE loading SET Loading_Code='" + txtLoadingCode.Text + "',ProgCourse_Code='" + cboCourse.Text.ToString() + "', Venue= '" + txtVenue.Text.ToString() + "', Lecture_Time='" + txtTime.Text.ToString() + "', Semester='" + cboSemester.Text.ToString() + "', Academic_Year='" + cboAcYr.Text + "',Staff_No='" + lblStaffNo.Text + "' WHERE Loading_Code='" + txtLoadingCode.Text.ToString() + "'";
                        msg = "Records have been Successfully updated!";
                        op = 1;
                    }
                }
                else
                {
                    query = "UPDATE loading SET Loading_Code='" + cboLoadingCode.Text + "',ProgCourse_Code='" + cboCourse.Text.ToString() + "', Venue= '" + txtVenue.Text.ToString() + "', Lecture_Time='" + txtTime.Text.ToString() + "',Semester='" + cboSemester.Text.ToString() + "',Academic_Year='" + cboAcYr.Text + "',Staff_No='" + lblStaffNo.Text + "' WHERE Loading_Code='" + lodCode + "'";
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
                    GetLoadings();


                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cboLoadingCode.Visible == false)
            {
                MessageBox.Show("Select Records to Delete", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboLoadingCode.Visible = true;
                cboLoadingCode.Focus();
            }
            else if (cboLoadingCode.Text.Replace(" ", "") == "" && cboLoadingCode.Visible == true)
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtLoadingCode.Focus();
            }
            else if (cboCourse.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboCourse.Focus();
            }
            else if (txtVenue.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtVenue.Focus();
            }
            else if (txtTime.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTime.Focus();
            }
            else if (cboSemester.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboSemester.Focus();
            }
            else if (cboAcYr.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAcYr.Focus();
            }
            else if (cboStaffName.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboStaffName.Focus();
            }
            else
            {
                Conn connect = new Conn();
                connect.CloseConnection();
                if (connect.OpenConnection() == true)
                {
                    if (MessageBox.Show("Are you sure you want to delete these details?", "MMUST CIMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        query = "DELETE FROM loading WHERE Loading_Code='" + cboLoadingCode.Text + "'";
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
                    GetLoadings();

                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cboLoadingCode.Visible = false;
            lodCode = "";
            clean();
        }
        private void GetLoadings()
        {
            Conn connect = new Conn();
            if (connect.OpenConnection() == true)
            {
                query = "SELECT * FROM loading ORDER BY Loading_Code ASC";
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                this.cboLoadingCode.Items.Clear();
                while (dataReader.Read())
                {
                    if (dataReader["Loading_Code"].ToString().Replace(" ", "") != "")
                    {
                        this.cboLoadingCode.Items.Add(dataReader["Loading_Code"].ToString());
                    }
                }
                connect.CloseConnection();



            }
        }
        private void GetStaffs()
        {
            Conn connect = new Conn();
            if (connect.OpenConnection() == true)
            {
                query = "SELECT * FROM staff WHERE Priviledges='Staff' ORDER BY Staff_Name ASC";
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                this.cboStaffName.Items.Clear();
                while (dataReader.Read())
                {
                    if (dataReader["Staff_Name"].ToString().Replace(" ", "") != "")
                    {
                        this.cboStaffName.Items.Add(dataReader["Staff_Name"].ToString());
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
                query = "SELECT * FROM program_course ORDER BY ProgCourse_Code ASC";
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                this.cboCourse.Items.Clear();
                while (dataReader.Read())
                {
                    if (dataReader["ProgCourse_Code"].ToString().Replace(" ", "") != "")
                    {
                        this.cboCourse.Items.Add(dataReader["ProgCourse_Code"].ToString());
                    }
                }
                connect.CloseConnection();



            }
        }
        private string GetStaff(string staffCode)
        {
            Conn connect = new Conn();
            if (connect.OpenConnection() == true)
            {
                query = "SELECT * FROM staff WHERE Staff_No='" + staffCode + "' ORDER BY Staff_No ASC";
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                
                if (dataReader.Read())
                {


                    return (dataReader["Staff_Name"].ToString());
                    //connect.CloseConnection();

                }
                else
                {
                    return "----";
                    //connect.CloseConnection();
                }
                



            }
            else
            {
                return "----";
            }
        }
        private string GetStaffNo(string staffName)
        {
            Conn connect = new Conn();
            if (connect.OpenConnection() == true)
            {
                query = "SELECT * FROM staff WHERE Staff_Name='" + staffName + "' ORDER BY Staff_Name ASC";
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list

                if (dataReader.Read())
                {


                    return (dataReader["Staff_No"].ToString());
                    //connect.CloseConnection();

                }
                else
                {
                    return "----";
                    //connect.CloseConnection();
                }




            }
            else
            {
                return "----";
            }
        }
        private bool FindRecord(string ldcode)
        {
            Conn connect = new Conn();
            if (connect.OpenConnection() == true)
            {

                query = "SELECT * FROM loading WHERE Loading_Code='" + ldcode + "'";
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
            cboLoadingCode.Visible = true;
        }

        private void cboLoadingCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Conn connect = new Conn();
            if (connect.OpenConnection() == true)
            {

                query = "SELECT * FROM loading WHERE Loading_Code='" + cboLoadingCode.Text.ToString() + "'";
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                if (dataReader.Read())
                {
                    cboLoadingCode.Text = dataReader["Loading_Code"].ToString();
                    cboCourse.Text = dataReader["ProgCourse_Code"].ToString();
                    cboSemester.Text = dataReader["Semester"].ToString();
                    txtVenue.Text = dataReader["Venue"].ToString();
                    txtTime.Text = dataReader["Lecture_Time"].ToString();
                    cboAcYr.Text = dataReader["Academic_Year"].ToString();
                    cboStaffName.Text = GetStaff(dataReader["Staff_No"].ToString());
                    lblStaffNo.Text = dataReader["Staff_No"].ToString();
                    lodCode = cboLoadingCode.Text;
                }
                connect.CloseConnection();
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
            else if (cboSemesterSearch.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboSemesterSearch.Focus();
            }
            else if (cboAcYrSearch.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAcYrSearch.Focus();
            }
            else
            {
                Conn connect = new Conn();
                if (connect.OpenConnection() == true)
                {
                    string searchval = "%" + txtSearchValue.Text + "%";
                    if (cboSearchCriteria.Text == "All")
                    {
                        query = "SELECT * FROM loading WHERE Semester='"+ cboSemesterSearch.Text +"' and Academic_Year='"+ cboAcYrSearch.Text +"' ORDER BY Loading_Code ASC";

                    }
                    else if (cboSearchCriteria.Text == "Course Code")
                    {
                        query = "SELECT * FROM loading WHERE ProgCourse_Code LIKE '" + searchval + "' and Semester='" + cboSemesterSearch.Text + "' and Academic_Year='" + cboAcYrSearch.Text + "' ORDER BY Loading_Code ASC";

                    }
                    else if (cboSearchCriteria.Text == "Program Code")
                    {
                        query = "SELECT * FROM loading WHERE ProgCourse_Code LIKE '" + searchval + "' and Semester='" + cboSemesterSearch.Text + "' and Academic_Year='" + cboAcYrSearch.Text + "' ORDER BY Loading_Code ASC";

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
                        if (dataReader["Loading_Code"].ToString().Replace(" ", "") != "")
                        {
                            string[] row = new string[] { dataReader["Loading_Code"].ToString(), dataReader["ProgCourse_Code"].ToString(), dataReader["Venue"].ToString(), dataReader["Lecture_Time"].ToString(), dataReader["Semester"].ToString(), dataReader["Academic_Year"].ToString(), dataReader["Staff_No"].ToString(), GetStaff(dataReader["Staff_No"].ToString()) };
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
            cboLoadingCode.Visible = true;
            cboLoadingCode.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            cboCourse.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            txtVenue.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
            txtTime.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();
            cboSemester.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString();
            cboAcYr.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[5].Value.ToString();
            lblStaffNo.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[6].Value.ToString();
            cboStaffName.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[7].Value.ToString();
            gboxSearch.Visible = false;
            lodCode = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
        }

        private void cboCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoadingCode.Visible == false)
            {
                txtLoadingCode.Text = cboCourse.Text + "-" + cboAcYr.Text + "-" + cboSemester.Text;
            }
            else
            {
                cboLoadingCode.Text = cboCourse.Text + "-" + cboAcYr.Text + "-" + cboSemester.Text;
            }
        }

        private void cboSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoadingCode.Visible == false)
            {
                txtLoadingCode.Text = cboCourse.Text + "-" + cboAcYr.Text + "-" + cboSemester.Text;
            }
            else
            {
                cboLoadingCode.Text = cboCourse.Text + "-" + cboAcYr.Text + "-" + cboSemester.Text;
            }
        }

        private void cboAcYr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoadingCode.Visible == false)
            {
                txtLoadingCode.Text = cboCourse.Text + "-" + cboAcYr.Text + "-" + cboSemester.Text;
            }
            else
            {
                cboLoadingCode.Text = cboCourse.Text + "-" + cboAcYr.Text + "-" + cboSemester.Text;
            }
        }

        private void btnPostLoading_Click(object sender, EventArgs e)
        {
            string msg = "";
            Conn connect = new Conn();
            Conn connect1 = new Conn();
            Conn connect2 = new Conn();
            Conn connect3 = new Conn();
            Conn connect4 = new Conn();
            Conn connect5 = new Conn();
            string query1, query2, query3, query4,query5;
                connect.CloseConnection();
                if (connect.OpenConnection() == true)
                {
                        query = "DELETE FROM lecturer_enquiry";
                        //create command and assign the query and connection from the constructor
                        MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                        //Execute command
                        cmd.ExecuteNonQuery();
                        //close connection
                 }
                  connect.CloseConnection();

            if (connect1.OpenConnection() == true)
            {

                query1 = "SELECT DISTINCT Staff_No FROM loading ORDER BY Staff_No ASC";
                MySqlCommand cmd1 = new MySqlCommand(query1, connect1.connection);
                MySqlDataReader dataReader1 = cmd1.ExecuteReader();
                //Read the data and store them in the list
                while(dataReader1.Read())
                {
                    if (connect2.OpenConnection() == true)
                    {

                        query2 = "SELECT DISTINCT Academic_Year FROM loading WHERE Staff_No='" + dataReader1["Staff_No"].ToString() + "' ORDER BY Academic_Year ASC";
                        MySqlCommand cmd2 = new MySqlCommand(query2, connect2.connection);
                        MySqlDataReader dataReader2 = cmd2.ExecuteReader();
                        while (dataReader2.Read())
                        {
                            if (connect3.OpenConnection() == true)
                            {

                                query3 = "SELECT DISTINCT Semester FROM loading WHERE Academic_Year='" + dataReader2["Academic_Year"].ToString() + "' AND Staff_No='" + dataReader1["Staff_No"].ToString() + "' ORDER BY Semester ASC";
                                MySqlCommand cmd3 = new MySqlCommand(query3, connect3.connection);
                                MySqlDataReader dataReader3 = cmd3.ExecuteReader();
                                while (dataReader3.Read())
                                {
                                    if (connect4.OpenConnection() == true)
                                    {

                                        query4 = "SELECT * FROM loading WHERE Semester='" + dataReader3["Semester"] + "' and  Academic_Year='" + dataReader2["Academic_Year"] + "' and Staff_No='" + dataReader1["Staff_No"].ToString() + "' ORDER BY Semester ASC";
                                        MySqlCommand cmd4 = new MySqlCommand(query4, connect4.connection);
                                        MySqlDataReader dataReader4 = cmd4.ExecuteReader();
                                        msg="";
                                        while (dataReader4.Read())
                                        {
                                            msg = msg + " " + dataReader4["ProgCourse_Code"];

                                        }
                                        if (connect5.OpenConnection() == true)
                                        {
                                            query5 = "INSERT INTO lecturer_enquiry(Academic_Year,Semester,Staff_No,Message) VALUES('" + dataReader4["Academic_Year"] + "', '" + dataReader4["Semester"] + "', '" + dataReader4["Staff_No"] + "','" + msg + "')";

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
            else if (cboSemesterSearch.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboSemesterSearch.Focus();
            }
            else if (cboAcYrSearch.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAcYrSearch.Focus();
            }
            else
            {
                Conn connect = new Conn();
                if (connect.OpenConnection() == true)
                {
                    string searchval = "%" + txtSearchValue.Text + "%";
                    if (cboSearchCriteria.Text == "All")
                    {
                        query = "SELECT * FROM loading WHERE Semester='"+ cboSemesterSearch.Text +"' and Academic_Year='"+ cboAcYrSearch.Text +"' ORDER BY Loading_Code ASC";

                    }
                    else if (cboSearchCriteria.Text == "Course Code")
                    {
                        query = "SELECT * FROM loading WHERE ProgCourse_Code LIKE '" + searchval + "' and Semester='" + cboSemesterSearch.Text + "' and Academic_Year='" + cboAcYrSearch.Text + "' ORDER BY Loading_Code ASC";

                    }
                    else if (cboSearchCriteria.Text == "Program Code")
                    {
                        query = "SELECT * FROM loading WHERE ProgCourse_Code LIKE '" + searchval + "' and Semester='" + cboSemesterSearch.Text + "' and Academic_Year='" + cboAcYrSearch.Text + "' ORDER BY Loading_Code ASC";

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
                        if (dataReader["Loading_Code"].ToString().Replace(" ", "") != "")
                        {
                            string[] row = new string[] { dataReader["Loading_Code"].ToString(), dataReader["ProgCourse_Code"].ToString(), dataReader["Venue"].ToString(), dataReader["Lecture_Time"].ToString(), dataReader["Semester"].ToString(), dataReader["Academic_Year"].ToString(), dataReader["Staff_No"].ToString(), GetStaff(dataReader["Staff_No"].ToString()) };
                            dataGridView1.Rows.Add(row);
                        }

                    }


                    connect.CloseConnection();
                    PrintDialog printDial = new PrintDialog();
                    printDial.Document = printDocument1;
                    printDial.UseEXDialog = true;
                    if (DialogResult.OK == printDial.ShowDialog())
                    {
                        printDocument1.DocumentName = "Loading Details";
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

            this.dataGridView1.Height = 229;
            this.dataGridView1.Width = 689;
            this.dataGridView1.ScrollBars = ScrollBars.Both;
            dataGridView1.BorderStyle = BorderStyle.FixedSingle;
            dataGridView1.BackgroundColor = Color.Gray;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString().ToString();
            lblTime2.Text = DateTime.Now.ToLongTimeString().ToString();
        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        
    }
}
