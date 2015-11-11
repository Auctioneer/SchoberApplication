﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace SchoberApplication
{
    public partial class Store : Form
    {
        public Store()
        {
            InitializeComponent();
        }

        private void storeSubmit_Click(object sender, EventArgs e)
        {

            String connstring = System.Configuration.ConfigurationManager.ConnectionStrings["team06ConnectionString"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                string query = "BEGIN; INSERT INTO address (AddressLine1, AddressLine2, Postcode, Region, Country) VALUES (@address1, @address2, @zip, @reg, @count); INSERT INTO store (Address_idAddress, Name, ContactNumber) VALUES (LAST_INSERT_ID(), @storename, @storenr); COMMIT;";
                
                using(MySqlCommand comm = new MySqlCommand(query, conn))
                {
                    comm.Parameters.AddWithValue("@address1",straddress1txt.Text);
                    comm.Parameters.AddWithValue("@address2", straddress2txt.Text);
                    comm.Parameters.AddWithValue("@zip", strziptxt.Text);
                    comm.Parameters.AddWithValue("@reg", strregiontxt.Text);
                    comm.Parameters.AddWithValue("@count", strcountrytxt.Text);
                    comm.Parameters.AddWithValue("@storename", strnametxt.Text);
                    comm.Parameters.AddWithValue("@storenr", strnrtxt.Text);
                   
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                    clear();
                    storemsg.Text = "Successfully added an entry";  
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
