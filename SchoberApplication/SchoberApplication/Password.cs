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
    public partial class Password : Form
    {
        string user = MainForm.uname;
        public Password()
        {
            InitializeComponent();
            newpswtxt.PasswordChar = '*';
            newpswrepeattxt.PasswordChar = '*';
        }
        
        private void pswsubmit_Click(object sender, EventArgs e)
        {
            string psw = "";
            if(newpswtxt.Text.Equals(newpswrepeattxt.Text))
            {
                psw = newpswtxt.Text;
                updatepsw(psw);
                MessageBox.Show("Password changed successfully.");
                clear();
            }
            else
            {
                MessageBox.Show("Entered passwords do not match.");
            }
            
 
        }
       
        private void updatepsw(String newpass)
        {
               
            String connstring = System.Configuration.ConfigurationManager.ConnectionStrings["team06ConnectionString"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                //string query = "UPDATE systemlogin SET password=\"" + Login.calcMD5(newpass) + "\"" + " WHERE systemlogin.username=\"" + MainForm.uname.ToString() + "\";";
                using (MySqlCommand comm = new MySqlCommand("updatepassword", conn))
                {

                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@newpass", Login.calcMD5(newpass));
                    comm.Parameters.AddWithValue("@uname", MainForm.uname.ToString());

                    conn.Open();

                    comm.ExecuteNonQuery();

                    conn.Close();
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
