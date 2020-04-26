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
        Int32 shopType;
        string location = string.Empty;
        public ShopList(Int32 type, string location)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.shopType = type;
            this.location = location;
            LoadShops();
        }

        public async void LoadShops()
        {
            try
            {
                var allShops = await _business.GetAllShopsByTypeAndLocation(shopType,location);
                listShops.ItemsSource = allShops;
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