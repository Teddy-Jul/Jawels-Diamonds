using Project.Factory;
using Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Handler
{
    public class JewelHandler
    {
        JewelFactory jewelFactory = new JewelFactory();
        CartFactory cartFactory = new CartFactory();
        JewelRepository jewelRepository = new JewelRepository();

        public MsJewel GetJewelById(int id)
        {
            return jewelRepository.GetJewelById(id);
        }

        public Cart HandleAddToCart(int userId, int jewelId)
        {
            Cart newCart = cartFactory.CreateCart(userId, jewelId, 1);
            return jewelRepository.AddToCart(newCart);
        }

        public bool DeleteJewel(int jewelId)
        {
            return jewelRepository.DeleteJewel(jewelId);
        }

        public bool HandleAddJewel(string jewelname, int brandId, int categoryId, int price, int releaseyear)
        {
            MsJewel newJewel = jewelFactory.CreateJewel(jewelname, brandId, categoryId, price, releaseyear);
            return jewelRepository.AddJewel(newJewel);
        }

        public bool HandleUpdateJewel(int jewelId, string name, int brandId, int categoryId, int price, int year)
        {
            return jewelRepository.UpdateJewel(jewelId, name, brandId, categoryId, price, year);
        }

        public List<MsCategory> GetAllCategories()
        {
            return jewelRepository.GetAllCategories();
        }

        public List<MsBrand> GetAllBrands()
        {
            return jewelRepository.GetAllBrands();
        }
    }
}