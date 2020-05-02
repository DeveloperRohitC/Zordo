using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zordo.Helper;

namespace Zordo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShopDetails : ContentPage
    {
        ExceptionEmail email = new ExceptionEmail();
        Shop _shop;
        public ShopDetails(Shop shop)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = this._shop = shop;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            PhoneDialer.Open(_shop.Mobile1);
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            PhoneDialer.Open(_shop.Mobile2);
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            try
            {
                var uriString = "whatsapp://send?phone=91" + _shop.Mobile1;
                uriString += "&text=" + "Order via Zordo : ";
                Launcher.OpenAsync(new Uri(uriString));
            }
            catch (Exception ex)
            {
                email.SendMail(ex.Message.ToString());
                DisplayAlert("Not Installed", "Whatsapp is not installed", "ok");
            }
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            try
            {
                var uriString = "whatsapp://send?phone=91" + _shop.Mobile2;
                uriString += "&text=" + "Order via Zordo : ";
                Launcher.OpenAsync(new Uri(uriString));
            }
            catch (Exception ex)
            {
                email.SendMail(ex.Message.ToString());
                DisplayAlert("Not Installed", "Whatsapp is not installed", "ok");
            }
        }
    }
}