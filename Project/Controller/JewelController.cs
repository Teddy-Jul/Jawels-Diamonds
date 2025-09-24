using Project.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace Project.Controller
{
    public class JewelController
    {
        JewelHandler JewelHandler = new JewelHandler();

        public string AddJewel(string jewelname, int brandId, int categoryId, int price, int releaseyear)
        {
            if (string.IsNullOrWhiteSpace(jewelname) || jewelname.Length < 3 || jewelname.Length > 25)
                return "Jewel Name must be between 3 and 25 characters.";

            if (categoryId <= 0)
                return "Please select a valid category.";

            if (brandId <= 0)
                return "Please select a valid brand.";

            if (price <= 25)
                return "Price must be a number greater than $25.";

            if (releaseyear >= DateTime.Now.Year)
                return "Release Year must be less than the current year.";

            bool success = JewelHandler.HandleAddJewel(jewelname, brandId, categoryId, price, releaseyear);
            if (success)
                return "Jewel added successfully.";
            else
                return "Failed to add jewel. Please try again.";
        }

        public MsJewel GetJewelById(int id)
        {
            return JewelHandler.GetJewelById(id);
        }

        public bool AddToCart(int userId, int jewelId)
        {
            var cart = JewelHandler.HandleAddToCart(userId, jewelId);
            return cart != null;
        }

        public bool DeleteJewel(int jewelId)
        {
            return JewelHandler.DeleteJewel(jewelId);
        }

        public string UpdateJewel(int jewelId, string name, int brandId, int categoryId, int price, int year)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 3 || name.Length > 25)
                return "Jewel Name must be between 3 and 25 characters.";
            if (categoryId <= 0)
                return "Please select a valid category.";
            if (brandId <= 0)
                return "Please select a valid brand.";
            if (price <= 25)
                return "Price must be a number greater than $25.";
            if (year >= DateTime.Now.Year)
                return "Release Year must be less than the current year.";

            bool success = JewelHandler.HandleUpdateJewel(jewelId, name, brandId, categoryId, price, year);
            return success ? "Jewel updated successfully." : "Failed to update jewel.";
        }

        public List<MsCategory> GetAllCategories()
        {
            return JewelHandler.GetAllCategories();
        }

        public List<MsBrand> GetAllBrands()
        {
            return JewelHandler.GetAllBrands();
        }
    }
}