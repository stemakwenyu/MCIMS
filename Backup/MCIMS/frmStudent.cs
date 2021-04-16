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
    public partial class frmStudent : Form
    {
        private string studentCode;
        private string optn;
        private string query;
        public frmStudent()
        {
            InitializeComponent();
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            gboxSearch.Visible = false;
            cboRegNo.Visible = false;
            GetPrograms();
            GetStudent();
            studentCode = "";
            groupBox56.Left = (this.ClientSize.Width - groupBox56.Width) / 2;
            groupBox56.Top = (this.ClientSize.Height - groupBox56.Height) / 2;
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            gboxSearch.Visible = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cboSearchCriteria.Text = "All";
            txtSearchValue.Text = "All";
            cboSemesterSearch.Text = "";
            cboYoSSearch.Text = "";
            chkStatusSearch.CheckState = 0;
            cboSemesterSearch.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            gboxSearch.Visible = true;
        }
        private void GetStudent()
        {
            Conn connect = new Conn();
            if (connect.OpenConnection() == true)
            {
                query = "SELECT * FROM student ORDER BY Reg_No ASC";
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                this.cboRegNo.Items.Clear();
                while (dataReader.Read())
                {
                    if (dataReader["Reg_No"].ToString().Replace(" ", "") != "")
                    {
                        this.cboRegNo.Items.Add(dataReader["Reg_No"].ToString());
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
        private void btnReset_Click(object sender, EventArgs e)
        {
            clean();
        }
        private void clean()
        {
            
            txtStudentName.Text = "";
            cboProgCode.Text = "";
            cboSemester.Text = "";
            cboYoS.Text = "";
            txtPostalAddress.Text = "";
            txtPostalCode.Text = "";
            txtTown.Text = "";
            txtResidence.Text = "";
            txtEmail.Text = "";
            txtPhoneNo.Text = "";
            chkStatus.CheckState = CheckState.Checked;
            if (cboRegNo.Visible)
            {
                cboRegNo.Text = "";
                cboRegNo.Focus();
            }
            else
            {
                txtRegNo.Text = "";
                txtRegNo.Focus();
            }
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private bool IsCharacter(string str)
        {
            int x=0;
            bool res=false;
            for(x=0;x<=9;x++)
            {
                if(str.Contains(x.ToString()))
                {
                    res=true;
                }

            }
            return res;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            long phone;
            string phn=txtPhoneNo.Text.Replace("+","").Trim().ToString();
            string postalcode = txtPostalCode.Text.Trim().ToString();
            string stName = txtStudentName.Text.Trim().ToString();
            if (txtRegNo.Text.Replace(" ", "") == "" && cboRegNo.Visible ==false)
            {
                MessageBox.Show("Ensure all fields are filled!","MMUST CIMS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                txtRegNo.Focus();
            }
            else if (cboRegNo.Text.Replace(" ", "") == "" && cboRegNo.Visible == true)
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtRegNo.Focus();
            }
            else if (txtStudentName.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtStudentName.Focus();
            }
            else if (IsCharacter(txtStudentName.Text.ToString()))
            {
                MessageBox.Show("Invalid Name!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtStudentName.Focus();
            }
            else if (cboProgCode.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!","MMUST CIMS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                cboProgCode.Focus();
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
            else if (txtPostalAddress.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPostalAddress.Focus();
            }
            else if (txtPostalCode.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPostalCode.Focus();
            }
            else if (!long.TryParse(postalcode, out phone))
            {
                MessageBox.Show("Invalid Postal Code!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPostalCode.Focus();
            }
            else if (txtTown.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTown.Focus();
            }
            else if (txtResidence.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtResidence.Focus();
            }
            else if (txtEmail.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtEmail.Focus();
            }
            else if (!IsValidEmail(txtEmail.Text.Replace(" ", "").ToString()))
            {
                MessageBox.Show("Invalid Email", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtEmail.Focus();
            }
            else if (txtPhoneNo.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPhoneNo.Focus();
            }
            else if (txtPhoneNo.Text.Length!=13)
            {
                MessageBox.Show("Invalid Phone Number!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPhoneNo.Focus();
            }
            else if (!long.TryParse(phn, out phone))
            {
                MessageBox.Show("Invalid Phone Number!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPhoneNo.Focus();
            }
            else if (!txtPhoneNo.Text.Contains("+"))
            {
                MessageBox.Show("Invalid Phone Number!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPhoneNo.Focus();
            }                
            else
            {

                string msg = "";
                int op;
                int status;
                if (chkStatus.CheckState == CheckState.Checked)
                {
                    status = 1;
                }
                else
                {
                    status = 0;
                }
                if (studentCode == "")
                {
                    if (FindRecord(txtRegNo.Text.ToString()) == false)
                    {


                        query = "INSERT INTO student VALUES('" + txtRegNo.Text.ToString() + "', '" + txtStudentName.Text.ToString() + "','" + cboProgCode.Text + "', '" + cboSemester.Text.ToString() + "','" + cboYoS.Text.ToString() + "','" + txtPostalAddress.Text + "','" + txtPostalCode.Text + "','" + txtTown.Text + "','" + txtResidence.Text + "','" + txtEmail.Text + "','" + txtPhoneNo.Text + "'," + status + ")";
                        msg = "Records have been successfully saved";
                        op = 0;
                    }
                    else
                    {


                        query = "UPDATE student SET Reg_No='" + txtRegNo.Text + "',Student_Name='" + txtStudentName.Text.ToString() + "', Program_Code= '" + cboProgCode.Text.ToString() + "', Semester='" + cboSemester.Text.ToString() + "', Year_of_Study='" + cboYoS.Text.ToString() + "', Postal_Address='" + txtPostalAddress.Text + "',Postal_Code='" + txtPostalCode.Text + "',Town='" + txtTown.Text + "',Residence='" + txtResidence.Text + "',Email_Address='" + txtEmail.Text + "',Phone_No='" + txtPhoneNo.Text + "',Status=" + status + " WHERE Reg_No='" + txtRegNo.Text.ToString() + "'";
                        msg = "Records have been Successfully updated!";
                        op = 1;
                    }
                }
                else
                {
                    query = "UPDATE student SET Reg_No='" + cboRegNo.Text + "',Student_Name='" + txtStudentName.Text.ToString() + "', Program_Code= '" + cboProgCode.Text.ToString() + "', Semester='" + cboSemester.Text.ToString() + "', Year_of_Study='" + cboYoS.Text.ToString() + "', Postal_Address='" + txtPostalAddress.Text + "',Postal_Code='" + txtPostalCode.Text + "',Town='" + txtTown.Text + "',Residence='" + txtResidence.Text + "',Email_Address='" + txtEmail.Text + "',Phone_No='" + txtPhoneNo.Text + "',Status=" + status + " WHERE Reg_No='" + studentCode + "'";
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
                        MySqlCommand cmdd = new MySqlCommand(query, connect.connection);

                        //Execute command
                        cmdd.ExecuteNonQuery();

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
                    GetStudent();



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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cboRegNo.Visible == false)
            {
                MessageBox.Show("Select Records to Delete", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboRegNo.Visible = true;
                cboRegNo.Focus();
            }
            else if (cboRegNo.Text.Replace(" ", "") == "" && cboRegNo.Visible == true)
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtRegNo.Focus();
            }
            else if (txtStudentName.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtStudentName.Focus();
            }
            else if (cboProgCode.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!","MMUST CIMS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                cboProgCode.Focus();
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
            else if (txtPostalAddress.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPostalAddress.Focus();
            }
            else if (txtPostalCode.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPostalCode.Focus();
            }
            else if (txtTown.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTown.Focus();
            }
            else if (txtResidence.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtResidence.Focus();
            }
            else if (txtEmail.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtEmail.Focus();
            }
            else if (txtPhoneNo.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPhoneNo.Focus();
            }
            else if (txtPhoneNo.Text.Length.ToString() != "13" || (txtPhoneNo.Text.Replace("+","")).ToString()=="")
            {
                MessageBox.Show("Invalid Phone Number!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPhoneNo.Focus();
            }
            else
            {
                Conn connect = new Conn();
                connect.CloseConnection();
                if (connect.OpenConnection() == true)
                {
                    if (MessageBox.Show("Are you sure you want to delete these details?", "MMUST CIMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        query = "DELETE FROM student WHERE Reg_No='" + cboRegNo.Text + "'";
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
                    GetStudent();

                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            cboRegNo.Visible = true;
            studentCode = "";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cboRegNo.Visible = false;
            studentCode = "";
            clean();
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
            else if (cboYoSSearch.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboYoSSearch.Focus();
            }
            else
            {
                Conn connect = new Conn();
                int sts;
                if (chkStatusSearch.CheckState == CheckState.Checked)
                {
                    sts = 1;
                }
                else
                {
                    sts = 0;
                }
                if (connect.OpenConnection() == true)
                {
                    string searchval = "%" + txtSearchValue.Text + "%";
                    if (cboSearchCriteria.Text == "All")
                    {
                        query = "SELECT * FROM student WHERE Semester='"+cboSemesterSearch.Text +"' AND Year_of_Study='"+ cboYoSSearch.Text +"' AND Status="+ sts +" ORDER BY Reg_No ASC";

                    }
                    else if (cboSearchCriteria.Text == "Reg No")
                    {
                        query = "SELECT * FROM student WHERE Reg_No LIKE '" + searchval + "' AND Semester='" + cboSemesterSearch.Text + "' AND Year_of_Study='" + cboYoSSearch.Text + "' AND Status=" + sts + " ORDER BY Reg_No ASC";

                    }
                    else if (cboSearchCriteria.Text == "Name")
                    {
                        query = "SELECT * FROM student WHERE Student_Name LIKE '" + searchval + "' AND Semester='" + cboSemesterSearch.Text + "' AND Year_of_Study='" + cboYoSSearch.Text + "' AND Status=" + sts + " ORDER BY Reg_No ASC";

                    }
                    else if (cboSearchCriteria.Text == "Program")
                    {
                        query = "SELECT * FROM student WHERE Program_Code LIKE '" + searchval + "' AND Semester='" + cboSemesterSearch.Text + "' AND Year_of_Study='" + cboYoSSearch.Text + "' AND Status=" + sts + " ORDER BY Reg_No ASC";

                    }
                    else if (cboSearchCriteria.Text == "Phone No")
                    {
                        query = "SELECT * FROM student WHERE Phone_No LIKE '" + searchval + "' AND Semester='" + cboSemesterSearch.Text + "' AND Year_of_Study='" + cboYoSSearch.Text + "' AND Status=" + sts + " ORDER BY Reg_No ASC";

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
                        if (dataReader["Reg_No"].ToString().Replace(" ", "") != "")
                        {
                            string[] row = new string[] { dataReader["Reg_No"].ToString(), dataReader["Student_Name"].ToString(), dataReader["Program_Code"].ToString(), dataReader["Semester"].ToString(), dataReader["Year_of_Study"].ToString(), dataReader["Phone_No"].ToString()};
                            dataGridView1.Rows.Add(row);
                        }

                    }


                    connect.CloseConnection();
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cboRegNo.Visible = true;
            cboRegNo.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();

            studentCode = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            gboxSearch.Visible = false;
        }
        private bool FindRecord(string scode)
        {
            Conn connect = new Conn();
            if (connect.OpenConnection() == true)
            {

                query = "SELECT * FROM student WHERE Reg_No='" + scode + "'";
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
        }

        private void cboRegNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Conn connect = new Conn();
            if (connect.OpenConnection() == true)
            {

                query = "SELECT * FROM student WHERE Reg_No='" + cboRegNo.Text.ToString() + "'";
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                if (dataReader.Read())
                {
                    txtStudentName.Text = dataReader["Student_Name"].ToString();
                    cboProgCode.Text = dataReader["Program_Code"].ToString();
                    cboSemester.Text = dataReader["Semester"].ToString();
                    cboYoS.Text = dataReader["Year_of_Study"].ToString();
                    txtPostalAddress.Text = dataReader["Postal_Address"].ToString();
                    txtPostalCode.Text = dataReader["Postal_Code"].ToString();
                    txtTown.Text = dataReader["Town"].ToString();
                    txtResidence.Text = dataReader["Residence"].ToString();
                    txtEmail.Text = dataReader["Email_Address"].ToString();
                    txtPhoneNo.Text = dataReader["Phone_No"].ToString();
                    if (dataReader["Status"].ToString() == "1")
                    {
                        chkStatus.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        chkStatus.CheckState = CheckState.Unchecked;
                    }
                    studentCode = cboRegNo.Text;
                }
                connect.CloseConnection();
            }
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
            else if (cboYoSSearch.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboYoSSearch.Focus();
            }
            else
            {
                Conn connect = new Conn();
                int sts;
                if (chkStatusSearch.CheckState == CheckState.Checked)
                {
                    sts = 1;
                }
                else
                {
                    sts = 0;
                }
                if (connect.OpenConnection() == true)
                {
                    string searchval = "%" + txtSearchValue.Text + "%";
                    if (cboSearchCriteria.Text == "All")
                    {
                        query = "SELECT * FROM student WHERE Semester='" + cboSemesterSearch.Text + "' AND Year_of_Study='" + cboYoSSearch.Text + "' AND Status=" + sts + " ORDER BY Reg_No ASC";

                    }
                    else if (cboSearchCriteria.Text == "Reg No")
                    {
                        query = "SELECT * FROM student WHERE Reg_No LIKE '" + searchval + "' AND Semester='" + cboSemesterSearch.Text + "' AND Year_of_Study='" + cboYoSSearch.Text + "' AND Status=" + sts + " ORDER BY Reg_No ASC";

                    }
                    else if (cboSearchCriteria.Text == "Name")
                    {
                        query = "SELECT * FROM student WHERE Student_Name LIKE '" + searchval + "' AND Semester='" + cboSemesterSearch.Text + "' AND Year_of_Study='" + cboYoSSearch.Text + "' AND Status=" + sts + " ORDER BY Reg_No ASC";

                    }
                    else if (cboSearchCriteria.Text == "Program")
                    {
                        query = "SELECT * FROM student WHERE Program_Code LIKE '" + searchval + "' AND Semester='" + cboSemesterSearch.Text + "' AND Year_of_Study='" + cboYoSSearch.Text + "' AND Status=" + sts + " ORDER BY Reg_No ASC";

                    }
                    else if (cboSearchCriteria.Text == "Phone No")
                    {
                        query = "SELECT * FROM student WHERE Phone_No LIKE '" + searchval + "' AND Semester='" + cboSemesterSearch.Text + "' AND Year_of_Study='" + cboYoSSearch.Text + "' AND Status=" + sts + " ORDER BY Reg_No ASC";

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
                        if (dataReader["Reg_No"].ToString().Replace(" ", "") != "")
                        {
                            string[] row = new string[] { dataReader["Reg_No"].ToString(), dataReader["Student_Name"].ToString(), dataReader["Program_Code"].ToString(), dataReader["Semester"].ToString(), dataReader["Year_of_Study"].ToString(), dataReader["Phone_No"].ToString() };
                            dataGridView1.Rows.Add(row);
                        }

                    }


                    connect.CloseConnection();
                    PrintDialog printDial = new PrintDialog();
                    printDial.Document = printDocument1;
                    printDial.UseEXDialog = true;
                    if (DialogResult.OK == printDial.ShowDialog())
                    {
                        printDocument1.DocumentName = "Student Details";
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

            this.dataGridView1.Height = 202;
            this.dataGridView1.Width = 689;
            this.dataGridView1.ScrollBars = ScrollBars.Both;
            dataGridView1.BorderStyle = BorderStyle.FixedSingle;
            dataGridView1.BackgroundColor = Color.Gray;
        }

        private void chkStatus_CheckedChanged(object sender, EventArgs e)
        {
            
            //string phn = txtPhoneNo.Text.Replace("+","").Trim().ToString();

            //MessageBox.Show(int.TryParse((txtPhoneNo.Text).Replace("+","").Trim(),out phone).ToString(), "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //MessageBox.Show(long.TryParse(phn,out phone).ToString() + " "+phn, "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString().ToString();
            lblTime2.Text = DateTime.Now.ToLongTimeString().ToString();
        }

       
    }
}
