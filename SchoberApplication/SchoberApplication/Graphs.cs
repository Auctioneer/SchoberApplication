//HELLO, THIS IS THE REAL COPY OF THE SOLUTION

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Windows.Forms.DataVisualization.Charting;
using SchoberApplication;
using ConnectCsharpToMysql;

namespace SchoberApplication
{
    public partial class Graphs : Form
    {

        DBConnect dbConnect;

        public Graphs()
        {
            InitializeComponent();
             dbConnect = new DBConnect();
            //Charts should be hidden on form open
            hideCharts();
        }

        //Method to get each store's overall sales (entire sales record)
        public void getAllSales()
        {
            //Maybe also add a piece of info to a label to say what the overall money made is?

            //Clear all the series and just add the sales one
            chartSalariesIncome.Series.Clear();
            chartSalariesIncome.Series.Add("Sale Profits");

            //Set axis labels
            chartSalariesIncome.ChartAreas[0].AxisX.Title = "Store Name";
            chartSalariesIncome.ChartAreas[0].AxisY.Title = "Profit (£)";

            //For storing sales
            List<StoreRecord> storeRecordList = new List<StoreRecord>();

            //Set the list to the result of the SQL command getting all sales of all stores
            storeRecordList = dbConnect.chartStoresRecords();

            //TEST DATA
            //storeRecordList.Add(new StoreRecord("Alpine"));
            //storeRecordList.Add(new StoreRecord("Valley"));
            //storeRecordList.Add(new StoreRecord("Plateau"));

            //Here are some sales and some salaries for each store
            //Alpine
            //storeRecordList[0].addSale(6, 130.99m);
            //storeRecordList[0].addSale(3, 7.50m);
            //storeRecordList[0].addSale(2, 60m);

            //Valley
            //storeRecordList[1].addSale(2, 40m);
            //storeRecordList[1].addSale(10, 13.50m);
            //storeRecordList[1].addSale(4, 7.99m);
            //storeRecordList[1].addSale(7, 70m);

            //Plateau
            //storeRecordList[2].addSale(10, 10m);
            //storeRecordList[2].addSale(3, 35.66m);
            //storeRecordList[2].addSale(2, 100m);
            //storeRecordList[2].addSale(4, 20m);

            for (int i = 0; i < storeRecordList.Count; i++)
            {
                //Get totals for that store
                decimal salesTotal = storeRecordList[i].getTotalSales();

                //Display these on the chartSalariesIncome
                chartSalariesIncome.Series["Sale Profits"].Points.AddXY(storeRecordList[i].getStoreName(), salesTotal);
            }

            //Display
            chartSalariesIncome.Show();
        }



        //Method to compare the profits of the last thirty days to the store's expenditure on staff wages
        public void getThirtyDaysProfitsWages()
        {
            //List of records storing store name list of salaries, and list of sales records
            //This should be kept in the class as we need to use this list for different methods
            List<StoreRecord> storeRecordList = new List<StoreRecord>();

            //Add the two necessary series
            chartSalariesIncome.Series.Clear();
            chartSalariesIncome.Series.Add("Sale Profits");
            chartSalariesIncome.Series.Add("Monthly Wage Expenditure");

            //Set axis labels
            chartSalariesIncome.ChartAreas[0].AxisX.Title = "Store Name";
            chartSalariesIncome.ChartAreas[0].AxisY.Title = "Profit/Cost (£)";

            //TEST DATA
            //storeRecordList.Add(new StoreRecord("Alpine"));
            //storeRecordList.Add(new StoreRecord("Valley"));
            //storeRecordList.Add(new StoreRecord("Plateau"));

            //Here are some sales and some salaries for each store
            //Alpine
            //storeRecordList[0].addSale(6, 130.99m);
            //storeRecordList[0].addSale(3, 7.50m);
            //storeRecordList[0].addSale(2, 60m);
            //storeRecordList[0].addSalary(250m);
            //storeRecordList[0].addSalary(600m);
            //storeRecordList[0].addSalary(300m);

            //Valley
            //storeRecordList[1].addSale(2, 40m);
            //storeRecordList[1].addSale(10, 13.50m);
            //storeRecordList[1].addSale(4, 7.99m);
            //storeRecordList[1].addSale(7, 70m);
            //storeRecordList[1].addSalary(500m);

            //Plateau
            //storeRecordList[2].addSale(10, 10m);
            //storeRecordList[2].addSale(3, 35.66m);
            //storeRecordList[2].addSale(2, 100m);
            //storeRecordList[2].addSale(4, 20m);
            //storeRecordList[2].addSalary(250m);
            //storeRecordList[2].addSalary(100m);
            //storeRecordList[2].addSalary(150m);

            for (int i = 0; i < storeRecordList.Count; i++)
            {

                //Get totals for that store
                decimal salesTotal = storeRecordList[i].getTotalSales();
                decimal salariesTotal = storeRecordList[i].getTotalSalaries();

                //Display these on the chartSalariesIncome
                chartSalariesIncome.Series["Sale Profits"].Points.AddXY(storeRecordList[i].getStoreName(), salesTotal);
                chartSalariesIncome.Series["Monthly Wage Expenditure"].Points.AddXY(storeRecordList[i].getStoreName(), salariesTotal);

            }

            //Display
            chartSalariesIncome.Show();

        }

