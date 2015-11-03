using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectCsharpToMysql;

namespace SchoberApplication
{
    public partial class MainForm : Form
    {
        List<Label> _priviledgeLabels;
        Login login;
        DBConnect db;
        Form1 form1 = new Form1();
        public AccessLevels userAccess = AccessLevels.None;
        public MainForm()
        {
            InitializeComponent();
            _priviledgeLabels = new List<Label>();
            //buttonBox.Controls.Add(graphsButton);
            //buttonBox.Controls.Add(employeeButton);
            //buttonBox.Controls.Add(productButton);
            //buttonBox.Controls.Add(editTableButton);
            //buttonBox.Controls.Add(storeButton);
            //buttonBox.Controls.Add(supplierButton);
            //buttonBox.Controls.Add(logoutButton);
            
            //Creates LogInScreen which changes user's AccessLevel
            logUser();

            connectDataBase();
            
        }

        private void connectDataBase()
        {
            db = new DBConnect();
            Console.WriteLine(db.OpenConnection());
        }

        private void logUser()
        {
            login = new Login(); //Create a login Screen 
        
            //Is called when user Presses Login Button. Will be used to crosscheck username and password with database and grant user according priviledges. 

            login.OnLogin += new Login.LoginHandler(CheckLogin);
            //CheckForNoPriviledges Is called when Login Form is closed.
            //If the user hasn't gained any priviledges after logging in, it closes the Application.
            login.OnLoginFormClose += new Login.LoginPageClose(CheckForNoPriviledge); 
            this.Hide();
            login.ShowDialog();

            
        }

        private void CheckForNoPriviledge()
        {
            Console.WriteLine("WOOO PRIVILEDGE");
            if (userAccess == AccessLevels.None)
                Application.Exit();
        }

        void CheckLogin(object a, LoginArgs e)
        {
          
            //Check whether the loginDetails are comparable to the ones we have in database and give user according userAccess.
            //e.LoginDetails returns a String in the format  "username%%password"
            //Currently temp code which will be replaced by a query to database
            Console.WriteLine( "PRIVILEDGE NOT SET");


            if (e.LoginDetails.CompareTo(e.LoginDetails) == 0)
            {
                userAccess = AccessLevels.Admin;

            }
            else
            {
                userAccess = AccessLevels.None;
            }
            this.StartPosition = FormStartPosition.Manual;
            //Show this main form again slightly above where the Login page was (Incase it was moved)
            this.Location = new Point(((Form)a).Location.X, ((Form)a).Location.Y - 150);
            ((Form)a).Close(); //Close the Login Screen and return to whatever screen launched it.
         //   priviledgeLabels.
            ShowUserPriviledges(userAccess);
            
        }

        private void ShowUserPriviledges(AccessLevels userAccess)
        {
            foreach (Control button in buttonBox.Controls)
            {
                if (button.Name.Contains("Yes") || button.Name.Contains("No"))
                    button.Visible = false;
            }

            if (userAccess == AccessLevels.Admin)
            {
                foreach (Control button in buttonBox.Controls)
                {
                    if (button.Name.Contains("Yes"))
                        button.Visible = true;
                }
            }
            else if(userAccess == AccessLevels.Regular)
            {
                editPrivLabelNo.Visible = true;
                productPrivLabelYes.Visible = true;
                //ADD REST OF PRIVILEDGES HERE.

            }
            //List<Label> _priviledgeLabels = null;
            //Console.WriteLine(userAccess);
            //_priviledgeLabels = new List<Label>();
         

                //for (int i = 0; i < buttonBox.Controls.Count; i++)
                //{

                    //_priviledgeLabels.Add(new Label());
                    //_priviledgeLabels[i].Font = yesLabel.Font;
                    // _priviledgeLabels[i].Size = yesLabel.Size;
                    //_priviledgeLabels[i].ForeColor = yesLabel.ForeColor;
                    //_priviledgeLabels[i].AutoSize = true;
                    // _priviledgeLabels[i].Text = yesLabel.Text;
                    ////_priviledgeLabels[i].StartPosition = FormStartPosition.Manual;
                    ////_priviledgeLabels[i].Location = new Point(200 , 200);
                    //_priviledgeLabels[i].Location = new Point(buttonBox.Controls[i].Location.X + buttonBox.Controls[i].Size.Width + 5, buttonBox.Controls[i].Location.Y + 5); 
                    //_priviledgeLabels[i].Visible = true;
                    //_priviledgeLabels[i].Show();
                    //_priviledgeLabels[i].BringToFront();
               
                //}

            this.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
            form1.MdiParent = this;
           

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void productPrivLabelYes_Click(object sender, EventArgs e)
        {

        }

        private void productButton_Click(object sender, EventArgs e)
        {
            form1.MdiParent = this;
            form1.Show();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            userAccess = AccessLevels.None;
            logUser();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (userAccess == AccessLevels.None)
                Application.Exit();
        }

     
       
    }

}
