using MySql.Data.MySqlClient;
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
        public Password()
        {
            InitializeComponent();
            newpswtxt.PasswordChar = '*';
            newpswrepeattxt.PasswordChar = '*';
        }
        
        string newpass = "";
        private void pswsubmit_Click(object sender, EventArgs e)
        {
            string psw = "";
            

            updatepsw(psw);
        }

        private void updatepsw(String newpass)
        {
            String connstring = System.Configuration.ConfigurationManager.ConnectionStrings["team06ConnectionString"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                string query = "UPDATE systemlogin SET password=" + newpass +
                                "WHERE username = ;";
                using (MySqlCommand comm = new MySqlCommand(query, conn))
                {
                    conn.Open();

                    comm.ExecuteNonQuery();

                    conn.Close();
                }
            }
        }
    }
}
