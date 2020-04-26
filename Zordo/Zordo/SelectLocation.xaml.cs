using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zordo.Helper;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Zordo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectLocation : ContentPage
    {
        ExceptionEmail email = new ExceptionEmail();
        public SelectLocation()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            pickerLocation.SelectedIndex = 0;
        }
        private async void btnGetShop_Clicked(object sender, EventArgs e)
        {
            try
            {
                ShopType shopTypeID = 0;
                string type = Convert.ToString(pickerType.SelectedItem);
                //shopTypeID = (type == "Grocery Shop") ? ShopType.GroceryShop : (type == "Medical Shop") ? ShopType.MedicalShop : type == "Vegetables Shop" ? ShopType.VegetablesShop : ShopType.GroceryShop;
                shopTypeID = (type == "Grocery Shop") ? ShopType.GroceryShop : (type.Contains("Confectionary")) ? ShopType.ConfectionaryShop : ShopType.GroceryShop;
                string location = Convert.ToString(pickerLocation.SelectedItem);
                if (!string.IsNullOrWhiteSpace(location))
                {
                    if (!string.IsNullOrWhiteSpace(type))
                        await Navigation.PushAsync(new ShopList(shopTypeID, location));
                    else
                        await DisplayAlert("Alert", "Please select type !", "Ok");
                }
                else
                {
                    await DisplayAlert("Alert", "Please select location !", "Ok");
                }
            }
            catch (Exception ex)
            {
                email.SendMail(ex.Message.ToString());
            }
        }
    }
}