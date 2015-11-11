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
        }

        private void Tables_Load(object sender, EventArgs e)
        {
            comboBoxSelectTable.SelectedIndex = 0;
            hideAllTables();
        }

        //Method to hide every table
        private void hideAllTables()
        {
            dgvAddress.Hide();
        }

        private void btnGetTable_Click(object sender, EventArgs e)
        {
            clearTables();

            String firstSelection = (String)comboBoxSelectTable.SelectedItem;

            switch (firstSelection)
            {
                case "Addresses":
                    getAddresses();
                    break;
                case "Employees":
                    getEmployees();
                    break;
            }
        }

        private void getEmployees()
        {
            //Get addresses from tableConnect
            workerList = tableConnection.getAllWorkers();

            //Add workers to table
            dgvAddress.ColumnCount = 7;
            dgvAddress.Columns[0].Name = "ID";
            dgvAddress.Columns[1].Name = "Forename";
            dgvAddress.Columns[2].Name = "Surname";
            dgvAddress.Columns[3].Name = "Store ID";
            dgvAddress.Columns[4].Name = "Job ID";
            dgvAddress.Columns[5].Name = "Job Name";
            dgvAddress.Columns[6].Name = "Salary";


            for (int i = 0; i < workerList.Count; i++)
            {
                string[] row = new string[] { workerList[i].getWorkerID().ToString(), workerList[i].getForename(), workerList[i].getSurname(), workerList[i].getStoreID().ToString(), workerList[i].getJobID().ToString(), workerList[i].getJobName(), workerList[i].getSalary().ToString() };
                dgvAddress.Rows.Add(row);
            }

            dgvAddress.Show();
        }

        //Method to get all the addresses from the database
        private void getAddresses()
        {
            //Get addresses from tableConnect
            addressList = tableConnection.getAllAddresses();

            //Add addresses to table
            dgvAddress.ColumnCount = 3;
            dgvAddress.Columns[0].Name = "ID";
            dgvAddress.Columns[1].Name = "Address Line 1";
            dgvAddress.Columns[2].Name = "Address Line 2";


            for (int i = 0; i < addressList.Count; i++)
            {
                string[] row = new string[] { addressList[i].getAddressID().ToString(), addressList[i].getAddressln1(), addressList[i].getAddressln2() };
                dgvAddress.Rows.Add(row);
            }

            dgvAddress.Show();

            
        }

        //Method to clear all data from all tables, just in case
        private void clearTables()
        {
            dgvAddress.Rows.Clear();
            //dgvEmployee.Rows.Clear();
        }
    }
}
