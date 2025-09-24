using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Factory
{
	public class JewelFactory
	{
        public JewelFactory() { }
        public MsJewel CreateJewel(string jewelname, int brandId, int categoryId, int price, int releaseyear)
        {
            return new MsJewel
            {
                JewelName = jewelname,
                BrandId = brandId,
                CategoryId = categoryId,
                JewelPrice = price,
                JewelReleaseYear = releaseyear
            };
        }
    }
}