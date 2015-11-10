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

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {

                using(MySqlCommand comm = new MySqlCommand("address"))
                {
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Connection = conn;

                    comm.Parameters.AddWithValue("@address1",straddress1txt.Text);
                    comm.Parameters.AddWithValue("@address2", straddress2txt.Text);
                    comm.Parameters.AddWithValue("@zip", strziptxt.Text);
                    comm.Parameters.AddWithValue("@reg", strregiontxt.Text);
                    comm.Parameters.AddWithValue("@count", strcountrytxt.Text);
                   
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();  
                }
            }
        }
    }
}
