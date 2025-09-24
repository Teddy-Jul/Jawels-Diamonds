using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Factory
{
	public class TransactionDetailFactory
	{
        public TransactionDetail Create(int transactionId, int jewelId, int quantity)
        {
            return new TransactionDetail
            {
                TransactionId = transactionId,
                JewelId = jewelId,
                Quantity = quantity
            };
        }
    }
}