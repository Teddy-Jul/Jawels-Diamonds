using Project.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Controller
{
    public class CartController
    {
        CartHandler cartHandler = new CartHandler();

        public List<Cart> GetCartItems(int userId) => cartHandler.GetCartItems(userId);

        public string UpdateCartItem(int userId, int jewelId, int quantity) => cartHandler.UpdateCartItem(userId, jewelId, quantity);

        public void RemoveCartItem(int userId, int jewelId) => cartHandler.RemoveCartItem(userId, jewelId);

        public void ClearCart(int userId) => cartHandler.ClearCart(userId);

        public void AddOrUpdateCartItem(int userId, int jewelId, int quantity) => cartHandler.AddOrUpdateCartItem(userId, jewelId, quantity);

        public string Checkout(int userId, string paymentMethod)
        {
            return cartHandler.Checkout(userId, paymentMethod);
        }
    }
}