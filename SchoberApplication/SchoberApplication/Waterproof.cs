using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoberApplication
{
    class Waterproof
    {

        String country;
        int waterproofCount;
        int nonWaterproofCount;
        float percentageW;
        float percentageN;

        public Waterproof()
        {
            waterproofCount = 0;
            nonWaterproofCount = 0;
        }

        public Waterproof(String country)
        {
            this.country = country;
            waterproofCount = 0;
            nonWaterproofCount = 0;
        }

        public void addWaterproof(int quantity)
        {
            waterproofCount = waterproofCount + quantity;
        }

        public void addNonWaterproof(int quantity)
        {
            nonWaterproofCount = nonWaterproofCount + quantity;
        }

        public String getCountry()
        {
            return country;
        }

        public int getWaterproofCount()
        {
            return waterproofCount;
        }

        public int getNonWaterproofCount()
        {
            return nonWaterproofCount;
        }

        public void calculatePercentages()
        {
            float total = (float)waterproofCount + (float)nonWaterproofCount;
            percentageW = waterproofCount / total * 100;
            percentageN = nonWaterproofCount / total * 100;
        }

        public float getPercentageN()
        {
            return percentageN;
        }

        public float getPercentageW()
        {
            return percentageW;
        }
    }
}
