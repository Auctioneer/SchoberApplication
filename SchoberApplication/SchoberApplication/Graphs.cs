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
        GraphConnect graphConnect;

        public Graphs()
        {
            InitializeComponent();
            dbConnect = new DBConnect();
            graphConnect = new GraphConnect(dbConnect.getConnection());

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
            storeRecordList = graphConnect.chartStoresRecords(0);

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
            List<StoreRecord> storeRecordList = new List<StoreRecord>();
            List<Worker> workerList = new List<Worker>();

            //Add the two necessary series
            chartSalariesIncome.Series.Clear();
            chartSalariesIncome.Series.Add("Sale Profits");
            chartSalariesIncome.Series.Add("Monthly Wage Expenditure");

            //Set axis labels
            chartSalariesIncome.ChartAreas[0].AxisX.Title = "Store Name";
            chartSalariesIncome.ChartAreas[0].AxisY.Title = "Profit/Cost (£)";

            //When calling in chartStoresRecords, pass in a 2 (that means we'll get data for past 30 days only
            //Set the list to the result of the SQL command getting sales of all stores
            storeRecordList = graphConnect.chartStoresRecords(2);

            //Get list of worker details
            workerList = graphConnect.chartWorkersSalaries();

            //This is a new list which will store each store's salaries
            List<Salary> storeSalaryList = new List<Salary>();

            //Loop through the worker list
            for (int i = 0; i < workerList.Count; i++)
            {
                //Get the position of the new list on which to add items to, if the worker's store IDs match
                int pos = findStorePos(workerList[i].getStoreID(), storeSalaryList);

                //If pos is less than 0, the search returned no results
                //Therefore the entry to the salary list is a new entry
                if (pos < 0)
                {
                    Salary salaryToAdd = new Salary(workerList[i].getStoreID(), workerList[i].getSalary());
                    storeSalaryList.Add(salaryToAdd);
                }
                //Else, it returned a position in which the salaries are already stored
                //Therefore, to avoid duplicate country entries, we simply add the sales of the current entry to the new list's entry
                else
                {
                    storeSalaryList[pos].addSalary(workerList[i].getSalary());
                }

            }

            //Loop through stores
            for (int i = 0; i < storeRecordList.Count; i++)
            {
                //Get the relative position in the salary list of the salaries for the current store
                int pos = findStorePos(storeRecordList[i].getStoreID(), storeSalaryList);

                //Get totals for that store
                decimal salesTotal = storeRecordList[i].getTotalSales();
                chartSalariesIncome.Series["Sale Profits"].Points.AddXY(storeRecordList[i].getStoreName(), salesTotal);

                //Add total salaries for that store
                chartSalariesIncome.Series["Monthly Wage Expenditure"].Points.AddXY(storeRecordList[i].getStoreName(), storeSalaryList[pos].getTotalSalaries());

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
            storeRecordList = graphConnect.chartStoresRecords(0);

            //This is a new list which will store each country's sales, not each store's
            List<StoreRecord> countrySortedStoreRecordList = new List<StoreRecord>();

            //Loop through the old list
            for (int i = 0; i < storeRecordList.Count; i++)
            {
                //Get the position of the new list on which to add items to, if the countries match
                int pos = findCountryPos(storeRecordList[i].getStoreCountry(), countrySortedStoreRecordList);

                //If pos is less than 0, the search returned no results
                //Therefore the entry to the list is a new entry
                if (pos < 0)
                {
                    countrySortedStoreRecordList.Add(storeRecordList[i]);
                }
                //Else, it returned a position in which the country's sales are already stored
                //Therefore, to avoid duplicate country entries, we simply add the sales of the current entry to the new list's entry
                else
                {
                    countrySortedStoreRecordList[pos].addStoreSales(storeRecordList[i].getStoreSales());
                }

            }

            //Now we display the data of the new list
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
        private int findCountryPos(String targetCountry, List<StoreRecord> newList)
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

        //Method to check whether store exists in new list of stores being compiled, and if so at what position
        private int findStorePos(int targetID, List<Salary> salaryList)
        {
            for (int i = 0; i < salaryList.Count; i++)
            {
                if (targetID == salaryList[i].getStoreID())
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
                case "Compare overall sales for each store":
                    getAllSales();
                    break;
                case "Compare overall sales for each country":
                    getSalesCountry();
                    //getSalesCountry(secondSelection);
                    break;
                case "Compare sales of last 30 days to employee wage expenses":
                    getThirtyDaysProfitsWages();
                    break;
                case "Compare overall sales of each product type":
                    getProductTypeSales(0);
                    break;
                case "Compare overall sales of products' activity grouping":
                    getProductTypeSales(1);
                    break;
                case "Compare sales of waterproof vs. non-waterproof items for each country":
                    getWaterproofSales();
                    break;
            }
        }

        //Method to compare countries' sales of waterproof vs. non-waterproof items
        private void getWaterproofSales()
        {
            //New list to store country name and quantities of waterproof vs. non-waterproof
            List<Waterproof> waterproofCountry = new List<Waterproof>();

            //Clear and add series
            chartSalariesIncome.Series.Clear();
            chartSalariesIncome.Series.Add("Waterproof item sales");
            chartSalariesIncome.Series.Add("Non-waterproof item sales");

            //For storing sales
            List<StoreRecord> storeRecordList = new List<StoreRecord>();

            //Set the list to the result of the SQL command getting all sales of all stores
            storeRecordList = graphConnect.chartStoresRecords(1);

            //So now we have a list of all the records, and each sale has a waterproof bool in it

            //We get storerecord list of countries
            
            //This is a new list which will store each country's sales, not each store's
            List<StoreRecord> countrySortedStoreRecordList = new List<StoreRecord>();

            //Loop through the old list
            for (int i = 0; i < storeRecordList.Count; i++)
            {
                //Get the position of the new list on which to add items to, if the countries match
                int pos = findCountryPos(storeRecordList[i].getStoreCountry(), countrySortedStoreRecordList);

                //If pos is less than 0, the search returned no results
                //Therefore the entry to the list is a new entry
                if (pos < 0)
                {
                    countrySortedStoreRecordList.Add(storeRecordList[i]);
                }
                //Else, it returned a position in which the country's sales are already stored
                //Therefore, to avoid duplicate country entries, we simply add the sales of the current entry to the new list's entry
                else
                {
                    countrySortedStoreRecordList[pos].addStoreSales(storeRecordList[i].getStoreSales());
                }

            }

            //We loop through each storerecord
            //Loop through the new list
            for (int i = 0; i < countrySortedStoreRecordList.Count; i++)
            {
                //Make new Waterproof object with country in constructor
                Waterproof waterproofToAdd = new Waterproof(countrySortedStoreRecordList[i].getStoreCountry());
                waterproofCountry.Add(waterproofToAdd);

                //Loop through store sales in record
                List<StoreSale> currentSaleList = countrySortedStoreRecordList[i].getStoreSales();

                for (int j = 0; j < currentSaleList.Count; j++)
                {
                    //Add sales to Waterproof[j] passing in quantity and waterproof bool
                    waterproofCountry[i].addSale(currentSaleList[j].getQuantity(), currentSaleList[j].getWaterproof());
                }

                //Run method to calculate percentages now we have all the data
                waterproofCountry[i].calculatePercentages();
                
                //Display
                chartSalariesIncome.Series["Waterproof item sales"].Points.AddXY(waterproofCountry[i].getCountry(), waterproofCountry[i].getPercentageW());
                chartSalariesIncome.Series["Non-waterproof item sales"].Points.AddXY(waterproofCountry[i].getCountry(), waterproofCountry[i].getPercentageN());
            }

            //Change type to StackedColumn100
            chartSalariesIncome.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn100;
            chartSalariesIncome.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn100;


            //So we have a list of waterproof quantities stored under a country
            chartSalariesIncome.Show();

        }

        //Method to compare sales of each type of product
        private void getProductTypeSales(int TypeOrActivity)
        {
            //Clear and add series
            chartSalariesIncome.Series.Clear();
            chartSalariesIncome.Series.Add("Number of Sales");

            //Change chart type to pie chart
            chartSalariesIncome.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

            //For storing sales
            List<StoreRecord> storeRecordList = new List<StoreRecord>();

            //Set the list to the result of the SQL command getting all sales of all stores
            storeRecordList = graphConnect.chartStoresRecords(0);

            //Make list of product type and quantity
            List<ProductCount> productTypeQuantityList = new List<ProductCount>();

            //Loop through list of store records
            for (int i = 0; i < storeRecordList.Count; i++)
            {
                //Get list of sales from record
                List<StoreSale> currentSaleList = new List<StoreSale>(storeRecordList[i].getStoreSales());

                //Loop through sales
                for (int j = 0; j < currentSaleList.Count; j++)
                {
                    String currentType;

                    if (TypeOrActivity == 0)
                    {
                        currentType = currentSaleList[i].getType();
                    }
                    else
                    {
                        currentType = currentSaleList[i].getActivity();
                    }
                    int pos = findProductPos(currentType, productTypeQuantityList);

                    //If pos is less than 0, the search returned no results
                    //Therefore the entry to the list is a new entry
                    if (pos < 0)
                    {
                        ProductCount productToAdd = new ProductCount(currentType);
                        productToAdd.addToQuantity(currentSaleList[i].getQuantity());
                        productTypeQuantityList.Add(productToAdd);
                    }
                    //Else, it returned a position in which the country's sales are already stored
                    //Therefore, to avoid duplicate country entries, we simply add the sales of the current entry to the new list's entry
                    else
                    {
                        productTypeQuantityList[pos].addToQuantity(currentSaleList[i].getQuantity());
                    }

                }

            }

            //Now we display the data of the new list
            for (int i = 0; i < productTypeQuantityList.Count; i++)
            {
                //Get quantity for type
                decimal quantityTotal = productTypeQuantityList[i].getQuantity();

                //Display these on the chartSalariesIncome
                chartSalariesIncome.Series["Number of Sales"].Points.AddXY(productTypeQuantityList[i].getProductType(), quantityTotal);
            }

            chartSalariesIncome.Show();

        }

        private int findProductPos(String targetType, List<ProductCount> productCountList)
        {
            for (int i = 0; i < productCountList.Count; i++)
            {
                if (targetType.Equals(productCountList[i].getProductType()))
                {
                    //Return position of country in new list if found
                    return i;
                }

                if (targetType.Equals(productCountList[i].getProductType()))
                {
                    //Return position of country in new list if found
                    return i;
                }

            }
            //Return -1 if not
            return -1;
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
