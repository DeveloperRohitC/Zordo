using System;
using System.Collections.Generic;
using System.Text;

namespace Zordo.Helper
{
    class BusinessLogic
    {
        ExceptionEmail email = new ExceptionEmail();
        public List<Shop> GetShopList()
        {
            List<Shop> shopList = new List<Shop>();
            try
            {
                shopList.Add(new Shop
                {
                    Id = 1,
                    ShopName = "Adarsh Kirana Store",
                    Type = ShopType.GroceryShop,
                    Landmark = "Kirana Mandi, Station Road",
                    Address = "Pilibhit",
                    Area = "Pilibhit City",
                    MinOrder = "Min Order  ₹ 200.00 /-",
                    Rating = "Rating : 4.5 / 5",
                    Mobile1 = "8218239739",
                    IsWhatsApp1 = true,
                    Mobile2 = "",
                    IsWhatsApp2 = false,
                    Image = "grocery.png",
                    IsActive = true
                });
                shopList.Add(new Shop
                {
                    Id = 2,
                    ShopName = "Chandra Confectionary",
                    Type = ShopType.ConfectionaryShop,
                    Landmark = "Main Market, Station Road",
                    Address = "Pilibhit",
                    Area = "Pilibhit City",
                    MinOrder = "Min Order  ₹ 100.00 /-",
                    Rating = "Rating : 4.5 / 5",
                    Mobile1 = "9058430500",
                    IsWhatsApp1 = false,
                    Mobile2 = "9410648691",
                    IsWhatsApp2 = true,
                    Image = "confect.png",
                    IsActive = true
                });

                return shopList;
            }
            catch (Exception ex)
            {
                email.SendMail(ex.Message.ToString());
                shopList = null;
                return shopList;
            }
        }
    }
}
