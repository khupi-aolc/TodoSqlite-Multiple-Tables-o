using BellApp.Views.Installation;
using BellApp.Views.riskAssessment;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BellApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public Command InstallCommand { get; }
        public Command RiskAssessmentCommand { get; }

        public HomeViewModel()
        {
            InstallCommand = new Command(StartInstallion);
            RiskAssessmentCommand = new Command(StartRiskAssessment);
        }

        public void StartInstallion()
        {
            Application.Current.MainPage = new NavigationPage(new InstallationPage1());
        }

        public void StartRiskAssessment()
        {
            Application.Current.MainPage = new NavigationPage(new RiskAssPage1());
        }
    }
}
