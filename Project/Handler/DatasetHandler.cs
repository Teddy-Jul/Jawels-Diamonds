using Project.Datasets;
using Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Handler
{
    public class DatasetHandler
    {
        DatasetRepository repo = new DatasetRepository();

        public List<TransactionHeader> GetSuccessfulTransactions()
        {
            return repo.GetSuccessfulTransactions();
        }
    }
}