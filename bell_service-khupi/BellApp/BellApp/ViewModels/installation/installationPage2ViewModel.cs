using BellApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BellApp.ViewModels.Installation
{
    public class installationPage2ViewModel : BaseViewModel
    {
        public Command PrevPageCommand { get; }
        public Command SubmitCommand { get; }

        public installationPage2ViewModel()
        {
            PrevPageCommand = new Command(PrevPage);
            SubmitCommand = new Command(SubmitInstallation);
        }

        public async void PrevPage()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public void SubmitInstallation()
        {
            Application.Current.MainPage = new HomePage();
        }
    }
}
