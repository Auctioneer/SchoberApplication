using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoberApplication
{
    class Salary
    {
        int storeID;
        List<decimal> salary;

        //For getting job data for tables
        decimal singSalary;
        String jobName;

        public Salary()
        {

        }

        //For storing info for tables
        public void setJobName(String jobName)
        {
            this.jobName = jobName;
        }

        public void setSingleSalary(decimal singSalary)
        {
            this.singSalary = singSalary;
        }

        public String getJobName()
        {
            return jobName;
        }

        public decimal getSingleSalary()
        {
            return singSalary;
        }
        //End


        public Salary(int storeID, decimal singleSalary)
        {
            this.storeID = storeID;
            salary = new List<decimal>();
            salary.Add(singleSalary);
        }

        public void addSalary(decimal singleSalary)
        {
            salary.Add(singleSalary);
        }

        public int getStoreID()
        {
            return storeID;
        }

        public decimal getTotalSalaries()
        {
            decimal total = 0;

            for (int i = 0; i < salary.Count; i++)
            {
                total = total + salary[i];
            }

            return total;
        }

    }
}
