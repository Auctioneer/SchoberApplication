using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChreneLib.Controls.TextBoxes;
using System.Threading;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;


namespace SchoberApplication
{
    public partial class Login : Form
    {
        public delegate void LoginHandler(object myObject,
                                               LoginArgs myArgs);
        public delegate void LoginPageClose();
        public event LoginHandler OnLogin;
        public event LoginPageClose OnLoginFormClose;
        public Login()
        {

            InitializeComponent();
            //Check whether key was ENTER/Return which in turn Calls OnLogin with the correct Login Info.
            cTextPassword.KeyDown += new KeyEventHandler(this.Login_EnterPress);
            cTextUsername.KeyDown += new KeyEventHandler(this.Login_EnterPress);

        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void Login_EnterPress(object sender, KeyEventArgs e)
        {
            //Could use a Semaphore here to Eliminate multiple Logins to be called.

            //If user pressed the Return/Enter KEy, continue
            if (e.KeyCode.CompareTo(Keys.Return) == 0)
            {
                //Do not bother trying to log in if there is an empty Text Field
                if (this.checkMissing())
                    return;
                //Call Logging In Method.
                LoginUser();
            }

        }

        //Returns True if either Username or Password TextBox is empty
        //Makes help label visible in the case of either MIssing & Focuses on missing TextBox
        private Boolean checkMissing()
        {
            helpMissingUsernameLabel.Visible = false;
            helpMissingPasswordLabel.Visible = false;
            if (cTextUsername.Text.Length == 0)
            {
                helpMissingUsernameLabel.Visible = true;
                cTextUsername.Focus();
                return true;
            }

            if (cTextPassword.Text.Length == 0)
            {
                helpMissingPasswordLabel.Visible = true;
                cTextPassword.Focus();
                return true;
            }
            return false;
        }






        //Called when user Presses the signInButton.
        //Calls loginEvent.
        private void signinButton_Click(object sender, EventArgs e)
        {
            if (this.checkMissing())
                return;
            LoginUser();
        }

        private void LoginUser()
        {
            incorrectUsernameLabel.Visible = false;
            incorrectPasswordLabel.Visible = false;
            String username = cTextUsername.Text;
            String pass = cTextPassword.Text;
            

            if (!checkCredentials(username, pass))
            {
                return;
            }
            LoginArgs loginArgs = new LoginArgs(username);
            OnLogin(this, loginArgs);
        }

        private bool checkCredentials(String username, String pass)
        {
            bool isU = unameExists(username);

            if (!isU)
            {
                incorrectUsernameLabel.Visible = true;
                cTextPassword.Text = "";
                cTextUsername.Text = "";
                cTextUsername.Focus();
                return false;
            }
            else
            {
                if (!matchPassword(username, pass))
                {
                    incorrectPasswordLabel.Visible = true;
                    cTextPassword.Text = "";
                    return false;
                }
            }

            return true;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnLoginFormClose();
        }



        //QUERIES
        //For hashing passwords. source: http://blogs.msdn.com/b/csharpfaq/archive/2006/10/09/how-do-i-calculate-a-md5-hash-from-a-string_3f00_.aspx
        public static string calcMD5(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }

        //Check if username is in the database - for log in. Method by KP
        private bool unameExists(String usernameToCompare)
        {
            String connstring = System.Configuration.ConfigurationManager.ConnectionStrings["team06ConnectionString"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                string query = "SELECT username FROM systemlogin";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    MySqlDataReader data = cmd.ExecuteReader();
                    while (data.Read())
                    {
                        String username = data.GetString("username");
                        if (username.CompareTo(usernameToCompare) == 0)
                        {
                            conn.Close();
                            return true;
                        }
                    }
                    conn.Close();
                }
            }
            return false;
        }

        //Check if given username matches with password- for log in. Method by KP
        private bool matchPassword(String usernameToCompare, String passToCompare)
        {
            String connstring = System.Configuration.ConfigurationManager.ConnectionStrings["team06ConnectionString"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                string query = "SELECT password FROM systemlogin WHERE username=\"" + usernameToCompare + "\"";
                String password = null;
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    MySqlDataReader data = cmd.ExecuteReader();
                    while (data.Read())
                    {
                        password = data.GetString("password");
                    }
                    if (password != null)
                    {
                        passToCompare = calcMD5(passToCompare);
                        if (password.CompareTo(passToCompare) == 0)
                        {
                            conn.Close();
                            return true;
                        }

                    }
                }
                conn.Close();
            }
            return false;
        }
            
    }
}
