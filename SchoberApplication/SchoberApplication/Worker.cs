using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoberApplication
{
    class Worker
    {
        decimal workerSalary;
        int workerID;
        int storeID;
        int jobID;
        //String forename;
        //String surname;

        public Worker()
        {

        }

        public Worker(int workerID)
        {
            this.workerID = workerID;
        }

        public Worker(int workerID, int storeID, decimal workerSalary,int jobID)
        {
            this.workerID = workerID;
            this.storeID = storeID;
            this.workerSalary = workerSalary;
            this.jobID = jobID;
        }

        public decimal getSalary()
        {
            return workerSalary;
        }

        public int getStoreID()
        {
            return storeID;
        }

        public int getJobID()
        {
            return jobID;
        }

        public void setJobID(int jobID)
        {
            this.jobID = jobID;
        }

        public void setSalary(decimal workerSalary)
        {
            this.workerSalary = workerSalary;
        }

        public void setStoreID(int storeID)
        {
            this.storeID = storeID;
        }

        public int getWorkerID()
        {
            return workerID;
        }

        public void setWorkerID(int workerID)
        {
            this.workerID = workerID;
        }

    }
}
