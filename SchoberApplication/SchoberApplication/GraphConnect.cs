﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace SchoberApplication
{
    class GraphConnect
    {
        String connstring = System.Configuration.ConfigurationManager.ConnectionStrings["team06ConnectionString"].ConnectionString;
        MySqlConnection connection;

        public GraphConnect()
        {
            this.connection = new MySqlConnection(connstring);
        }

        public List<StoreSale> chartStoresSales(int storeID)
        {
            try
            {
                connection.Open();
                MySqlCommand command;
                MySqlDataReader data;

                //string query = "SELECT Quantity,Product_idProduct FROM sales WHERE Store_idStore = " + storeID;
                string query = "chartStoreSales";
                List<StoreSale> listOfSales = new List<StoreSale>();

                command = new MySqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@storeId", storeID);
                data = command.ExecuteReader();

                while (data.Read())
                {
                    int quantity = data.GetInt32("Quantity");
                    int productID = data.GetInt32("Product_idProduct");
                    decimal value = data.GetDecimal("Price");
                    string type = data.GetString("Type");
                    string activity = data.GetString("Activity");
                    //decimal value = getProductPrice(data.GetInt32("Product_idProduct"));
                    //StoreSale store = new StoreSale(quantity, value);
                    StoreSale store = new StoreSale();
                    store.setQuantity(quantity);
                    store.setProductId(productID);
                    store.setValue(value);
                    store.setType(type);
                    store.setActivity(activity);
                    listOfSales.Add(store);

                }
                connection.Close();
                /* foreach (StoreSale sale in listOfSales)
                 {
                     decimal value = getProductPrice(sale.getProductID());
                     string type = getProductType(sale.getProductID());
                     string activity = getProductActivity(sale.getProductID());
                     sale.setValue(value);
                     sale.setType(type);
                     sale.setActivity(activity);
                 }*/


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
                //string query = "SELECT Quantity,Product_idProduct,Date FROM sales WHERE Date < CURDATE() AND Date > (CURDATE() - 30) AND Store_idStore =" + storeID + ";";
                string query = "chartMonthGross";
                List<StoreSale> listOfSales = new List<StoreSale>();

                command = new MySqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@storeId", storeID);
                data = command.ExecuteReader();

                while (data.Read())
                {
                    int quantity = data.GetInt32("Quantity");
                    int productID = data.GetInt32("Product_idProduct");
                    decimal value = data.GetDecimal("Price");
                    //decimal value = getProductPrice(data.GetInt32("Product_idProduct"));
                    //StoreSale store = new StoreSale(quantity, value);
                    StoreSale store = new StoreSale();
                    store.setQuantity(quantity);
                    store.setProductId(productID);
                    store.setValue(value);
                    listOfSales.Add(store);

                }
                connection.Close();
                /*foreach (StoreSale sale in listOfSales)
                {
                    decimal value = getProductPrice(sale.getProductID());
                    sale.setValue(value);
                }*/

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

                else if (choice == 1)
                {
                    foreach (StoreRecord singStore in listOfStores)
                    {
                        singStore.setStoreSales(getWaterPData(singStore.getStoreID()));
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
            string query = "SELECT Price FROM product where idProduct =" + productID + ";";
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
            string query = "SELECT Address_idAddress FROM store where idStore =" + storeID + ";";
            MySqlCommand command;
            MySqlDataReader data;
            int addressID = 0;
            String country = "";

            command = new MySqlCommand(query, connection);

            data = command.ExecuteReader();

            try
            {
                while (data.Read())
                {
                    addressID = data.GetInt32("Address_idAddress");
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
            string query = "SELECT Country FROM address where idAddress =" + addressID + ";";
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

        public List<Worker> chartWorkersSalaries()
        {
            try
            {
                connection.Open();
                MySqlCommand command;
                MySqlDataReader data;
                string query = "SELECT WorkerId,Store_idStore,Job_idJob FROM worker;";
                List<Worker> listOfWorkers = new List<Worker>();

                command = new MySqlCommand(query, connection);
                data = command.ExecuteReader();

                while (data.Read())
                {
                    int workerID = data.GetInt32("WorkerId");
                    int storeID = data.GetInt32("Store_idStore");
                    int jobID = data.GetInt32("Job_idJob");

                    Worker worker = new Worker();
                    worker.setWorkerID(workerID);
                    worker.setStoreID(storeID);
                    worker.setJobID(jobID);
                    listOfWorkers.Add(worker);

                }
                connection.Close();
                foreach (Worker wrkr in listOfWorkers)
                {
                    decimal salary = getWorkerSalary(wrkr.getJobID());
                    wrkr.setSalary(salary);
                }

                return listOfWorkers;



            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }


        }

        public string getProductType(int productID)
        {
            connection.Open();
            string query = "SELECT Type FROM product where idProduct =" + productID + ";";
            MySqlCommand command;
            MySqlDataReader data;
            string type = "";

            command = new MySqlCommand(query, connection);

            data = command.ExecuteReader();

            try
            {
                while (data.Read())
                {
                    type = data.GetString("Type");
                }
                connection.Close();
                return type;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return type;
            }
        }

        public string getProductActivity(int productID)
        {
            connection.Open();
            string query = "SELECT Activity FROM product where idProduct =" + productID + ";";
            MySqlCommand command;
            MySqlDataReader data;
            string activity = "";

            command = new MySqlCommand(query, connection);

            data = command.ExecuteReader();

            try
            {
                while (data.Read())
                {
                    activity = data.GetString("Activity");
                }
                connection.Close();
                return activity;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return activity;
            }
        }

        public decimal getWorkerSalary(int jobID)
        {
            connection.Open();
            string query = "SELECT Salary FROM job where idJob =" + jobID + ";";
            MySqlCommand command;
            MySqlDataReader data;
            decimal salary = 0;

            command = new MySqlCommand(query, connection);

            data = command.ExecuteReader();

            try
            {
                while (data.Read())
                {
                    salary = data.GetDecimal("Salary");
                }
                connection.Close();
                return salary;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return salary;
            }
        }

        public List<StoreSale> getWaterPData(int storeID)
        {
            try
            {
                connection.Open();
                MySqlCommand command;
                MySqlDataReader data;
                // string query = "SELECT Quantity,Product_idProduct FROM sales WHERE Store_idStore =" + storeID + ";";
                string query = "getWaterPData";
                List<StoreSale> listOfSales = new List<StoreSale>();

                command = new MySqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@storeId", storeID);
                data = command.ExecuteReader();

                while (data.Read())
                {
                    int quantity = data.GetInt32("Quantity");
                    int productID = data.GetInt32("Product_idProduct");
                    bool waterproof = data.GetBoolean("Waterproof");
                    //decimal value = getProductPrice(data.GetInt32("Product_idProduct"));
                    //StoreSale store = new StoreSale(quantity, value);
                    StoreSale store = new StoreSale();
                    store.setQuantity(quantity);
                    store.setProductId(productID);
                    store.setWaterproof(waterproof);
                    listOfSales.Add(store);

                }
                connection.Close();
                /*foreach (StoreSale sale in listOfSales)
                {
                    int materialID = getMaterialID(sale.getProductID());
                    bool waterproof = getWaterProof(materialID);
                    sale.setWaterproof(waterproof);
                }*/

                return listOfSales;



            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }


        }

        public int getMaterialID(int productID)
        {
            connection.Open();
            string query = "SELECT Material_idMaterial from product where idProduct =" + productID + ";";
            MySqlCommand command;
            MySqlDataReader data;
            int materialID = 0;

            command = new MySqlCommand(query, connection);

            data = command.ExecuteReader();

            try
            {
                while (data.Read())
                {
                    materialID = data.GetInt32("Material_idMaterial");
                }
                connection.Close();
                return materialID;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return materialID;
            }
        }

        public bool getWaterProof(int materialID)
        {
            connection.Open();
            string query = "SELECT Waterproof FROM material where idMaterial =" + materialID + ";";
            MySqlCommand command;
            MySqlDataReader data;
            bool waterproof = false;

            command = new MySqlCommand(query, connection);

            data = command.ExecuteReader();

            try
            {
                while (data.Read())
                {
                    waterproof = data.GetBoolean("Waterproof");
                }
                connection.Close();
                return waterproof;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return waterproof;
            }
        }

        public List<Address> getAllAddresses()
        {
            try
            {
                connection.Open();
                MySqlCommand command;
                MySqlDataReader data;
                string query = "SELECT * FROM address;";
                List<Address> listOfAddresses = new List<Address>();

                command = new MySqlCommand(query, connection);
                data = command.ExecuteReader();

                while (data.Read())
                {
                    int addressID = data.GetInt32("idAddress");
                    string addressln1 = data.GetString("AddressLine1");
                    string addressln2 = data.GetString("AddressLine2");
                    string postCode = data.GetString("Postcode");
                    string region = data.GetString("Region");
                    string country = data.GetString("Country");
                    Address address = new Address(addressID, addressln1, addressln2, postCode, region, country);

                    listOfAddresses.Add(address);

                }
                connection.Close();

                return listOfAddresses;



            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }


        }

    }
}
