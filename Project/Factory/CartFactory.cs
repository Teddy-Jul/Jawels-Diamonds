using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Factory
{
	public class CartFactory
	{
        public CartFactory() { }
        public Cart CreateCart(int userId, int jewelId, int quantity)
        {
            return new Cart
            {
                UserId = userId,
                JewelId = jewelId,
                Quantity = quantity
            };
        }
    }
}