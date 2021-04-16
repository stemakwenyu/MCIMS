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
    public partial class frmLogin : Form
    {
        private string query;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            //this.Dispose();
            Conn connn = new Conn();
            connn.CloseConnection();
            Application.Exit();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }

        private void frmLogin_UnLoad(object sender, EventArgs e)
        {
            Conn connn = new Conn();
            connn.CloseConnection();
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Replace(" ","")== "")
            {
                MessageBox.Show("Ensure all fields are filled!","MMUST CIMS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                txtUsername.Focus();
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!","MMUST CIMS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                txtPassword.Focus();
            }
            else
            {
                Conn connect = new Conn();
                query = "SELECT * FROM  staff WHERE Login_Name='"+ txtUsername.Text.ToString() +"' AND Passsword='"+ txtPassword.Text.ToString() +"' AND Status=1";

                //open connection
                if (connect.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    if (dataReader.Read())
                    {
                        //list[0].Add(dataReader["id"] + "");
                        //list[1].Add(dataReader["name"] + "");
                        if (dataReader["Login_Name"].ToString() == txtUsername.Text && dataReader["Passsword"].ToString() == txtPassword.Text)
                        {
                            Sessions.username = dataReader["Staff_Name"].ToString();
                            Sessions.prev = dataReader["Priviledges"].ToString();
                            Sessions.userID = dataReader["Staff_No"].ToString();
                            Sessions.loginTime = DateTime.Now.ToString();
                            MDIParent1 mdi = new MDIParent1();
                            mdi.Visible = true;
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Username/Password Mismatch!\nPlease Try again!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtUsername.Text = "";
                            txtPassword.Text = "";
                            txtUsername.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username/Password Mismatch!\nPlease Try again!","MMUST CIMS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        txtUsername.Text = "";
                        txtPassword.Text = "";
                        txtUsername.Focus();
                    }

                    //close Data Reader
                    dataReader.Close();


                    //close connection
                    connect.CloseConnection();
                }

                
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            Conn connn = new Conn();
            connn.CloseConnection();
            lblConfirmPassword.Visible = false;
            lblStaffNo.Text = "Staff No:";
            lblPhoneNo.Text = "Phone No:";
            gboxReset.Visible = false;
            groupBox1.Left = (this.ClientSize.Width - groupBox1.Width) / 2;
            groupBox1.Top = (this.ClientSize.Height - groupBox1.Height) / 2;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            gboxReset.Visible = true;
            lblPhoneNo.Text = "Phone No:";
            lblStaffNo.Text = "Staff No:";
            txtPassword2.Visible = false;
            lblConfirmPassword.Visible = false;
            txtConfirmPassword.Visible = false;
            Sessions.userID = "";
            Sessions.phoneNo = "";
            txtStaffNo.Focus();
            

        }
        private bool FindRecord(string scode,string phno)
        {
            Conn connect = new Conn();
            if (connect.OpenConnection() == true)
            {

                query = "SELECT * FROM staff WHERE Staff_No='" + scode + "' and Phone_No='"+ phno +"'";
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                if (dataReader.Read())
                {
                    if (dataReader["Staff_No"].ToString() == scode && dataReader["Phone_No"].ToString() == phno)
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
                    connect.CloseConnection();
                    return false;
                }
            }
            else
            {
                return true;
            }



        }
        private bool FindRecord2(string scode)
        {
            Conn connect = new Conn();
            if (connect.OpenConnection() == true)
            {

                query = "SELECT * FROM staff WHERE Staff_No='" + Sessions.userID + "' and Phone_No='" + Sessions.phoneNo + "' and Passsword='"+ scode +"'";
                
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                if (dataReader.Read())
                {
                    if (dataReader["Passsword"].ToString() == scode && dataReader["Phone_No"].ToString() == Sessions.phoneNo && dataReader["Staff_No"].ToString() == Sessions.userID)
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
                    connect.CloseConnection();
                    return false;
                }
            }
            else
            {
                return true;
            }



        }
        private void btnRequest_Click(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Visible == false)
            {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var stringChars = new char[8];
                var random = new Random();
                long phone;
                string phn = txtPhoneNo.Text.Replace("+", "").Trim().ToString();

                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }

                var finalString = new String(stringChars);

                if (txtStaffNo.Text == "")
                {
                    MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtStaffNo.Focus();
                }
                else if (txtPhoneNo.Text == "")
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
                else
                {
                    if (FindRecord(txtStaffNo.Text, txtPhoneNo.Text) == true)
                    {

                        //MessageBox.Show(finalString);
                        Sessions.phoneNo = txtPhoneNo.Text.Trim();
                        Sessions.userID = txtStaffNo.Text;
                        string senders="MCIMS";
                        string subject="MCIMS Passwword Reset";
                        string body="Your new Password is "+ finalString +". If you did not request for password reset, Please contact system administrator urgently";
                        query = "UPDATE staff SET Passsword='" + finalString + "' WHERE Staff_No='" + txtStaffNo.Text.ToString() + "' AND Phone_No='" + txtPhoneNo.Text.ToString() + "'";
                        string query1 = "INSERT INTO messages(Direction,Type,Status,Sender,Recipient,Subject,Body) VALUES(2,2,1,'"+ senders+"','"+ Sessions.phoneNo+"','"+ subject+"','"+ body +"')";
                        Conn connect = new Conn();
                        connect.CloseConnection();
                        if (connect.OpenConnection() == true)
                        {
                            //create command and assign the query and connection from the constructor
                            MySqlCommand cmd = new MySqlCommand(query, connect.connection);

                            //Execute command
                            cmd.ExecuteNonQuery();
                            //create command and assign the query and connection from the constructor
                            
                        }
                        connect.CloseConnection();
                        Conn connect2 = new Conn();
                        if (connect2.OpenConnection() == true)
                        {
                            //create command and assign the query and connection from the constructor
                            MySqlCommand cmd = new MySqlCommand(query1, connect2.connection);

                            //Execute command
                            cmd.ExecuteNonQuery();
                            
                        }
                        connect2.CloseConnection();
                        MessageBox.Show("New password has been sent to your phone number", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblStaffNo.Text = "Reset Code:";
                        lblPhoneNo.Text = "Password:";
                        txtStaffNo.Text = "";
                        txtPhoneNo.Text = "";
                        txtConfirmPassword.Text = "";
                        txtPassword2.Visible= true;
                        txtConfirmPassword.Visible = true;
                        lblConfirmPassword.Visible = true;
                        txtStaffNo.Focus();

                    }
                    else
                    {
                        MessageBox.Show("Staff Details do not exist!\nPlease try again or contact system administrator", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtStaffNo.Text = "";
                        txtPhoneNo.Text = "";
                        txtPassword2.Text= "";
                        txtStaffNo.Focus();
                    }

                }
            }
            else
            {
                if (txtStaffNo.Text.Trim() == "")
                {
                    MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtStaffNo.Focus();
                }
                else if (txtPassword2.Text == "")
                {
                    MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPassword2.Focus();
                }
                else if (txtPassword2.Text.Length < 5)
                {
                    MessageBox.Show("Weak Password, Put 5 or more characters", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPassword2.Focus();
                }
                else if (txtConfirmPassword.Text == "")
                {
                    MessageBox.Show("Ensure all fields are filled!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtConfirmPassword.Focus();
                }
                else if (txtPassword2.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Password Mismatch!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPassword2.Text = "";
                    txtConfirmPassword.Text = "";
                    txtPassword2.Focus();
                }
                else if (FindRecord2(txtStaffNo.Text) == false)
                {
                    MessageBox.Show("Invalid Code!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtStaffNo.Text = "";
                    txtStaffNo.Focus();
                }
                else
                {
                    //MessageBox.Show(finalString);
                    query = "UPDATE staff SET Passsword='" + txtPassword2.Text.ToString() + "' WHERE Staff_No='" + Sessions.userID + "' AND Phone_No='" + Sessions.phoneNo + "'";
                    Conn connect = new Conn();
                    connect.CloseConnection();
                    if (connect.OpenConnection() == true)
                    {
                        //create command and assign the query and connection from the constructor
                        MySqlCommand cmd = new MySqlCommand(query, connect.connection);

                        //Execute command
                        cmd.ExecuteNonQuery();
                    }
                    connect.CloseConnection();
                    MessageBox.Show("Password has been successfully reset!", "MMUST CIMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblStaffNo.Text = "Staff No:";
                    lblPhoneNo.Text = "Phone No:";
                    txtStaffNo.Text = "";
                    txtPhoneNo.Text = "";
                    txtConfirmPassword.Text = "";
                    txtPassword2.Text ="";
                    txtPassword2.Visible = false;
                    txtConfirmPassword.Visible = false;
                    lblConfirmPassword.Visible = false;
                    gboxReset.Visible = false;
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    Sessions.phoneNo = "";
                    Sessions.userID = "";
                    txtUsername.Focus();
                }
            

            }



        }

        private void btnQuitRequest_Click(object sender, EventArgs e)
        {
            Sessions.phoneNo = "";
            Sessions.userID = "";
            txtPassword2.Text ="";
            txtPhoneNo.Text = "";
            txtStaffNo.Text = "";
            txtConfirmPassword.Text = "";
            lblPhoneNo.Text ="Phone No:";
            txtPassword2.Visible = false;
            lblConfirmPassword.Visible=false;
            txtConfirmPassword.Visible = false;

            gboxReset.Visible = false;
        }

        private void btnResetRequest_Click(object sender, EventArgs e)
        {
            txtPhoneNo.Text = "";
            txtPassword2.Text = "";
            txtStaffNo.Text = "";
            txtConfirmPassword.Text = "";
            txtStaffNo.Focus();
        }
    }
}
