using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectCsharpToMysql;

namespace SchoberApplication
{
    public partial class Tables : Form
    {
        String whatTable = "";

        DBConnect dbConnect = new DBConnect();
        TableConnect tableConnection;
        
        //These variables have to be in the class and not the method
        //As we'll need to use them to send data back to the database
        List<Address> addressList = new List<Address>();
        List<Worker> workerList = new List<Worker>();


        public Tables()
        {
            tableConnection = new TableConnect(dbConnect.getConnection());
            InitializeComponent();
            comboBoxSelectTable.SelectedIndex = 0;
        }

        private void Tables_Load(object sender, EventArgs e)
        {
            hideAllTables();
        }

        //Method to hide every table
        private void hideAllTables()
        {
            dgvTable.Hide();
        }

        private void btnGetTable_Click(object sender, EventArgs e)
        {
            clearTables();

            String firstSelection = (String)comboBoxSelectTable.SelectedItem;

            switch (firstSelection)
            {
                case "Addresses":
                    whatTable = "Address";
                    getAddresses();
                    break;
                case "Employees":
                    whatTable = "Employee";
                    getEmployees();
                    break;
            }
        }

        private void getEmployees()
        {
            //Get addresses from tableConnect
            workerList = tableConnection.getAllWorkers();

            //Add workers to table
            dgvTable.ColumnCount = 8;
            dgvTable.Columns[0].Name = "ID";
            dgvTable.Columns[1].Name = "Forename";
            dgvTable.Columns[2].Name = "Surname";
            dgvTable.Columns[3].Name = "Store ID";
            dgvTable.Columns[4].Name = "Store Name";
            dgvTable.Columns[5].Name = "Job ID";
            dgvTable.Columns[6].Name = "Job Name";
            dgvTable.Columns[7].Name = "Salary (£)";


            for (int i = 0; i < workerList.Count; i++)
            {
                string[] row = new string[] { workerList[i].getWorkerID().ToString(), workerList[i].getForename(), workerList[i].getSurname(), workerList[i].getStoreID().ToString(), workerList[i].getStoreName(), workerList[i].getJobID().ToString(), workerList[i].getJobName(), workerList[i].getSalary().ToString() };
                dgvTable.Rows.Add(row);
            }

            dgvTable.Show();
        }

        //Method to get all the addresses from the database
        private void getAddresses()
        {
            //Get addresses from tableConnect
            addressList = tableConnection.getAllAddresses();

            //Add addresses to table
            dgvTable.ColumnCount = 6;
            dgvTable.Columns[0].Name = "ID";
            dgvTable.Columns[1].Name = "Address Line 1";
            dgvTable.Columns[2].Name = "Address Line 2";
            dgvTable.Columns[3].Name = "Postcode";
            dgvTable.Columns[4].Name = "Region";
            dgvTable.Columns[5].Name = "Country";


            for (int i = 0; i < addressList.Count; i++)
            {
                string[] row = new string[] { addressList[i].getAddressID().ToString(), addressList[i].getAddressln1(), addressList[i].getAddressln2(), addressList[i].getPostcode(), addressList[i].getRegion(), addressList[i].getCountry() };
                dgvTable.Rows.Add(row);
            }

            dgvTable.Show();

        }

        //Method to clear all data from all tables, just in case
        private void clearTables()
        {
            dgvTable.Rows.Clear();
        }






    }
}
