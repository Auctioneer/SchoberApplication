using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
//Add MySql Library
using MySql.Data.MySqlClient;
using SchoberApplication;

namespace ConnectCsharpToMysql
{
    class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "silva.computing.dundee.ac.uk";
            database = "14ac3d06";
            uid = "14ac3u06";
            password = "cba123";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }


        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                    default:
                        //         Console.WriteLine(ex.);
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public MySqlConnection getConnection()
        {
            return connection;
        }

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["id"] + "");
                    list[1].Add(dataReader["name"] + "");
                    list[2].Add(dataReader["age"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

       


        public List<StoreSale> chartStoresSales(int storeID)
        {
            try
            {
                connection.Open();
                MySqlCommand command;
                MySqlDataReader data;
                string query = "SELECT Quantity,Product_idProduct FROM sales WHERE Store_idStore = " + storeID;
                List<StoreSale> listOfSales = new List<StoreSale>();

                command = new MySqlCommand(query, connection);
                data = command.ExecuteReader();

                while (data.Read())
                {
                    int quantity = data.GetInt32("Quantity");
                    int productID = data.GetInt32("Product_idProduct");
                    //decimal value = getProductPrice(data.GetInt32("Product_idProduct"));
                    //StoreSale store = new StoreSale(quantity, value);
                    StoreSale store = new StoreSale();
                    store.setQuantity(quantity);
                    store.setProductId(productID);
                    listOfSales.Add(store);

                }
                connection.Close();
                foreach(StoreSale sale in listOfSales)
                {
                    decimal value = getProductPrice(sale.getProductID());
                    sale.setValue(value);
                }

                return listOfSales;



            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }


        }

        public List<StoreSale> chartMonthGross(int storeID)
        {
            try
            {
                connection.Open();
                MySqlCommand command;
                MySqlDataReader data;
                string query = "SELECT Quantity,Product_idProduct,Date FROM sales WHERE Date < CURDATE() AND Date > (CURDATE() - 30) AND Store_idStore =" + storeID;
                List<StoreSale> listOfSales = new List<StoreSale>();

                command = new MySqlCommand(query, connection);
                data = command.ExecuteReader();

                while (data.Read())
                {
                    int quantity = data.GetInt32("Quantity");
                    int productID = data.GetInt32("Product_idProduct");
                    //decimal value = getProductPrice(data.GetInt32("Product_idProduct"));
                    //StoreSale store = new StoreSale(quantity, value);
                    StoreSale store = new StoreSale();
                    store.setQuantity(quantity);
                    store.setProductId(productID);
                    listOfSales.Add(store);

                }
                connection.Close();
                foreach (StoreSale sale in listOfSales)
                {
                    decimal value = getProductPrice(sale.getProductID());
                    sale.setValue(value);
                }

                return listOfSales;



            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }


        }

        //Method to return every sale from every store
        public List<StoreRecord> chartStoresRecords(int choice)
        {
            try
            {
                connection.Open();
                MySqlCommand command;
                MySqlDataReader data;
                string query = "SELECT * FROM store";
                List<StoreRecord> listOfStores = new List<StoreRecord>();

                command = new MySqlCommand(query, connection);
                data = command.ExecuteReader();

                while (data.Read())
                {
                    int id = data.GetInt32("idStore");
                    String name = data.GetString("Name");

                    //decimal value = getProductPrice(data.GetInt32("Product_idProduct"));
                    StoreRecord store = new StoreRecord(id, name);
                    //store.setStoreSales(chartStoresSales(id));
                    //store.setCountry(getStoreCountry(id));
                    
                    listOfStores.Add(store);

                }
                connection.Close();

                if (choice == 0)
                {
                    foreach (StoreRecord singStore in listOfStores)
                    {
                        singStore.setStoreSales(chartStoresSales(singStore.getStoreID()));
                    }
                    foreach (StoreRecord singStore in listOfStores)
                    {
                        singStore.setCountry(getStoreCountry(singStore.getStoreID()));
                    }
                }
                else
                {

                    foreach (StoreRecord singStore in listOfStores)
                    {
                        singStore.setStoreSales(chartMonthGross(singStore.getStoreID()));
                    }
                    
                }

                return listOfStores;



            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }


        }

        public decimal getProductPrice(int productID)
        {
            connection.Open();
            string query = "SELECT Price FROM product where idProduct =" + productID;
            MySqlCommand command;
            MySqlDataReader data;
            decimal price = 0;

            command = new MySqlCommand(query, connection);

            data = command.ExecuteReader();

            try
            {
                while (data.Read())
                {
                    price = data.GetDecimal("Price");
                }
                connection.Close();
                return price;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return price;
            }
        }

        public String getStoreCountry(int storeID)
        {
            connection.Open();
            string query = "SELECT Address_idAddress FROM store where idStore =" + storeID;
            MySqlCommand command;
            MySqlDataReader data;
            int addressID=0;
            String country = "";

            command = new MySqlCommand(query, connection);

            data = command.ExecuteReader();

            try
            {
                while (data.Read())
                {
                    addressID = data.GetInt32("Address_idAddress");
                    //country = getCountryFromID(addressID);
                }
                connection.Close();
                country = getCountryFromID(addressID);
                return country;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return country;
            }
        }

        public String getCountryFromID(int addressID)
        {
            connection.Open();
            string query = "SELECT Country FROM address where idAddress =" + addressID;
            MySqlCommand command;
            MySqlDataReader data;
            String country = "";

            command = new MySqlCommand(query, connection);

            data = command.ExecuteReader();

            try
            {
                while (data.Read())
                {
                    country = data.GetString("Country");
                }
                connection.Close();
                return country;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return country;
            }
        }
    }
}
