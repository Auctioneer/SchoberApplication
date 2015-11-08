using System;
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

            string server = "localhost";
            string uid = "mantas";
            string password = "labas";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            string Query = "SELECT * FROM mydb.address WHERE idAddress=1";

            MySqlConnection con = new MySqlConnection(connectionString);
            MySqlCommand comm = new MySqlCommand(Query, con);
            MySqlDataReader dr;
            try
            {
                con.Open();
                dr = comm.ExecuteReader();
                while(dr.Read())
                {
                    textBox1.Text = dr.GetString("Postcode");
                }
                con.Close();
            }
            catch (Exception Exception){ }

                
            
        }
    }
}
