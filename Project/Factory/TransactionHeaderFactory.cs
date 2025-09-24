using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Factory
{
	public class TransactionHeaderFactory
	{
        public TransactionHeader Create(int userId, string paymentMethod)
        {
            return new TransactionHeader
            {
                UserId = userId,
                TransactionDate = DateTime.Now,
                PaymentMethod = paymentMethod,
                TransactionStatus = "Payment Pending"
            };
        }
    }
}