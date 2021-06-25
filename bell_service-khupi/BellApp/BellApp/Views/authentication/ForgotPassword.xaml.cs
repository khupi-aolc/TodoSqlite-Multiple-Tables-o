using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;
using BellApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BellApp.ViewModels.authentication;

namespace BellApp.Views.authentication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPassword : ContentPage
    {

        public ForgotPassword()
        {
            InitializeComponent();
            this.BindingContext = new ForgotPasswordViewModel();

        }
    }
}
