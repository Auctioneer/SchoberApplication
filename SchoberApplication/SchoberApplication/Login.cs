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
using ConnectCsharpToMysql;


namespace SchoberApplication
{
    public partial class Login : Form
    {
        Boolean processing = false;
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
            DBConnect dbconn = new DBConnect();
            bool isU = dbconn.unameExists(username);

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
                if (!dbconn.matchPassword(username, pass))
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
    }
}
