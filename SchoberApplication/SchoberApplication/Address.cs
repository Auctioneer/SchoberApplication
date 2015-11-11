using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoberApplication
{
    class Address
    {
        private int addressID;
        private string addressln1;
        private string addressln2;
        private string postCode;
        private string region;
        private string country;

        public Address()
        {

        }

        public Address(int addressID, string addressln1, string addressln2, string postCode, string region, string country)
        {
            this.addressID = addressID;
            this.addressln1 = addressln1;
            this.addressln2 = addressln2;
            this.postCode = postCode;
            this.region = region;
            this.country = country;
        }

        public void setAddressID(int addressID)
        {
            this.addressID = addressID;
        }

        public void setAddressln1(string addressln1)
        {
            this.addressln1 = addressln1;
        }

        public void setAddressln2(string addressln2)
        {
            this.addressln2 = addressln2;
        }

        public void setPostCode(string postCode)
        {
            this.postCode = postCode;
        }

        public void setRegion(string region)
        {
            this.region = region;
        }

        public void setCountry(string country)
        {
            this.country = country;
        }

        public int getAddressID()
        {
            return addressID;
        }

        public string getAddressln1()
        {
            return addressln1;
        }

        public string getAddressln2()
        {
            return addressln2;
        }

        public string getRegion()
        {
            return region;
        }

        public string getCountry()
        {
            return country;
        }

        public string getPostcode()
        {
            return postCode;
        }
    }
}
