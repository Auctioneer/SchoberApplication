using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoberApplication
{
    class Products
    {
        private int productID;
        private string activity;
        private string type;

        public Products()
        {

        }

        public Products(int productID, string activity, string type)
        {
            this.productID = productID;
            this.activity = activity;
            this.type = type;
        }

        public void setProductID(int productID)
        {
            this.productID = productID;
        }

        public void setActivity(string activity)
        {
            this.activity = activity;
        }

        public void setType(string type)
        {
            this.type = type;
        }

        public int getProductID()
        {
            return productID;
        }

        public string getActivity()
        {
            return activity;
        }

        public string getType()
        {
            return type;
        }


    }
}
