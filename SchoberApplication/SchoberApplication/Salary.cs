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

        public Salary()
        {

        }

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
