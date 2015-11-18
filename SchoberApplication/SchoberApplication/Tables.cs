using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SchoberApplication
{
    public partial class Tables : Form
    {
        //To show current table selection
        String whatTable = "";

        //Adapters and data table
        MySqlDataAdapter da;
        MySqlCommandBuilder cb;
        DataTable table;

        //DBConnect dbConnect = new DBConnect();
        TableConnect tableConnection;
        
        public Tables()
        {
            tableConnection = new TableConnect();
            InitializeComponent();
            comboBoxSelectTable.SelectedIndex = 0;
        }

        private void Tables_Load(object sender, EventArgs e)
        {
            dgvTable.Hide();
        }

        private void btnGetTable_Click(object sender, EventArgs e)
        {
            String firstSelection = (String)comboBoxSelectTable.SelectedItem;

            //Perform functions to columns based on selection
            switch (firstSelection)
            {
                case "Addresses":
                    whatTable = "address";
                    getTable();
                    dgvTable.Columns["idAddress"].ReadOnly = true;
                    break;

                case "Employees":
                    whatTable = "worker";
                    getTable();
                    dgvTable.Columns["Address_idAddress"].Visible = false;
                    dgvTable.Columns["Store_idStore"].Visible = false;
                    dgvTable.Columns["Job_idJob"].Visible = false;
                    dgvTable.Columns["Store Name"].ReadOnly = true;
                    dgvTable.Columns["Job Name"].ReadOnly = true;
                    dgvTable.Columns["SystemLogin_idSystemLogin"].Visible = false;
                    break;

                case "Stores":
                    whatTable = "store";
                    getTable();
                    dgvTable.Columns["idStore"].ReadOnly = true;
                    dgvTable.Columns["Address_idAddress"].ReadOnly = true;
                    break;

                case "Products":
                    whatTable = "product";
                    getTable();
                    dgvTable.Columns["idProduct"].ReadOnly = true;
                    dgvTable.Columns["Supplier_idSupplier"].Visible = false;
                    dgvTable.Columns["Material_idMaterial"].Visible = false;
                    dgvTable.Columns["Material Name"].ReadOnly = true;
                    break;

                case "Jobs":
                    whatTable = "job";
                    getTable();
                    dgvTable.Columns["idJob"].ReadOnly = true;
                    break;
                case "Sales":
                    whatTable = "sales";
                    getTable();
                    dgvTable.Columns["idSales"].ReadOnly = true;
                    break;
            }
        }

        //Method to return the information of the table by querying the database
        public void getTable()
        {
            //Create connection
            String connstring = System.Configuration.ConfigurationManager.ConnectionStrings["team06ConnectionString"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connstring);
            MySqlCommand command;
            string query = "";

            //Make query based on selected table
            if (whatTable.Equals("product"))
            {
                //query = "CREATE OR REPLACE VIEW t AS SELECT product.*,material.Name AS 'Material Name' from product inner join material on product.Material_idMaterial = material.idMaterial; SELECT * FROM t";
                query = "getProduct";
            }
            else if (whatTable.Equals("store"))
            {
                //query = "CREATE OR REPLACE VIEW t AS SELECT * FROM store inner join address on store.Address_idAddress = address.idAddress; SELECT * FROM t";
                query = "getStore";
            }
            else if (whatTable.Equals("worker"))
            {
                //query = "CREATE OR REPLACE VIEW t AS SELECT worker.*, store.Name AS 'Store Name', job.JobName AS 'Job Name' FROM  worker, store, job WHERE worker.Store_idStore = store.idStore AND worker.Job_idJob = job.idJob; SELECT * FROM t";
                query = "getWorker";
            }
            else if (whatTable.Equals("address"))
            {
                query = "getAddress";
            }
            else if (whatTable.Equals("job"))
            {
                query = "getJob";
            }
            else
            {
                query = "getSales";
            }
 
            //Fill the datagridview with the data returned
            command = new MySqlCommand(query, conn);
            command.CommandType = CommandType.StoredProcedure;

            da = new MySqlDataAdapter();
            da.SelectCommand = command;
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

            int rowsUpdated = da.Update(dt);

            MessageBox.Show("Update successful.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //TEST METHOD - To delete the selected row in address
            if (whatTable.Equals("address") || (whatTable.Equals("sales")))
            {
                foreach (DataGridViewRow item in this.dgvTable.SelectedRows)
                {
                    dgvTable.Rows.RemoveAt(item.Index);
                }

                //Updates table based on selection
                dgvTable.EndEdit();

                DataTable dt = (DataTable)dgvTable.DataSource;

                DataTable changedTable = dt.GetChanges();

                int rowsUpdated = da.Update(dt);

                MessageBox.Show("Delete successful.");


            }
        }
         
        }
    }

