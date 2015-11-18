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
        }

        private void Supplier_Load(object sender, EventArgs e)
        {

        }

        private void suppSubmit_Click(object sender, EventArgs e)
        {
            String connstring = System.Configuration.ConfigurationManager.ConnectionStrings["team06ConnectionString"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                using (MySqlCommand comm = new MySqlCommand("insertSupplier", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@nameBran", suppnametxt.Text);
                    comm.Parameters.AddWithValue("@conNo", suppnrtxt.Text);
                    comm.Parameters.AddWithValue("@repFname", suppfnametxt.Text);
                    comm.Parameters.AddWithValue("@RepLname", supplnametxt.Text);
                    comm.Parameters.AddWithValue("@contEmail", suppemailtxt.Text);

                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                    clear();
                    //suppmsg.Text = "Successfully added an entry";
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
