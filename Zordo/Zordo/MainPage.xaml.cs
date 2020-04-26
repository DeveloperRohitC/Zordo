using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Zordo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }
        private void btnOrder_Clicked(object sender, EventArgs e)
        {
            //Helper.ExceptionEmail ee = new Helper.ExceptionEmail();
            //ee.SendMail("Hello Rohit");
            Navigation.PushAsync(new NavigationPage(new SelectLocation()));
        }
    }
}
