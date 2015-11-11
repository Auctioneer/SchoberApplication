using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SchoberApplication
{

    class StoreRecord
    {
        //Name of store
        String storeName;

        //Country
        String storeCountry;

        //ID number
        int storeID;

        //Address
        Address storeAddress;

        //Contact number
        String contactNumber;

        //List of sales
        List<StoreSale> saleList = new List<StoreSale>();

        public StoreRecord(String storeName)
        {
            this.storeName = storeName;
        }

        public String getStoreCountry()
        {
            return storeCountry;
        }

        //The actual constructor, passing in ID and name
        public StoreRecord(int storeID, String storeName)
        {
            this.storeID = storeID;
            this.storeName = storeName;
        }

        public void setCountry(String storeCountry)
        {
            this.storeCountry = storeCountry;
        }

        public String getStoreName()
        {
            return storeName;
        }

        public int getStoreID()
        {
            return storeID;
        }

        public void setStoreSales(List<StoreSale> saleList)
        {
            this.saleList = saleList;
        }

        public List<StoreSale> getStoreSales()
        {
            return saleList;
        }

        public void addStoreSales(List<StoreSale> salesToAdd)
        {
            for (int i = 0; i < salesToAdd.Count; i++)
            {
                saleList.Add(salesToAdd[i]);
            }
                
        }

        //Method to add sale to list of sales
        //ONLY FOR TEST DATA - TO BE REMOVED
        public void addSale(int quantity, decimal value)
        {
            saleList.Add(new StoreSale(quantity, value));
        }

        public void setAddress(Address address)
        {
            this.storeAddress = address;
        }

        public Address getAddress()
        {
            return storeAddress;
        }

        public void setContactNumber(String contactNumber)
        {
            this.contactNumber = contactNumber;
        }

        public String getContactNumber()
        {
            return contactNumber;
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
      //  public decimal getTotalSalaries()
    //    {
    //        decimal runningSalaryTotal = 0;

            //Loop through list and add each value to running total
    //        for (int i = 0; i < salariesList.Count; i++)
    //        {
     //           runningSalaryTotal = runningSalaryTotal + salariesList[i];
    //        }

     //       return runningSalaryTotal;
    //    }

    }
}
