﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoberApplication
{
    public partial class Supplier : Form
    {
        public Supplier()
        {
            InitializeComponent();
        }

        private void Supplier_Load(object sender, EventArgs e)
        {

        }

        private void suppSubmit_Click(object sender, EventArgs e)
        {
            String connstring = System.Configuration.ConfigurationManager.ConnectionStrings["team06ConnectionString"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                string query = "INSERT INTO supplier (BrandName, ContactNo, RepFirstName, RepLastName, ContactEmail) VALUES (@brand, @nr, @fname, @lname, @email);";

                using (MySqlCommand comm = new MySqlCommand(query, conn))
                {
                    comm.Parameters.AddWithValue("@brand", suppnametxt.Text);
                    comm.Parameters.AddWithValue("@nr", suppnrtxt.Text);
                    comm.Parameters.AddWithValue("@fname", suppfnametxt.Text);
                    comm.Parameters.AddWithValue("@lname", supplnametxt.Text);
                    comm.Parameters.AddWithValue("@email", suppemailtxt.Text);

                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                    clear();
                    suppmsg.Text = "Successfully added an entry";
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
