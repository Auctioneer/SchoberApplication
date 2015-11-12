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
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
            getBranch();
            getBrand();
            getMaterial();
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
                        prodinstoredrop.Items.Add(dr.GetString("Name"));
                    }
                    conn.Close();
                }
            }
        }

        //--------------------------------------------------------
        // POPULATE MATERIAL COMBOBOX
        //--------------------------------------------------------

        private void getMaterial()
        {
            String connstring = System.Configuration.ConfigurationManager.ConnectionStrings["team06ConnectionString"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {

                string querymaterial = "SELECT Name FROM material";

                using (MySqlCommand comm = new MySqlCommand(querymaterial, conn))
                {
                    conn.Open();
                    MySqlDataReader dr;
                    dr = comm.ExecuteReader();
                    while (dr.Read())
                    {
                        prodmaterialdrop.Items.Add(dr.GetString("Name"));
                    }
                    conn.Close();
                }
            }
        }

        //--------------------------------------------------------
        // POPULATE BRAND COMBOBOX
        //--------------------------------------------------------

        private void getBrand()
        {
            String connstring = System.Configuration.ConfigurationManager.ConnectionStrings["team06ConnectionString"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {

                string querybrand = "SELECT BrandName FROM supplier";

                using (MySqlCommand comm = new MySqlCommand(querybrand, conn))
                {
                    conn.Open();
                    MySqlDataReader dr;
                    dr = comm.ExecuteReader();
                    while (dr.Read())
                    {
                        prodbranddrop.Items.Add(dr.GetString("BrandName"));
                    }
                    conn.Close();
                }
            }
        }

        //--------------------------------------------------------
        // PRODUCT FORM SUBMIT
        //--------------------------------------------------------

        private void prodsubmit_Click(object sender, EventArgs e)
        {
            int supid = 0;
            int branchid = 0;
            int materialid = 0;
            String connstring = System.Configuration.ConfigurationManager.ConnectionStrings["team06ConnectionString"].ConnectionString;
            
        //--------------------------------------------------------
        // GT SUPPLIER ID
        //--------------------------------------------------------

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                string queryb = "SELECT idSupplier FROM supplier WHERE BrandName=" + "'" + prodbranddrop.Text + "';";
                using (MySqlCommand comm = new MySqlCommand(queryb, conn))
                {
                    conn.Open();
                    MySqlDataReader dr;
                    dr = comm.ExecuteReader();
                    while (dr.Read())
                    {
                        supid = dr.GetInt32(0);
                    }
                    conn.Close();
                }
            }
            
            //--------------------------------------------------------
            // GET STORE ID
            //--------------------------------------------------------
            
            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                string queryb = "SELECT idStore FROM store WHERE Name=" + "'" + prodinstoredrop.Text + "';";
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
            // GET MATERIAL ID
            //--------------------------------------------------------

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                string queryb = "SELECT idMaterial FROM material WHERE Name=" + "'" + prodmaterialdrop.Text + "';";
                using (MySqlCommand comm = new MySqlCommand(queryb, conn))
                {
                    conn.Open();
                    MySqlDataReader dr;
                    dr = comm.ExecuteReader();
                    while (dr.Read())
                    {
                        materialid = dr.GetInt32(0);
                    }
                    conn.Close();
                }
            }

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                string query = "BEGIN;" +
                                "INSERT INTO product (ProductName, Colour, Price, Supplier_idSupplier, Capacity, Weight, Type, Activity, Material_idMaterial)" +
                                "VALUES (@name, @colour, @price, @sup, @capacity, @weight, @type, @activity, @material);" +
                                "INSERT INTO stock (Quantity, Store_idStore, Product_idProduct)" +
                                "VALUES (@quantity, @storeid, LAST_INSERT_ID());" +
                                "COMMIT;";
                using (MySqlCommand comm = new MySqlCommand(query, conn))
                {
                    
                    comm.Parameters.AddWithValue("@name", prodnametxt.Text);
                    comm.Parameters.AddWithValue("@colour", prodcolourdrop.Text);
                    comm.Parameters.AddWithValue("@price", prodpricetxt.Text);
                    comm.Parameters.AddWithValue("@sup", supid);
                    comm.Parameters.AddWithValue("@capacity", prodcapacitytxt.Text);
                    comm.Parameters.AddWithValue("@weight", prodweighttxt.Text);
                    comm.Parameters.AddWithValue("@type", prodtypetxt.Text);
                    comm.Parameters.AddWithValue("@activity", prodactivitytxt.Text);
                    comm.Parameters.AddWithValue("@material", materialid);

                    comm.Parameters.AddWithValue("@quantity", Int32.Parse(prodstocktxt.Text));
                    comm.Parameters.AddWithValue("@storeid", branchid);

                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();

                    clear();
                    prodmsg.Text = "Successfully added an entry";
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
