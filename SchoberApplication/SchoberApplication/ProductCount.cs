using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoberApplication
{
    class ProductCount
    {
        String productType;
        int quantity;

        public ProductCount()
        {
            quantity = 0;
        }

        public ProductCount(String productType)
        {
            this.productType = productType;
            quantity = 0;
        }

        public String getProductType()
        {
            return productType;
        }

        public int getQuantity()
        {
            return quantity;
        }

        public void addToQuantity(int q)
        {
            quantity = quantity + q;
        }

    }
}
