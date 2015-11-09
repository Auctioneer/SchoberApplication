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
    
            String storename = strnametxt.Text;
            String storeadd1 = straddress1txt.Text;
            String storeadd2 = straddress2txt.Text;
            String storenr = strnrtxt.Text;
            String storezip = strziptxt.Text;
            String storeregion = strregiontxt.Text;
            String storecountry = strcountrytxt.Text;
            int addressFK = int.Parse(textBox1.Text);

            
            
            

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {

                String query = "INSERT INTO Store (Name, ContactNumber, Address_idAddress) VALUES (@Name, @ContactNumber, @Address_idAddress)";

                String query1 = "INSERT INTO Address (AddressLine1, AddressLine2, Pstcode, Region, Country) VALUES (storeadd1, storeadd2, storenr, storezip, storeregion, storecountry)";
                using(MySqlCommand comm = new MySqlCommand(query))
                {
                    comm.Connection = conn;
                    comm.Parameters.Add("@Name", MySqlDbType.VarChar, 45).Value = storename;
                    comm.Parameters.Add("@ContactNumber", MySqlDbType.VarChar, 15).Value = storenr;
                    comm.Parameters.Add("@Address_idAddress", MySqlDbType.Int32, 11).Value = addressFK;
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                    
                }
       
            }
        }
    }
}
