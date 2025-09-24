using Project.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Controller
{
    public class TransactionController
    {
        TransactionHandler handler = new TransactionHandler();

        public string Checkout(int userId, string paymentMethod)
        {
            return handler.Checkout(userId, paymentMethod);
        }
        public List<TransactionHeader> GetUnfinishedOrders()
        {
            return handler.GetUnfinishedOrders();
        }

        public void UpdateTransactionStatus(int transactionId, string newStatus)
        {
            handler.UpdateTransactionStatus(transactionId, newStatus);
        }
        public List<TransactionHeader> GetUserTransactions(int userId)
        {
            return handler.GetUserTransactions(userId);
        }
        public TransactionHeader GetUserTransactionById(int transactionId)
        {
            return handler.GetUserTransactionById(transactionId);
        }
    }
}