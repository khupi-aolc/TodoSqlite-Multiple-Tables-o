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
    public partial class LoginPage : ContentPage
    {
        LoginViewModel loginVM;
        public LoginPage()
        {
            InitializeComponent();
            loginVM = new LoginViewModel();
            this.BindingContext = loginVM;
        }
        

    }

   
}
