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
                using (MySqlCommand comm = new MySqlCommand("storename", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;

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
                using (MySqlCommand comm = new MySqlCommand("getmaterialname", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;

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
                using (MySqlCommand comm = new MySqlCommand("getbrandname", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;
                    
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
                using (MySqlCommand comm = new MySqlCommand("getsuppid", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@bname", prodbranddrop.Text);
                    
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
                using (MySqlCommand comm = new MySqlCommand("getstoreid", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@store", prodinstoredrop.Text);

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
                using (MySqlCommand comm = new MySqlCommand("getmaterialid", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@mat", prodmaterialdrop.Text);
                    
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
                /*string query = "BEGIN;" +
                                "INSERT INTO product (ProductName, Colour, Price, Supplier_idSupplier, Capacity, Weight, Type, Activity, Material_idMaterial)" +
                                "VALUES (@name, @colour, @price, @sup, @capacity, @weight, @type, @activity, @material);" +
                                "INSERT INTO stock (Quantity, Store_idStore, Product_idProduct)" +
                                "VALUES (@quantity, @storeid, LAST_INSERT_ID());" +
                                "COMMIT;";*/
                using (MySqlCommand comm = new MySqlCommand("insertproduct", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;
                    
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
