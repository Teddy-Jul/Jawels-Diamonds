using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Repository
{
    public class JewelRepository
    {
        Database1Entities1 db = new Database1Entities1();

        public MsJewel GetJewelById(int id)
        {
            return db.MsJewels
                .Include("MsBrand")
                .Include("MsCategory")
                .FirstOrDefault(j => j.JewelId == id);
        }

        public Cart AddToCart(Cart cart)
        {
            var existingCart = db.Carts.FirstOrDefault(c => c.UserId == cart.UserId && c.JewelId == cart.JewelId);
            if (existingCart != null)
            {
                existingCart.Quantity += cart.Quantity;
                db.SaveChanges();
                return existingCart;
            }
            else
            {
                db.Carts.Add(cart);
                db.SaveChanges();
                return cart;
            }
        }

        public bool DeleteJewel(int jewelId)
        {
            var jewel = db.MsJewels.FirstOrDefault(j => j.JewelId == jewelId);
            if (jewel == null)
                return false;


            db.MsJewels.Remove(jewel);
            db.SaveChanges();
            return true;
        }

        public bool AddJewel(MsJewel jewel)
        {
            db.MsJewels.Add(jewel);
            db.SaveChanges();
            return true;
        }

        public bool UpdateJewel(int jewelId, string name, int brandId, int categoryId, int price, int year)
        {
            var jewel = db.MsJewels.FirstOrDefault(j => j.JewelId == jewelId);
            if (jewel == null)
                return false;

            jewel.JewelName = name;
            jewel.BrandId = brandId;
            jewel.CategoryId = categoryId;
            jewel.JewelPrice = price;
            jewel.JewelReleaseYear = year;

            db.SaveChanges();
            return true;
        }
        public List<MsCategory> GetAllCategories()
        {
            return db.MsCategories.ToList();
        }

        public List<MsBrand> GetAllBrands()
        {
            return db.MsBrands.ToList();
        }
    }
}