using Project.Datasets;
using Project.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Controller
{
    public class DatasetController
    {
        DatasetHandler handler = new DatasetHandler();
        public List<TransactionHeader> GetSuccessfulTransactions()
        {
            return handler.GetSuccessfulTransactions();
        }
    }
}