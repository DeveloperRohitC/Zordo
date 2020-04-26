using System;
using System.Collections.Generic;
using System.Text;

namespace Zordo
{
    public enum ShopType
    {
        ConfectionaryShop,
        GroceryShop,
        MedicalShop,
        VegetablesShop
    }
    public class Shop
    {
        public int Id { get; set; }
        public string ShopName { get; set; }
        public ShopType Type { get; set; }
        public string Landmark { get; set; }
        public string Address { get; set; }
        public string Area { get; set; }
        public string MinOrder { get; set; }
        public string Rating { get; set; }
        public string Mobile1 { get; set; }
        public bool IsWhatsApp1 { get; set; }
        public string Mobile2 { get; set; }
        public bool IsWhatsApp2 { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
    }
}
