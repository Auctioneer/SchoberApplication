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
    public partial class Supplier : Form
    {
        public Supplier()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void Supplier_Load(object sender, EventArgs e)
        {

        }

        private void suppSubmit_Click(object sender, EventArgs e)
        {
            String connstring = System.Configuration.ConfigurationManager.ConnectionStrings["team06ConnectionString"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                //string query = "BEGIN; INSERT INTO address (AddressLine1, AddressLine2, Postcode, Region, Country) VALUES (@address1, @address2, @zip, @reg, @count); INSERT INTO store (Address_idAddress, Name, ContactNumber) VALUES (LAST_INSERT_ID(), @storename, @storenr); COMMIT;";
                string query = "insertSupplier";
                using (MySqlCommand comm = new MySqlCommand(query, conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@nameBran", suppnametxt.Text);
                    comm.Parameters.AddWithValue("@conNo", suppnrtxt.Text);
                    comm.Parameters.AddWithValue("@repFname", suppfnametxt.Text);
                    comm.Parameters.AddWithValue("@repLname", supplnametxt.Text);
                    comm.Parameters.AddWithValue("@contEmail", suppemailtxt.Text);

                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                    clear();
                    //storemsg.Text = "Successfully added an entry";
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