        //Method to get the sales of each country
        public void getSalesCountry()
        {
            //Clear and add series
            chartSalariesIncome.Series.Clear();
            chartSalariesIncome.Series.Add("Sale Profits");


            //For storing sales
            List<StoreRecord> storeRecordList = new List<StoreRecord>();

            //Set the list to the result of the SQL command getting all sales of all stores
            storeRecordList = dbConnect.chartStoresRecords();

            //TEST DATA
            //storeRecordList.Add(new StoreRecord("Austria"));
            //storeRecordList.Add(new StoreRecord("Scotland"));
            //storeRecordList.Add(new StoreRecord("Tibet"));

            //Here are some sales and some salaries for each store
            //Alpine
            //storeRecordList[0].addSale(6, 130.99m);
            //storeRecordList[0].addSale(3, 7.50m);
            //storeRecordList[0].addSale(2, 60m);

            //Valley
            //storeRecordList[1].addSale(2, 40m);
            //storeRecordList[1].addSale(10, 13.50m);
            //storeRecordList[1].addSale(4, 7.99m);
            //storeRecordList[1].addSale(7, 70m);

            //Plateau
            //storeRecordList[2].addSale(10, 10m);
            //storeRecordList[2].addSale(3, 35.66m);
            //storeRecordList[2].addSale(2, 100m);
            //storeRecordList[2].addSale(4, 20m);

            //This is a new list which will store each country's sales, not each store's
            List<StoreRecord> countrySortedStoreRecordList = new List<StoreRecord>();

            for (int i = 0; i < storeRecordList.Count; i++)
            {

                int pos = doesCountryExist(storeRecordList[i].getStoreCountry(), countrySortedStoreRecordList);
                
                if (pos < 0)
                {
                    countrySortedStoreRecordList.Add(storeRecordList[i]);
                }
                else
                {
                    countrySortedStoreRecordList[pos].addStoreSales(storeRecordList[i].getStoreSales());
                }
                
            }
                for (int i = 0; i < countrySortedStoreRecordList.Count; i++)
                {
                //Get totals for that store
                decimal salesTotal = countrySortedStoreRecordList[i].getTotalSales();

                //Display these on the chartSalariesIncome
                chartSalariesIncome.Series["Sale Profits"].Points.AddXY(countrySortedStoreRecordList[i].getStoreCountry(), salesTotal);
                }
            


            //Change chart type to doughnut chart
            chartSalariesIncome.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;

            //Display
            chartSalariesIncome.Show();


        }

        //Method to check whether country exists in new list of countries being compiled
        private int doesCountryExist(String targetCountry, List<StoreRecord>newList)
        {
            for (int i = 0; i < newList.Count; i++)
            {
                if (targetCountry.Equals(newList[i].getStoreCountry()))
                {
                    //Return position of country in new list if found
                    return i;
                }
            }
            //Return -1 if not
            return -1;
        }



        //When the user selects certain options, a secondary combobox should appear to refine the query
        private void comboBoxGraphMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TO DO
            //When query changes to get details of specific store, query database for list of store names
            //When query changes to get details of countries, query database for list of countries
        }

        //Button to start creating the visualisation based on the user's option
        private void btnRunQuery_Click(object sender, EventArgs e)
        {
            //Clear all the charts
            clearCharts();

            String firstSelection = (String)comboBoxGraphMain.SelectedItem;
            //String secondSelection = (String)comboBoxGraphSecondary.SelectedItem;
            //secondSelection = "Scotland";

            switch (firstSelection)
            {
                case "Get overall sales for each store":
                    getAllSales();
                    break;
                case "Get overall sales for each country":
                    getSalesCountry();
                    //getSalesCountry(secondSelection);
                    break;
                case "Compare sales of last 30 days to employee wage expenses":
                    getThirtyDaysProfitsWages();
                    break;
            }
        }

        //Method to clear every chart of data
        private void clearCharts()
        {
            foreach (var series in chartSalariesIncome.Series)
            {
                series.Points.Clear();
            }

        }

        //Method to hide all the charts from view
        //Should only be run at the beginning, unless there's a need for doing it again
        private void hideCharts()
        {
            chartSalariesIncome.Hide();
        }
    }
}
