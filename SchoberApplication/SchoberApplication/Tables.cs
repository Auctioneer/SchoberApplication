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
            String firstSelection = (String)comboBoxSelectTable.SelectedItem;

            switch (firstSelection)
            {
                case "Addresses":
                    getAddresses();
                    break;
            }
        }

        //Method to get all the addresses from the database
        private void getAddresses()
        {
            //Get addresses from tableConnect
            addressList = tableConnection.getAllAddresses();

            
        }
    }
}
