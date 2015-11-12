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
        String forename;
        String surname;
        String jobName;
        String storeName;

        public Worker()
        {

        }

        public Worker(int workerID)
        {
            this.workerID = workerID;
        }

        public Worker(int workerID, int storeID, decimal workerSalary, int jobID)
        {
            this.workerID = workerID;
            this.storeID = storeID;
            this.workerSalary = workerSalary;
            this.jobID = jobID;
        }

        public Worker(int workerID, int storeID, int jobID, String forename, String surname)
        {
            this.forename = forename;
            this.surname = surname;
            this.workerID = workerID;
            this.storeID = storeID;
            this.jobID = jobID;
        }


        public decimal getSalary()
        {
            return workerSalary;
        }

        public void setStoreName(String storeName)
        {
            this.storeName = storeName;
        }

        public String getStoreName()
        {
            return storeName;
        }

        public String getJobName()
        {
            return jobName;
        }

        public int getStoreID()
        {
            return storeID;
        }

        public int getJobID()
        {
            return jobID;
        }

        public String getForename()
        {
            return forename;
        }

        public void setJobName(String jobName)
        {
            this.jobName = jobName;
        }

        public String getSurname()
        {
            return surname;
        }

        public void setForename(String forename)
        {
            this.forename = forename;
        }

        public void setSurname(String surname)
        {
            this.surname = surname;
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
