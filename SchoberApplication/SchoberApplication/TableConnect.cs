using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectCsharpToMysql;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SchoberApplication
{
    class TableConnect : DBConnect
    {
        MySqlConnection connection;

        public TableConnect(MySqlConnection connection)
        {
            this.connection = connection;
        }

        public List<Address> getAllAddresses()
        {
            try
            {
                connection.Open();
                MySqlCommand command;
                MySqlDataReader data;

                string query = "BEGIN; CREATE OR REPLACE VIEW t AS SELECT * FROM address; SELECT * FROM t;";
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

        public List<Worker> getAllWorkers()
        {
            try
            {
                connection.Open();
                MySqlCommand command;
                MySqlDataReader data;

                string query = "BEGIN; CREATE OR REPLACE VIEW t AS SELECT * FROM worker; SELECT * FROM t;";
                List<Worker> listOfWorkers = new List<Worker>();

                command = new MySqlCommand(query, connection);
                data = command.ExecuteReader();

                //THIS NEEDS EXPANDING FOR CONTACT DETAILS
                while (data.Read())
                {
                    int workerID = data.GetInt32("WorkerId");
                    int storeID = data.GetInt32("Store_idStore");
                    int jobID = data.GetInt32("Job_idJob");
                    string forename = data.GetString("FirstName");
                    string surname = data.GetString("LastName");

                    Worker worker = new Worker(workerID, storeID, jobID, forename, surname);

                    listOfWorkers.Add(worker);

                }
                connection.Close();

                for (int i = 0; i < listOfWorkers.Count; i++)
                {
                    Salary addToWorker = getJobDetails(listOfWorkers[i].getJobID());
                    String storeName = getStoreName(listOfWorkers[i].getStoreID());
                    listOfWorkers[i].setJobName(addToWorker.getJobName());
                    listOfWorkers[i].setSalary(addToWorker.getSingleSalary());
                    listOfWorkers[i].setStoreName(storeName);
                }
                return listOfWorkers;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        //Get name based on jobID
        public Salary getJobDetails(int jobID)
        {
            Salary salaryToReturn = new Salary();

            try
            {
                connection.Open();
                MySqlCommand command;
                MySqlDataReader data;

                string query = "BEGIN; CREATE OR REPLACE VIEW t AS SELECT JobName, Salary FROM Job where idJob = " + jobID + "; SELECT * FROM t;";
                command = new MySqlCommand(query, connection);
                data = command.ExecuteReader();

                while (data.Read())
                {
                    String jobName = data.GetString("JobName");
                    decimal jobSalary = data.GetDecimal("Salary");

                    salaryToReturn.setJobName(jobName);
                    salaryToReturn.setSingleSalary(jobSalary);
                }
                connection.Close();

                return salaryToReturn;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        //Get store name based on ID
        public String getStoreName(int storeID)
        {
            connection.Open();
            string query = "BEGIN; CREATE OR REPLACE VIEW t AS SELECT Name FROM store where idStore =" + storeID + "; SELECT * FROM t;";
            MySqlCommand command;
            MySqlDataReader data;
            String store = "";

            command = new MySqlCommand(query, connection);

            data = command.ExecuteReader();

            try
            {
                while (data.Read())
                {
                    store = data.GetString("Name");
                }
                connection.Close();
                return store;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return store;
            }
        }

        public List<StoreRecord> getAllStores()
        {
            List<StoreRecord> storeRecordList = new List<StoreRecord>();




            return storeRecordList;
        }
    }
}
