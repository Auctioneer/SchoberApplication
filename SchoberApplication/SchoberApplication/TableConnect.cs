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
        //Hello this is a change

        public List<Address> getAllAddresses()
        {
            try
            {
                connection.Open();
                MySqlCommand command;
                MySqlDataReader data;
                string query = "SELECT * FROM address";
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
