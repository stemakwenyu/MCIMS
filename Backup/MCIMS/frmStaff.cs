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
    public partial class frmStaff : Form
    {
        private string staffCode;
        private string optn;
        private string query;
        public frmStaff()
        {
            InitializeComponent();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            gboxSearch.Visible = false;
        }

        private void frmStaff_Load(object sender, EventArgs e)
        {
            groupBox56.Left = (this.ClientSize.Width - groupBox56.Width) / 2;
            groupBox56.Top = (this.ClientSize.Height - groupBox56.Height) / 2;
            if (Sessions.prev == "Administrator")
            {
                gboxSearch.Visible = false;
                cboStaffNo.Visible = false;
                GetStaff();
                GetDepartment();
                staffCode = "";
                AssignStaffNo();
            }
            else if (Sessions.prev == "Clerk" || Sessions.prev == "Staff")
            {
                gboxSearch.Visible = false;
                cboStaffNo.Visible = false;
                GetStaff();
                GetDepartment();
                staffCode = "";
                AssignStaffNo();
                cboPriviledges.Enabled = false;
                chkStatus.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                MessageBox.Show("You are not Allowed to Access this Service!\nPlease Contact System Administrator.", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Dispose();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            gboxSearch.Visible = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cboSearchCriteria.Text = "All";
            txtSearchValue.Text = "All";
            cboSearchCriteria.Focus();
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
            txtPfNo.Text = "";
            txtStaffName.Text = "";
            txtDesignation.Text = "";
            cboDepCode.Text = "";
            txtStaffID.Text = "";
            txtPostalAddress.Text = "";
            txtPostalCode.Text = "";
            txtTown.Text = "";
            txtResidence.Text = "";
            txtEmail.Text = "";
            txtPhoneNo.Text = "";
            txtOffice.Text = "";
            txtTimeAvailable.Text = "";
            txtLoginName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            cboPriviledges.Text = "Staff";
            chkStatus.CheckState = 0;
            if (cboStaffNo.Visible)
            {
                cboStaffNo.Text = "";
                cboStaffNo.Focus();
            }
            else
            {
                txtStaffNo.Text = "";
                txtStaffNo.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((cboStaffNo.Visible == true && Sessions.userID == cboStaffNo.Text && (Sessions.prev == "Staff" || Sessions.prev == "Clerk")) || Sessions.prev == "Administrator")
            {
                long phone;
                string phn = txtPhoneNo.Text.Replace("+", "").Trim().ToString();
                string postalcode = txtPostalCode.Text.Trim().ToString();
                string stName = txtStaffName.Text.Trim().ToString();

                if (txtStaffNo.Text.Replace(" ", "") == "" && cboStaffNo.Visible == false)
                {
                    MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtStaffNo.Focus();
                }
                else if (cboStaffNo.Text.Replace(" ", "") == "" && cboStaffNo.Visible == true)
                {
                    MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboStaffNo.Focus();
                }
                else if (txtPfNo.Text.Replace(" ", "") == "")
                {
                    MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPfNo.Focus();
                }
                else if (txtStaffName.Text.Replace(" ", "") == "")
                {
                    MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtStaffName.Focus();
                }
                else if (IsCharacter(txtStaffName.Text.ToString()))
                {
                    MessageBox.Show("Invalid Name!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtStaffName.Focus();
                }
                else if (txtDesignation.Text.Replace(" ", "") == "")
                {
                    MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDesignation.Focus();
                }
                else if (cboDepCode.Text.Replace(" ", "") == "")
                {
                    MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboDepCode.Focus();
                }
                else if (txtStaffID.Text.Replace(" ", "") == "")
                {
                    MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtStaffID.Focus();
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
                else if (txtPhoneNo.Text.Length != 13)
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
                else if (txtOffice.Text.Replace(" ", "") == "")
                {
                    MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtOffice.Focus();
                }
                else if (txtTimeAvailable.Text.Replace(" ", "") == "")
                {
                    MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtTimeAvailable.Focus();
                }
                else if (txtLoginName.Text.Replace(" ", "") == "")
                {
                    MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtLoginName.Focus();
                }
                else if (txtPassword.Text == "")
                {
                    MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPassword.Focus();
                }
                else if (txtPassword.Text.Length < 5)
                {
                    MessageBox.Show("Weak Password, Put 5 or more characters", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPassword.Focus();
                }
                else if (txtConfirmPassword.Text == "")
                {
                    MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtConfirmPassword.Focus();
                }
                else if (txtPassword.Text.Replace(" ", "") != txtConfirmPassword.Text.Replace(" ", ""))
                {
                    MessageBox.Show("Password Mismatch!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPassword.Text = "";
                    txtConfirmPassword.Text = "";
                    txtPassword.Focus();
                }
                else if (cboPriviledges.Text.Replace(" ", "") == "")
                {
                    MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboPriviledges.Focus();
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
                    if (staffCode == "")
                    {
                        if (FindRecord(txtStaffNo.Text.ToString()) == false)
                        {


                            query = "INSERT INTO staff(Staff_No,Pf_No,Staff_Name,Designation,Department_Code,Staff_ID,Postal_Address,Postal_Code,Town,Residence,Email_Address,Phone_No,Office,Time_Available,Login_Name,Passsword,Priviledges,Status) VALUES('" + txtStaffNo.Text.ToString() + "', '" + txtPfNo.Text.ToString() + "','" + txtStaffName.Text + "', '" + txtDesignation.Text.ToString() + "','" + cboDepCode.Text.ToString() + "','" + txtStaffID.Text.ToString() + "','" + txtPostalAddress.Text + "','" + txtPostalCode.Text + "','" + txtTown.Text + "','" + txtResidence.Text + "','" + txtEmail.Text + "','" + txtPhoneNo.Text + "','" + txtOffice.Text + "','" + txtTimeAvailable.Text + "','" + txtLoginName.Text + "','" + txtPassword.Text + "','" + cboPriviledges.Text + "'," + status + ")";
                            msg = "Records have been successfully saved";
                            op = 0;
                        }
                        else
                        {


                            query = "UPDATE staff SET Staff_No='" + txtStaffNo.Text + "',Pf_No='" + txtPfNo.Text.ToString() + "', Staff_Name= '" + txtStaffName.Text.ToString() + "', Designation='" + txtDesignation.Text.ToString() + "', Department_Code='" + cboDepCode.Text.ToString() + "', Staff_ID='" + txtStaffID.Text + "',Postal_Address='" + txtPostalAddress.Text + "',Postal_Code='" + txtPostalCode.Text + "',Town='" + txtTown.Text + "',Residence='" + txtResidence.Text + "',Email_Address='" + txtEmail.Text + "',Phone_No='" + txtPhoneNo.Text + "',Office='" + txtOffice.Text + "',Time_Available='" + txtTimeAvailable.Text + "',Login_Name='" + txtLoginName.Text + "',Passsword='" + txtPassword.Text + "',Priviledges='" + cboPriviledges.Text + "',Status=" + status + " WHERE Staff_No='" + txtStaffNo.Text.ToString() + "'";
                            msg = "Records have been Successfully updated!";
                            op = 1;
                        }
                    }
                    else
                    {
                        query = "UPDATE staff SET Staff_No='" + cboStaffNo.Text + "',Pf_No='" + txtPfNo.Text.ToString() + "', Staff_Name= '" + txtStaffName.Text.ToString() + "', Designation='" + txtDesignation.Text.ToString() + "', Department_Code='" + cboDepCode.Text.ToString() + "', Staff_ID='" + txtStaffID.Text + "',Postal_Address='" + txtPostalAddress.Text + "',Postal_Code='" + txtPostalCode.Text + "',Town='" + txtTown.Text + "',Residence='" + txtResidence.Text + "',Email_Address='" + txtEmail.Text + "',Phone_No='" + txtPhoneNo.Text + "',Office='" + txtOffice.Text + "',Time_Available='" + txtTimeAvailable.Text + "',Login_Name='" + txtLoginName.Text + "',Passsword='" + txtPassword.Text + "',Priviledges='" + cboPriviledges.Text + "',Status=" + status + " WHERE Staff_No='" + staffCode + "'";
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
                        GetStaff();
                        AssignStaffNo();


                    }
                }
            }
            else
            {
                MessageBox.Show("You are not allowed to access this service!\nPlease Contact System Administrator", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private bool FindRecord(string scode)
        {
            Conn connect = new Conn();
            if (connect.OpenConnection() == true)
            {

                query = "SELECT * FROM staff WHERE Staff_No='" + scode + "'";
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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cboStaffNo.Visible == false)
            {
                MessageBox.Show("Select Records to Delete", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboStaffNo.Visible = true;
                cboStaffNo.Focus();
            }
            else if (cboStaffNo.Text.Replace(" ", "") == "" && cboStaffNo.Visible == true)
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboStaffNo.Focus();
            }
            else if (txtPfNo.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPfNo.Focus();
            }
            else if (txtStaffName.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtStaffName.Focus();
            }
            else if (txtDesignation.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDesignation.Focus();
            }
            else if (cboDepCode.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboDepCode.Focus();
            }
            else if (txtStaffID.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtStaffID.Focus();
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
            else if (txtOffice.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtOffice.Focus();
            }
            else if (txtTimeAvailable.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTimeAvailable.Focus();
            }
            else if (txtLoginName.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtLoginName.Focus();
            }
            else if (txtPassword.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPassword.Focus();
            }
            else if (cboPriviledges.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboPriviledges.Focus();
            }
            else
            {
                Conn connect = new Conn();
                connect.CloseConnection();
                if (connect.OpenConnection() == true)
                {
                    if (MessageBox.Show("Are you sure you want to delete these details?", "MMUST CIMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        query = "DELETE FROM staff WHERE Staff_No='" + cboStaffNo.Text + "'";
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
                    GetStaff();

                }

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            cboStaffNo.Visible = true;
            //AssignStaffNo();
        }
        private void GetStaff()
        {
            Conn connect = new Conn();
            if (connect.OpenConnection() == true)
            {
                query = "SELECT * FROM staff ORDER BY Staff_No ASC";
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                this.cboStaffNo.Items.Clear();
                while (dataReader.Read())
                {
                    if (dataReader["Staff_No"].ToString().Replace(" ", "") != "")
                    {
                        this.cboStaffNo.Items.Add(dataReader["Staff_No"].ToString());
                    }
                }
                connect.CloseConnection();



            }
        }
        private void AssignStaffNo()
        {
            Conn connect = new Conn();
            if (connect.OpenConnection() == true)
            {
                query = "SELECT * FROM staff ORDER BY Staff_No DESC";
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                //this.cboStaffNo.Items.Clear();
                int stffNo;
                if (dataReader.Read())
                {
                    if (dataReader["Staff_No"].ToString().Replace(" ", "") != "")
                    {

                        stffNo = Convert.ToInt32((dataReader["Staff_No"].ToString().Substring(4)));
                        if (stffNo < 9)
                        {
                            txtStaffNo.Text = "EMP/000" + (stffNo + 1);
                        }
                        else if (stffNo >= 9 && stffNo < 99)
                        {
                            txtStaffNo.Text = "EMP/00" + (stffNo + 1);
                        }
                        else if (stffNo >= 99 && stffNo < 999)
                        {
                            txtStaffNo.Text = "EMP/0" + (stffNo + 1);
                        }
                        else
                        {
                            txtStaffNo.Text = "EMP/" + (stffNo + 1);
                        }

                        //MessageBox.Show(txtStaffNo.Text);
                    }
                }
                connect.CloseConnection();



            }
        }
        private void GetDepartment()
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            cboStaffNo.Visible = false;
            staffCode = "";
            clean();
            AssignStaffNo();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
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
                        query = "SELECT * FROM staff ORDER BY Staff_No ASC";

                    }
                    else if (cboSearchCriteria.Text == "PF No")
                    {
                        query = "SELECT * FROM staff WHERE Staff_No LIKE '" + searchval + "' ORDER BY Staff_No ASC";

                    }
                    else if (cboSearchCriteria.Text == "Name")
                    {
                        query = "SELECT * FROM staff WHERE Staff_Name LIKE '" + searchval + "' ORDER BY Staff_No ASC";

                    }
                    else if (cboSearchCriteria.Text == "Department")
                    {
                        query = "SELECT * FROM staff WHERE Department_Code LIKE '" + searchval + "' ORDER BY Staff_No ASC";

                    }
                    else if (cboSearchCriteria.Text == "ID No")
                    {
                        query = "SELECT * FROM staff WHERE Staff_ID LIKE '" + searchval + "' ORDER BY Staff_No ASC";

                    }
                    else if (cboSearchCriteria.Text == "Phone No")
                    {
                        query = "SELECT * FROM staff WHERE Phone_No LIKE '" + searchval + "' ORDER BY Staff_No ASC";

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
                        if (dataReader["Staff_No"].ToString().Replace(" ", "") != "")
                        {
                            string[] row = new string[] { dataReader["Staff_No"].ToString(), dataReader["Pf_No"].ToString(), dataReader["Staff_Name"].ToString(), dataReader["Designation"].ToString(), dataReader["Department_Code"].ToString(), dataReader["Staff_ID"].ToString(), dataReader["Phone_No"].ToString(), dataReader["Office"].ToString(), dataReader["Time_Available"].ToString() };
                            dataGridView1.Rows.Add(row);
                        }

                    }


                    connect.CloseConnection();
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cboStaffNo.Visible = true;
            cboStaffNo.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();

            staffCode = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            gboxSearch.Visible = false;
        }

        private void cboStaffNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Conn connect = new Conn();
            if (connect.OpenConnection() == true)
            {

                query = "SELECT * FROM staff WHERE Staff_No='" + cboStaffNo.Text.ToString() + "'";
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                if (dataReader.Read())
                {
                    cboStaffNo.Text = dataReader["Staff_No"].ToString();
                    txtPfNo.Text = dataReader["Pf_No"].ToString();
                    txtStaffName.Text = dataReader["Staff_Name"].ToString();
                    txtDesignation.Text = dataReader["Designation"].ToString();
                    cboDepCode.Text = dataReader["Department_Code"].ToString();
                    txtStaffID.Text = dataReader["Staff_ID"].ToString();
                    txtPostalAddress.Text = dataReader["Postal_Address"].ToString();
                    txtPostalCode.Text = dataReader["Postal_Code"].ToString();
                    txtTown.Text = dataReader["Town"].ToString();
                    txtResidence.Text = dataReader["Residence"].ToString();
                    txtEmail.Text = dataReader["Email_Address"].ToString();
                    txtPhoneNo.Text = dataReader["Phone_No"].ToString();
                    txtOffice.Text = dataReader["Office"].ToString();
                    txtTimeAvailable.Text = dataReader["Time_Available"].ToString();
                    txtLoginName.Text = dataReader["Login_Name"].ToString();
                    txtPassword.Text = dataReader["Passsword"].ToString();
                    txtConfirmPassword.Text = dataReader["Passsword"].ToString();
                    cboPriviledges.Text = dataReader["Priviledges"].ToString();
                    if (dataReader["Status"].ToString() == "1")
                    {
                        chkStatus.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        chkStatus.CheckState = CheckState.Unchecked;
                    }
                    staffCode = cboStaffNo.Text;
                }
                connect.CloseConnection();
            }
        }

        private void chkStatus_CheckedChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(chkStatus.CheckState.ToString());
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
            int x = 0;
            bool res = false;
            for (x = 0; x <= 9; x++)
            {
                if (str.Contains(x.ToString()))
                {
                    res = true;
                }

            }
            return res;

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
                        query = "SELECT * FROM staff ORDER BY Staff_No ASC";

                    }
                    else if (cboSearchCriteria.Text == "PF No")
                    {
                        query = "SELECT * FROM staff WHERE Staff_No LIKE '" + searchval + "' ORDER BY Staff_No ASC";

                    }
                    else if (cboSearchCriteria.Text == "Name")
                    {
                        query = "SELECT * FROM staff WHERE Staff_Name LIKE '" + searchval + "' ORDER BY Staff_No ASC";

                    }
                    else if (cboSearchCriteria.Text == "Department")
                    {
                        query = "SELECT * FROM staff WHERE Department_Code LIKE '" + searchval + "' ORDER BY Staff_No ASC";

                    }
                    else if (cboSearchCriteria.Text == "ID No")
                    {
                        query = "SELECT * FROM staff WHERE Staff_ID LIKE '" + searchval + "' ORDER BY Staff_No ASC";

                    }
                    else if (cboSearchCriteria.Text == "Phone No")
                    {
                        query = "SELECT * FROM staff WHERE Phone_No LIKE '" + searchval + "' ORDER BY Staff_No ASC";

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
                        if (dataReader["Staff_No"].ToString().Replace(" ", "") != "")
                        {
                            string[] row = new string[] { dataReader["Staff_No"].ToString(), dataReader["Pf_No"].ToString(), dataReader["Staff_Name"].ToString(), dataReader["Designation"].ToString(), dataReader["Department_Code"].ToString(), dataReader["Staff_ID"].ToString(), dataReader["Phone_No"].ToString(), dataReader["Office"].ToString(), dataReader["Time_Available"].ToString() };
                            dataGridView1.Rows.Add(row);
                        }

                    }


                    connect.CloseConnection();
                    PrintDialog printDial = new PrintDialog();
                    printDial.Document = printDocument1;
                    printDial.UseEXDialog = true;
                    if (DialogResult.OK == printDial.ShowDialog())
                    {
                        printDocument1.DocumentName = "Staff Details";
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

            this.dataGridView1.Height = 254;
            this.dataGridView1.Width = 785;
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
