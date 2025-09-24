using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project.Repository
{
    public class CartRepository
    {
        Database1Entities1 db = new Database1Entities1();

        public List<Cart> GetCartItems(int userId)
        {
            return db.Carts
                .Where(c => c.UserId == userId)
                .Include("MsJewel.MsBrand")
                .ToList();
        }

        public bool UpdateCartItem(int userId, int jewelId, int quantity)
        {
            var cart = db.Carts.FirstOrDefault(c => c.UserId == userId && c.JewelId == jewelId);
            if (cart == null) return false;
            cart.Quantity = quantity;
            db.SaveChanges();
            return true;
        }

        public bool RemoveCartItem(int userId, int jewelId)
        {
            var cart = db.Carts.FirstOrDefault(c => c.UserId == userId && c.JewelId == jewelId);
            if (cart == null) return false;
            db.Carts.Remove(cart);
            db.SaveChanges();
            return true;
        }

        public bool ClearCart(int userId)
        {
            var carts = db.Carts.Where(c => c.UserId == userId).ToList();
            foreach (var cart in carts)
            {
                db.Carts.Remove(cart);
            }
            db.SaveChanges();
            return true;
        }

        public bool AddOrUpdateCartItem(int userId, int jewelId, int quantity)
        {
            var cart = db.Carts.FirstOrDefault(c => c.UserId == userId && c.JewelId == jewelId);
            if (cart != null)
            {
                cart.Quantity += quantity;
            }
            else
            {
                cart = new Cart { UserId = userId, JewelId = jewelId, Quantity = quantity };
                db.Carts.Add(cart);
            }
            db.SaveChanges();
            return true;
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
                var cartToRemove = db.Carts
                    .FirstOrDefault(c => c.UserId == cart.UserId && c.JewelId == cart.JewelId);
                if (cartToRemove != null)
                {
                    db.Carts.Remove(cartToRemove);
                }
            }
            db.SaveChanges();

            return "Success";
        }
    }
}