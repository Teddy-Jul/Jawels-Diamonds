using Project.Factory;
using Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Handler
{
    public class TransactionHandler
    {
        TransactionRepository transactionRepository = new TransactionRepository();
        TransactionHeaderFactory headerFactory = new TransactionHeaderFactory();
        TransactionDetailFactory detailFactory = new TransactionDetailFactory();
        CartRepository cartRepository = new CartRepository();

        public string Checkout(int userId, string paymentMethod)
        {
            var cartItems = cartRepository.GetCartItems(userId);
            if (cartItems == null || !cartItems.Any())
                return "Cart is empty.";

            var header = headerFactory.Create(userId, paymentMethod);

            var details = new List<TransactionDetail>();
            foreach (var item in cartItems)
            {
                var detail = detailFactory.Create(0, item.JewelId, item.Quantity);
                details.Add(detail);
            }

            return transactionRepository.Checkout(header, details, cartItems);
        }
        public List<TransactionHeader> GetUnfinishedOrders()
        {
            return transactionRepository.GetUnfinishedOrders();
        }

        public void UpdateTransactionStatus(int transactionId, string newStatus)
        {
            transactionRepository.UpdateTransactionStatus(transactionId, newStatus);
        }
        public List<TransactionHeader> GetUserTransactions(int userId)
        {
            return transactionRepository.GetUserTransactions(userId);
        }
        public TransactionHeader GetUserTransactionById(int transactionId)
        {
            return transactionRepository.GetUserTransactionById(transactionId);
        }
    }
}