using System;
using System.Collections.Generic;

namespace SchoberApplication
{
    public class StoreSale
    {
        int quantity;
        int productID;
        decimal value;
        decimal total;
        DateTime dateOfSale;

        public StoreSale()
        {

        }

        public StoreSale(int quantity, decimal value)
        {
            this.quantity = quantity;
            this.value = value;
        }

        //Overload for including date in sale
        public StoreSale(int quantity, decimal value, DateTime dateOfSale)
        {
            this.quantity = quantity;
            this.value = value;
            this.dateOfSale = dateOfSale;
        }

        public void setQuantity(int quantity)
        {
            this.quantity = quantity;
        }

        public void setProductId(int productID)
        {
            this.productID = productID;
        }

        public void setValue(decimal value)
        {
            this.value = value;
        }

        public int getQuantity()
        {
            return quantity;
        }

        public int getProductID()
        {
            return productID;
        }

        public decimal getValue()
        {
            return value;
        }

        public decimal getTotal()
        {
            this.total = quantity * value;
            return total;
        }

    }
}