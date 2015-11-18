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
    public partial class Sale : Form
    {
        public Sale()
        {
            InitializeComponent();
            getBranch();
            getProduct();
        }

        //--------------------------------------------------------
        // POPULATE BRANCH COMBOBOX
        //--------------------------------------------------------
        private void getBranch()
        {
            String connstring = System.Configuration.ConfigurationManager.ConnectionStrings["team06ConnectionString"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                using (MySqlCommand comm = new MySqlCommand("storename", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    MySqlDataReader dr;
                    dr = comm.ExecuteReader();
                    while (dr.Read())
                    {
                        saleinstoredrop.Items.Add(dr.GetString("Name"));
                    }
                    conn.Close();
                }
            }
        }

        //--------------------------------------------------------
        // POPULATE ITEM COMBOBOX
        //--------------------------------------------------------
        private void getProduct()
        {
            String connstring = System.Configuration.ConfigurationManager.ConnectionStrings["team06ConnectionString"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                using (MySqlCommand comm = new MySqlCommand("getproductname", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    MySqlDataReader dr;
                    dr = comm.ExecuteReader();
                    while (dr.Read())
                    {
                       itemsolddrop.Items.Add(dr.GetString("ProductName"));
                    }
                    conn.Close();
                }
            }
        }

        //--------------------------------------------------------
        // SALE FORM SUBMIT
        //--------------------------------------------------------

        private void salesubmit_Click(object sender, EventArgs e)
        {
            String connstring = System.Configuration.ConfigurationManager.ConnectionStrings["team06ConnectionString"].ConnectionString;
            int branchid = 0;
            int prodid = 0;

            //--------------------------------------------------------
            // GET STORE ID
            //--------------------------------------------------------

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                using (MySqlCommand comm = new MySqlCommand("getstoreid", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@store", saleinstoredrop.Text);

                    conn.Open();
                    MySqlDataReader dr;
                    dr = comm.ExecuteReader();
                    while (dr.Read())
                    {
                        branchid = dr.GetInt32(0);
                    }
                    conn.Close();
                }
            }

            //--------------------------------------------------------
            // GET Product ID
            //--------------------------------------------------------

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                using (MySqlCommand comm = new MySqlCommand("getproductid", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@product", itemsolddrop.Text);
                    
                    conn.Open();
                    MySqlDataReader dr;
                    dr = comm.ExecuteReader();
                    while (dr.Read())
                    {
                        prodid = dr.GetInt32(0);
                    }
                    conn.Close();
                }
            }

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                using (MySqlCommand comm = new MySqlCommand("insertsale", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;
                    
                    comm.Parameters.AddWithValue("@date", DateTime.Now);
                    comm.Parameters.AddWithValue("@quantity", Int32.Parse(soldquantitytxt.Text));
                    comm.Parameters.AddWithValue("@storeid", branchid);
                    comm.Parameters.AddWithValue("@productid", prodid);

                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();

                    clear();
                    salemsg.Text = "Successfully added an entry";
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

        private void Sale_Load(object sender, EventArgs e)
        {

        }
    }
}
