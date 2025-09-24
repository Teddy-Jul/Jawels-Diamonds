using Project.Factory;
using Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Handler
{
    public class CartHandler
    {
        CartRepository cartRepository = new CartRepository();
        TransactionHeaderFactory headerFactory = new TransactionHeaderFactory();
        TransactionDetailFactory detailFactory = new TransactionDetailFactory();

        public List<Cart> GetCartItems(int userId) => cartRepository.GetCartItems(userId);

        public string UpdateCartItem(int userId, int jewelId, int quantity)
        {
            if (quantity <= 0) return "Quantity must be greater than 0.";
            return cartRepository.UpdateCartItem(userId, jewelId, quantity) ? "Success" : "Failed to update item.";
        }

        public void RemoveCartItem(int userId, int jewelId) => cartRepository.RemoveCartItem(userId, jewelId);

        public void ClearCart(int userId) => cartRepository.ClearCart(userId);

        public void AddOrUpdateCartItem(int userId, int jewelId, int quantity) => cartRepository.AddOrUpdateCartItem(userId, jewelId, quantity);

        public string Checkout(int userId, string paymentMethod)
        {
            var cartItems = cartRepository.GetCartItems(userId);
            if (cartItems == null || !cartItems.Any())
                return "Cart is empty.";

            var header = headerFactory.Create(userId, paymentMethod);

            var details = cartItems
                .Select(item => detailFactory.Create(0, item.JewelId, item.Quantity))
                .ToList();

            return cartRepository.Checkout(header, details, cartItems);
        }
    }
}