using Project.Datasets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Repository
{
    public class DatasetRepository
    {
        Database1Entities1 db = new Database1Entities1();

        public List<TransactionHeader> GetSuccessfulTransactions()
        {
            return db.TransactionHeaders
                .Include("TransactionDetails.MsJewel") 
                .Where(th => th.TransactionStatus == "Done")
                .ToList();
        }
    }
}