using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;

namespace Zordo.Helper
{
    class BusinessLogic
    {
        ExceptionEmail email = new ExceptionEmail();
        FirebaseClient firebase = new FirebaseClient("https://zordo-1317.firebaseio.com/");


        public async Task<List<Shop>> GetAllShops()
        {
            return (await firebase
              .Child("Shop")
              .OnceAsync<Shop>()).Select(item => new Shop
              {
                  ShopName = item.Object.ShopName,
                  Type = item.Object.Type,
                  Landmark = item.Object.Landmark,
                  Address = item.Object.Address,
                  Area = item.Object.Area,
                  MinOrder = item.Object.MinOrder,
                  Rating = item.Object.Rating,
                  Mobile1 = item.Object.Mobile1,
                  IsWhatsApp1 = item.Object.IsWhatsApp1,
                  Mobile2 = item.Object.Mobile2,
                  IsWhatsApp2 = item.Object.IsWhatsApp2,
                  Image = item.Object.Image,
                  IsActive = item.Object.IsActive
              }).ToList();
        }

        public async Task<List<Shop>> GetAllShopsByTypeAndLocation(int type, string location)
        {
            return (await firebase
              .Child("Shop")
              .OnceAsync<Shop>()).Select(item => new Shop
              {
                  ShopName = item.Object.ShopName,
                  Type = item.Object.Type,
                  Landmark = item.Object.Landmark,
                  Address = item.Object.Address,
                  Area = item.Object.Area,
                  MinOrder = item.Object.MinOrder,
                  Rating = item.Object.Rating,
                  Mobile1 = item.Object.Mobile1,
                  IsWhatsApp1 = item.Object.IsWhatsApp1,
                  Mobile2 = item.Object.Mobile2,
                  IsWhatsApp2 = item.Object.IsWhatsApp2,
                  Image = item.Object.Image,
                  IsActive = item.Object.IsActive
              }).ToList().Where(s=>s.Type==type && s.Area==location).ToList();
        }

        public async Task<Shop> GetShop(int shopId)
        {
            var allPersons = await GetAllShops();
            await firebase
              .Child("Shop")
              .OnceAsync<Shop>();
            return allPersons.Where(s => s.Id == shopId).FirstOrDefault();
        }

        public async Task AddShop(Shop _shop)
        {

            await firebase
              .Child("Shop")
              .PostAsync(new Shop()
              {
                  ShopName = _shop.ShopName,
                  Type = _shop.Type,
                  Landmark = _shop.Landmark,
                  Address = _shop.Address,
                  Area = _shop.Area,
                  MinOrder = _shop.MinOrder,
                  Rating = _shop.Rating,
                  Mobile1 = _shop.Mobile1,
                  IsWhatsApp1 = _shop.IsWhatsApp1,
                  Mobile2 = _shop.Mobile2,
                  IsWhatsApp2 = _shop.IsWhatsApp2,
                  Image = _shop.Image,
                  IsActive = _shop.IsActive
              });
        }

        public async Task UpdateShop(Shop _shop)
        {
            var toUpdatePerson = (await firebase
              .Child("Shop")
              .OnceAsync<Shop>()).Where(a => a.Object.Id == _shop.Id).FirstOrDefault();

            await firebase
              .Child("Shop")
              .Child(toUpdatePerson.Key)
              .PutAsync(new Shop()
              {
                  ShopName = _shop.ShopName,
                  Type = _shop.Type,
                  Landmark = _shop.Landmark,
                  Address = _shop.Address,
                  Area = _shop.Area,
                  MinOrder = _shop.MinOrder,
                  Rating = _shop.Rating,
                  Mobile1 = _shop.Mobile1,
                  IsWhatsApp1 = _shop.IsWhatsApp1,
                  Mobile2 = _shop.Mobile2,
                  IsWhatsApp2 = _shop.IsWhatsApp2,
                  Image = _shop.Image,
                  IsActive = _shop.IsActive
              });
        }

        public List<Shop> GetShopList()
        {
            List<Shop> shopList = new List<Shop>();
            try
            {
                shopList.Add(new Shop
                {
                    Id = 1,
                    ShopName = "Adarsh Kirana Store",
                    Type = 1,
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
                    Type = 0,
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
