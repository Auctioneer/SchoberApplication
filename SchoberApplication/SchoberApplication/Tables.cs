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
using MySql.Data.MySqlClient;

namespace SchoberApplication
{
    public partial class Tables : Form
    {
        //To show current table selection
        String whatTable = "";

        MySqlDataAdapter da;
        MySqlCommandBuilder cb;
        DataTable table;

        DBConnect dbConnect = new DBConnect();
        TableConnect tableConnection;
        
        //These variables have to be in the class and not the method
        //As we'll need to use them to send data back to the database
        List<Address> addressList = new List<Address>();
        List<Worker> workerList = new List<Worker>();
        List<StoreRecord> storeList = new List<StoreRecord>();


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
            String firstSelection = (String)comboBoxSelectTable.SelectedItem;

            switch (firstSelection)
            {
                case "Addresses":
                    whatTable = "address";
                    getTable();
                    break;
                case "Employees":
                    whatTable = "worker";
                    getTable();
                    dgvTable.Columns["Address_idAddress"].Visible = false;
                    dgvTable.Columns["Store_idStore"].Visible = false;
                    dgvTable.Columns["Job_idJob"].Visible = false;
                    dgvTable.Columns["SystemLogin_idSystemLogin"].Visible = false;
                    break;
                case "Stores":
                    whatTable = "store";
                    getTable();
                    break;
                case "Products":
                    whatTable = "product";
                    getTable();
                    break;
            }
        }

        private void getStores()
        {
            storeList = tableConnection.getAllStores();
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

        public void getTable()
        {
            String connstring = System.Configuration.ConfigurationManager.ConnectionStrings["team06ConnectionString"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connstring);
            string query = "SELECT * FROM " + whatTable;
            da = new MySqlDataAdapter(query, conn);
            cb = new MySqlCommandBuilder(da);
            table = new DataTable();
            da.Fill(table);

            dgvTable.DataSource = table;
            dgvTable.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Updates table based on selection
            dgvTable.EndEdit();

            DataTable dt = (DataTable)dgvTable.DataSource;

            DataTable changedTable = dt.GetChanges();
            Console.WriteLine(changedTable.Rows.Count);

            int rowsUpdated = da.Update(dt);

            MessageBox.Show("Update successful.");
        }
        






    }
}
