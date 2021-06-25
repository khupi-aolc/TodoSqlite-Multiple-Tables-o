using BellApp.Models;
using BellApp.Views.Installation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BellApp.ViewModels.Installation
{
    public class installationPage1ViewModel : BaseViewModel
    {
        private string pinVin;
        public string PinVin
        {
            get { return pinVin; }
            set
            {
                if (pinVin == value) return;
                pinVin = value;
                OnPropertyChanged(nameof(PinVin));
            }
        }

        InstallationCertificate currInstallation;

        public Command NextPageCommand { get; }

        public installationPage1ViewModel()
        {
            NextPageCommand = new Command(NextPage);
            Task.Run(() => CheckCurrentInstallation()).Wait();

            // Create new if none exists
            if (currInstallation == null)
            {

            }
        }

        public async void CheckCurrentInstallation()
        {
            currInstallation = await DataStore.GetIncompleteInstallation();
        }

        public async void CheckCurrentRiskAssesment()
        {
            //currRisk = await DataStore.GetIncompleteRiskAssesment();
        }

        public async void NextPage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new InstallationPage2());
        }
    }
}
