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
            getPosition();
        }
        //--------------------------------------------------------
        // POPULATE BRANCH COMBOBOX
        //--------------------------------------------------------
        private void getBranch()
        {
            String connstring = System.Configuration.ConfigurationManager.ConnectionStrings["team06ConnectionString"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {              
                using (MySqlCommand comm = new MySqlCommand("storename", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;
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
        // POPULATE POSITION COMBOBOX
        //--------------------------------------------------------

        private void getPosition()
        {
            String connstring = System.Configuration.ConfigurationManager.ConnectionStrings["team06ConnectionString"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                using (MySqlCommand comm = new MySqlCommand("jobname", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    MySqlDataReader dr;
                    dr = comm.ExecuteReader();
                    while (dr.Read())
                    {
                        empposdrop.Items.Add(dr.GetString("JobName"));
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
                using (MySqlCommand comm = new MySqlCommand("getstoreid", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@store", empbranchdrop.Text);

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
                using (MySqlCommand comm = new MySqlCommand("insert_login", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;

                    comm.Parameters.AddWithValue("@login", login);
                    comm.Parameters.AddWithValue("@pass", Login.calcMD5("pass"));

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
                using (MySqlCommand comm = new MySqlCommand("getloginid", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@user", login);
                    
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
            // GET POSITION ID
            //--------------------------------------------------------

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                using (MySqlCommand comm = new MySqlCommand("getjobid", conn))
                {

                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@job", empposdrop.Text);

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
                using (MySqlCommand comm = new MySqlCommand("new_employee", conn))
                {
                    
                    comm.CommandType = CommandType.StoredProcedure;
                    
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
                    if (empaddress2txt.Text != "")
                    {
                        comm.Parameters.AddWithValue("@address2", empaddress2txt.Text);
                    }
                    comm.Parameters.AddWithValue("@zip", empziptxt.Text);
                    comm.Parameters.AddWithValue("@reg", empregiontxt.Text);
                    comm.Parameters.AddWithValue("@count", empcountrytxt.Text); 

                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();

                    clear();
                    //employeemsg.Text = "Successfully added an entry";
                    MessageBox.Show("Successfully added an entry");
                }
            }
        }

        public void clear()
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
