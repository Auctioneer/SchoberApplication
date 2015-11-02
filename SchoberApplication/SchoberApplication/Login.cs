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
       




        private void label2_Click(object sender, EventArgs e)
        {

        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
            LoginArgs loginArgs = new LoginArgs(cTextUsername.Text + "%%" + cTextPassword.Text);
            OnLogin(this, loginArgs);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cTextUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void helpMissingPasswordLabel_Click(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load_1(object sender, EventArgs e)
        {

        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnLoginFormClose();
        }

      


    }
}
