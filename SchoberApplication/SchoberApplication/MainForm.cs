using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SchoberApplication
{
    public partial class MainForm : Form
    {
        List<Label> _priviledgeLabels;
        Login login;
        Employee employee = new Employee();
        Product productForm = new Product();
        Supplier supplierForm = new Supplier();
        Store store = new Store();
        Graphs graphs = new Graphs();
        Tables tables = new Tables();

        //public static AccessLevels userAccess = AccessLevels.None;

        public MainForm()
        {
            InitializeComponent();

            //Creates LogInScreen which changes user's AccessLevel
            logUser();

            //connectDataBase();

        }

        private void hideControls()
        {
            employee.Hide();
            productForm.Hide();
            supplierForm.Hide();
            store.Hide();
            graphs.Hide();
            tables.Hide();

        }

        private void logUser()
        {
            login = new Login(); //Create a login Screen 
        
            //Is called when user Presses Login Button. Will be used to crosscheck username and password with database and grant user according priviledges. 

            login.OnLogin += new Login.LoginHandler(setPrivilige);
            //CheckForNoPriviledges Is called when Login Form is closed.
            //If the user hasn't gained any privileges after logging in, it closes the Application. THIS SHOULDN'T EVER HAPPEN - if it does this might indicate errors in the database
            login.OnLoginFormClose += new Login.LoginPageClose(CheckForNoPrivilege);
            this.Hide();
            login.ShowDialog();

            
        }

        private void CheckForNoPrivilege()
        {
            Console.WriteLine("PRIVILEGE CHECK");
            if (Program.userAccess == AccessLevels.None)
                Application.Exit();
        }

        void setPrivilige(object a, LoginArgs e)
        {

            //Check in the database for worker's job and assign priviliges accordingly
            //e.LoginDetails returns a username
            String uname = e.LoginDetails.ToString();
            int priv = getJob(uname);

            if (priv == 0)
            {
                Program.userAccess = AccessLevels.None;

            }
            else if (priv == 10700001 || priv == 10700002)
            {
                Program.userAccess = AccessLevels.Admin;
            }
            else if (priv == 10700003)
            {
                Program.userAccess = AccessLevels.Manager;
            }
            else
            {
                Program.userAccess = AccessLevels.Regular;
            }

            Console.WriteLine(Program.userAccess.ToString());

            this.StartPosition = FormStartPosition.Manual;
            //Show this main form again slightly above where the Login page was (In case it was moved)
            this.Location = new Point(((Form)a).Location.X, ((Form)a).Location.Y);
            ((Form)a).Close(); //Close the Login Screen and return to whatever screen launched it.
            //   privilegeLabels.
            ShowUserPrivileges(Program.userAccess);

        }

        private int getJob(String Username)
        {
            String connstring = System.Configuration.ConfigurationManager.ConnectionStrings["team06ConnectionString"].ConnectionString;
            int logID=0, jobID=0;

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                
                string logIdQuery = "SELECT idSystemLogin FROM systemlogin WHERE username=\"" + Username +"\"";
                using (MySqlCommand comm = new MySqlCommand(logIdQuery, conn))
                {
                    conn.Open();
                    MySqlDataReader dr;
                    dr = comm.ExecuteReader();
                    while (dr.Read())
                    {
                        logID = dr.GetInt32("idSystemLogin");
                    }
                    conn.Close();
                }
                string jobIdQuery = "SELECT Job_idJob FROM worker WHERE SystemLogin_idSystemLogin=" + logID;
                using (MySqlCommand comm = new MySqlCommand(jobIdQuery, conn))
                {
                    conn.Open();
                    MySqlDataReader dr;
                    dr = comm.ExecuteReader();
                    while (dr.Read())
                    {
                        jobID = dr.GetInt32("Job_idJob");
                    }
                    conn.Close();
                }
                
            }

            return jobID;
        }

        private void ShowUserPrivileges(AccessLevels userAccess)
        {
            if (userAccess == AccessLevels.Admin)
            {
                employeeButton.Enabled = true;
                productButton.Enabled = true;
                storeButton.Enabled = true;
                supplierButton.Enabled = true;
                graphsButton.Enabled = true;
            }
            else if (userAccess == AccessLevels.Manager)
            {
                employeeButton.Enabled = false;
                productButton.Enabled = true;
                storeButton.Enabled = false;
                supplierButton.Enabled = true;
                graphsButton.Enabled = false;
            }
            else if (userAccess == AccessLevels.Regular)
            {
                employeeButton.Enabled = false;
                productButton.Enabled = false;
                storeButton.Enabled = false;
                supplierButton.Enabled = false;
                graphsButton.Enabled = false;
            }

            this.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
            employee.MdiParent = this;
            store.MdiParent = this;

        }


        private void productButton_Click(object sender, EventArgs e)
        {
            hideControls();
            productForm.MdiParent = this;
            productForm.Dock = DockStyle.Fill;

            productForm.FormBorderStyle = FormBorderStyle.None;
            productForm.Show();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Program.userAccess = AccessLevels.None;
            logUser();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (Program.userAccess == AccessLevels.None)
                Application.Exit();
        }

        private void employeeButton_Click(object sender, EventArgs e)
        {
            hideControls();

            employee.MdiParent = this;
            employee.Dock = DockStyle.Fill;
            employee.ControlBox = false;
            employee.FormBorderStyle = FormBorderStyle.None;
            employee.Show();
        }


        private void supplierButton_Click(object sender, EventArgs e)
        {
            hideControls();
            supplierForm.MdiParent = this;
            supplierForm.Dock = DockStyle.Fill;
            supplierForm.ControlBox = false;
            supplierForm.FormBorderStyle = FormBorderStyle.None;
            supplierForm.Show();
        }

        private void storeButton_Click(object sender, EventArgs e)
        {
            store.MdiParent = this;
            store.Dock = DockStyle.Fill;
            store.ControlBox = false;
            store.FormBorderStyle = FormBorderStyle.None;
            store.Show();
        }

        private void graphsButton_Click(object sender, EventArgs e)
        {
            graphs.MdiParent = this;
            graphs.Dock = DockStyle.Fill;
            graphs.ControlBox = false;
            graphs.FormBorderStyle = FormBorderStyle.None;
            graphs.Show();
        }

        private void editTableButton_Click(object sender, EventArgs e)
        {
            tables.MdiParent = this;
            tables.Dock = DockStyle.Fill;
            tables.ControlBox = false;
            tables.FormBorderStyle = FormBorderStyle.None;
            tables.Show();
        }

    }

}
