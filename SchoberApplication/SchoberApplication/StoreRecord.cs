using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SchoberApplication
{

    class StoreRecord
    {
        //Name of store OR the country (this field can be used for both)
        String storeName;

        //List of sales
        List<StoreSale> saleList = new List<StoreSale>();

        //List of employee salaries
        List<decimal> salariesList = new List<decimal>();

        public StoreRecord(String storeName)
        {
            this.storeName = storeName;
        }

        public String getStoreName()
        {
            return storeName;
        }

        //Method to add sale to list of sales
        public void addSale(int quantity, decimal value)
        {
            saleList.Add(new StoreSale(quantity, value));
        }

        //Method to add salary to list of salaries
        public void addSalary(decimal salary)
        {
            salariesList.Add(salary);
        }

        //Method to get the accumulated total of every sale
        public decimal getTotalSales()
        {
            decimal runningProfitTotal = 0;

            //Loop through list and add each value to running total
            for (int i = 0; i < saleList.Count; i++)
            {
                runningProfitTotal = runningProfitTotal + saleList[i].getTotal();
            }

            return runningProfitTotal;
        }

        //Method to get the accumulated total of every employee salary
        public decimal getTotalSalaries()
        {
            decimal runningSalaryTotal = 0;

            //Loop through list and add each value to running total
            for (int i = 0; i < salariesList.Count; i++)
            {
                runningSalaryTotal = runningSalaryTotal + salariesList[i];
            }

            return runningSalaryTotal;
        }

    }
}
