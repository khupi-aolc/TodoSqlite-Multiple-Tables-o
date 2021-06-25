using BellApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BellApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeCarouselPage : ContentPage
    {

        public HomeCarouselPage()
        {
            InitializeComponent();
            this.BindingContext = new CarouselViewModel();
        }

        protected override bool OnBackButtonPressed()
        {
            Application.Current.MainPage = new LoginPage();
            base.OnBackButtonPressed();
            return true;
          
        }

    }
}