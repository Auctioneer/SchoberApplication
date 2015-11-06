using System;
using System.Collections.Generic;

namespace SchoberApplication
{
    public class StoreSale
    {
        int quantity;
        decimal value;
        decimal total;
        DateTime dateOfSale;

        public StoreSale(int quantity, decimal value)
        {
            this.quantity = quantity;
            this.value = value;

            //Call method to calculate total
            calculateAddTotal();
        }

        //Overload for including date in sale
        public StoreSale(int quantity, decimal value, DateTime dateOfSale)
        {
            this.quantity = quantity;
            this.value = value;
            this.dateOfSale = dateOfSale;
        }

        public int getQuantity()
        {
            return quantity;
        }

        public decimal getValue()
        {
            return value;
        }

        //For getting the overall value of the sale
        private void calculateAddTotal()
        {
            this.total = quantity * value;
        }

        public decimal getTotal()
        {
            return total;
        }

    }
}