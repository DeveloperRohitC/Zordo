using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zordo.Helper;

namespace Zordo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShopList : ContentPage
    {
        ExceptionEmail email = new ExceptionEmail();
        BusinessLogic _business = new BusinessLogic();
        List<Shop> Shops = new List<Shop>();
        ShopType shopType;
        string location = string.Empty;
        public ShopList(ShopType type, string location)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.shopType = type;
            this.location = location;
            LoadShops();
        }

        public void LoadShops()
        {
            try
            {
                Shops = _business.GetShopList();
                if (Shops != null)
                    listShops.ItemsSource = Shops.Where(s => s.Type == shopType && s.Area == location).ToList();
            }
            catch (Exception ex)
            {
                email.SendMail(ex.Message.ToString());
            }
        }

        private async void listShops_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Shop _shop = e.Item as Shop;
            await Navigation.PushAsync(new ShopDetails(_shop));
        }
    }
}