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

        private void submitEmployee_Click(object sender, EventArgs e)
        {
              String connstring = System.Configuration.ConfigurationManager.ConnectionStrings["team06ConnectionString"].ConnectionString;

              using (MySqlConnection conn = new MySqlConnection(connstring))
              {
                  string query = "BEGIN;" +
                                 "INSERT INTO address (AddressLine1, AddressLine2, Postcode, Region, Country)" +
                                 "VALUES (@address1, @address2, @zip, @reg, @count);" + 
                                 "INSERT INTO worker (Address_idAddress, FirstName, LastName, Email, Phone, Store_Storeid )" +
                                 "VALUES (LAST_INSERT_ID(), @fname, @lname, @email, @nr, @branch);" +
                                 "COMMIT;";
                  using (MySqlCommand comm = new MySqlCommand(query, conn))
                  {

                      comm.Parameters.AddWithValue("@fname", empnametxt.Text);
                      comm.Parameters.AddWithValue("@lname", emplasttxt.Text);
                      comm.Parameters.AddWithValue("@email", empemailtxt.Text);
                      comm.Parameters.AddWithValue("@nr", empphonetxt.Text);
                      comm.Parameters.AddWithValue("@address1", empaddress1txt.Text);
                      comm.Parameters.AddWithValue("@address2", empaddress2txt.Text);
                      comm.Parameters.AddWithValue("@zip", empziptxt.Text);
                      comm.Parameters.AddWithValue("@reg", empregiontxt.Text);
                      comm.Parameters.AddWithValue("@count", empcountrytxt.Text);
                      comm.Parameters.AddWithValue("@position", emppositiontxt.Text);
                      comm.Parameters.AddWithValue("@salary", empsalarytxt.Text);
                      comm.Parameters.AddWithValue("@hours", emphoursdrop.Text);
                      comm.Parameters.AddWithValue("@branch", empbranchdrop.Text);
                      

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
