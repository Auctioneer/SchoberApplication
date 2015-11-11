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
using System.Configuration;

namespace SchoberApplication
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
            getBranch();
        }
        //--------------------------------------------------------
        // POPULATE BRANCH COMBOBOX
        //--------------------------------------------------------
        private void getBranch()
        {
            String connstring = System.Configuration.ConfigurationManager.ConnectionStrings["team06ConnectionString"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                
                string querybranch = "SELECT Name FROM store";
                
                using (MySqlCommand comm = new MySqlCommand(querybranch, conn))
                {
                    conn.Open();
                    MySqlDataReader dr;
                    dr = comm.ExecuteReader();
                    while (dr.Read())
                    {
                        empbranchdrop.Items.Add(dr.GetString("Name"));
                    }
                    conn.Close(); 
                }
            }
        }

        //--------------------------------------------------------
        // EMPLOYEE FORM SUBMIT
        //--------------------------------------------------------

        private void submitEmployee_Click(object sender, EventArgs e)
        {
            int branchid = 0;
            int loginid = 0;
            int jobid = 0;
            //generate login. first 3 characters of first name and 2 first characters of last name
            string login = empnametxt.Text.Substring(0, 3) + emplasttxt.Text.Substring(0, 2);
            //get connection string from config
            String connstring = System.Configuration.ConfigurationManager.ConnectionStrings["team06ConnectionString"].ConnectionString;

            //--------------------------------------------------------
            // GET STORE ID
            //--------------------------------------------------------
            
            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                string queryb = "SELECT idStore FROM store WHERE Name=" + "'" + empbranchdrop.Text + "';";
                using (MySqlCommand comm = new MySqlCommand(queryb, conn))
                {
                    conn.Open();
                    MySqlDataReader dr;
                    dr = comm.ExecuteReader();
                    while (dr.Read())
                    {
                        branchid = dr.GetInt32(0);
                    }
                    conn.Close();
                }
            }

            //--------------------------------------------------------
            // INSERT LOGIN DETAILS
            //--------------------------------------------------------

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                string queryl = "INSERT INTO systemlogin (username, password) VALUES (@login, @pass);";
                using (MySqlCommand comm = new MySqlCommand(queryl, conn))
                {
                    comm.Parameters.AddWithValue("@login", login);
                    comm.Parameters.AddWithValue("@pass", "pass");

                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
            }

            //--------------------------------------------------------
            // GET SYSTEM LOGIN ID
            //--------------------------------------------------------

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                string queryl = "SELECT idSystemLogin FROM systemlogin WHERE username=" + "'" + login + "';";
                using (MySqlCommand comm = new MySqlCommand(queryl, conn))
                {
                    conn.Open();
                    MySqlDataReader dr;
                    dr = comm.ExecuteReader();
                    while (dr.Read())
                    {
                        loginid = dr.GetInt32(0);
                    }
                    conn.Close();
                }
            }

            //--------------------------------------------------------
            // INSERT POSITION DETAILS
            //--------------------------------------------------------

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                string queryj = "INSERT INTO job (JobName, Salary, HoursPerWeek) VALUES (@position, @salary, @hours);";
                using (MySqlCommand comm = new MySqlCommand(queryj, conn))
                {
                    comm.Parameters.AddWithValue("@position", emppositiontxt.Text);
                    comm.Parameters.AddWithValue("@salary", empsalarytxt.Text);
                    comm.Parameters.AddWithValue("@hours", Int32.Parse(emphoursdrop.Text));

                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
            }

            //--------------------------------------------------------
            // GET POSITION ID
            //--------------------------------------------------------

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                string queryj = "SELECT idjob FROM job WHERE JobName=" + "'" + emppositiontxt.Text + "';";
                using (MySqlCommand comm = new MySqlCommand(queryj, conn))
                {
                    conn.Open();
                    MySqlDataReader dr;
                    dr = comm.ExecuteReader();
                    while (dr.Read())
                    {
                        jobid = dr.GetInt32(0);
                    }
                    conn.Close();
                }
            }

            //--------------------------------------------------------
            // INSERT ADDRESS AND WORKER DETAILS
            //--------------------------------------------------------

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                  
                string query = "BEGIN;" +
                                "INSERT INTO address (AddressLine1, AddressLine2, Postcode, Region, Country)" +
                                "VALUES (@address1, @address2, @zip, @reg, @count);" +
                                "INSERT INTO worker (FirstName, LastName, Email, Phone, Address_idAddress, Store_idStore, Job_idJob, SystemLogin_idSystemLogin )" +
                                "VALUES (@fname, @lname, @email, @nr, LAST_INSERT_ID(), @branchid, @jobid, @loginid);" +
                                "COMMIT;";
                using (MySqlCommand comm = new MySqlCommand(query, conn))
                {
                    //WORKER
                    comm.Parameters.AddWithValue("@fname", empnametxt.Text);
                    comm.Parameters.AddWithValue("@lname", emplasttxt.Text);
                    comm.Parameters.AddWithValue("@email", empemailtxt.Text);
                    comm.Parameters.AddWithValue("@nr", empphonetxt.Text);
                    comm.Parameters.AddWithValue("@branchid", branchid);
                    comm.Parameters.AddWithValue("@jobid", jobid);
                    comm.Parameters.AddWithValue("@loginid", loginid);
                    //ADDRESS
                    comm.Parameters.AddWithValue("@address1", empaddress1txt.Text);
                    comm.Parameters.AddWithValue("@address2", empaddress2txt.Text);
                    comm.Parameters.AddWithValue("@zip", empziptxt.Text);
                    comm.Parameters.AddWithValue("@reg", empregiontxt.Text);
                    comm.Parameters.AddWithValue("@count", empcountrytxt.Text);

                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();

                    clear();
                    employeemsg.Text = "Successfully added an entry";
                }
            }
        }



        private void clear()
        {
            foreach (var c in this.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = String.Empty;
                }
            }
        }
    }
}
