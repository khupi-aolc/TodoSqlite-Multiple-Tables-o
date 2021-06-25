using BellApp.ViewModels.Installation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BellApp.Views.Installation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InstallationPage1 : ContentPage
    {
        public InstallationPage1()
        {
            InitializeComponent();

            this.BindingContext = new installationPage2ViewModel();
        }
    }
}
