using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace Project.Repository
{
    public class TransactionRepository
    {
        Database1Entities1 db = new Database1Entities1();

        public List<TransactionHeader> GetUnfinishedOrders()
        {
            return db.TransactionHeaders
                .Where(th => th.TransactionStatus != "Done" && th.TransactionStatus != "Rejected")
                .ToList();
        }

        public void UpdateTransactionStatus(int transactionId, string newStatus)
        {
            var header = db.TransactionHeaders.FirstOrDefault(th => th.TransactionId == transactionId);
            if (header != null)
            {
                header.TransactionStatus = newStatus;
                db.SaveChanges();
            }
        }
        public string Checkout(TransactionHeader header, List<TransactionDetail> details, List<Cart> cartItems)
        {
            db.TransactionHeaders.Add(header);
            db.SaveChanges();

            foreach (var detail in details)
            {
                detail.TransactionId = header.TransactionId;
                db.TransactionDetails.Add(detail);
            }

            foreach (var cart in cartItems)
            {
                var cartToRemove = db.Carts.FirstOrDefault(c => c.UserId == cart.UserId && c.JewelId == cart.JewelId);
                if (cartToRemove != null)
                {
                    db.Carts.Remove(cartToRemove);
                }
            }
            
            db.SaveChanges();

            return "Success";
        }
        public List<TransactionHeader> GetUserTransactions(int userId)
        {
            return db.TransactionHeaders
                .Where(th => th.UserId == userId)
                .OrderByDescending(th => th.TransactionDate)
                .ToList();
        }

        public TransactionHeader GetUserTransactionById(int transactionId)
        {
            return db.TransactionHeaders
                .Include(th => th.TransactionDetails.Select(td => td.MsJewel))
                .Include(th => th.MsUser)
                .FirstOrDefault(th => th.TransactionId == transactionId);
        }

    }
}