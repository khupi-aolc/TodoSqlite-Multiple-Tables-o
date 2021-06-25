using BellApp.Views.riskAssessment;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BellApp.ViewModels.riskAssessment
{
     public class SignatureRiskAssesment : BaseViewModel
     {
      public Command RiskAssPageCommand { set; get; }

        public SignatureRiskAssesment()
        {
            RiskAssPageCommand = new Command(RiskAssPage1);
         
        }

        public void RiskAssPage1()
        {
            Application.Current.MainPage = new NavigationPage(new RiskAssPage1());
        }

       

    }
}
