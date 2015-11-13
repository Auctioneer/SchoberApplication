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

                string querybranch = "SELECT Name FROM store";

                using (MySqlCommand comm = new MySqlCommand(querybranch, conn))
                {
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

                string queryprod = "SELECT ProductName FROM product";

                using (MySqlCommand comm = new MySqlCommand(queryprod, conn))
                {
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
                string queryb = "SELECT idStore FROM store WHERE Name=" + "'" + saleinstoredrop.Text + "';";
                using (MySqlCommand comm = new MySqlCommand(queryb, conn))
                {
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
                string queryb = "SELECT idProduct FROM product WHERE ProductName=" + "'" + itemsolddrop.Text + "';";
                using (MySqlCommand comm = new MySqlCommand(queryb, conn))
                {
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
                string query = "INSERT INTO sales (Date, Quantity, Store_idStore, Product_idProduct)" +
                               "VALUES (@date, @quantity, @storeid, @productid);";
                using (MySqlCommand comm = new MySqlCommand(query, conn))
                {
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
