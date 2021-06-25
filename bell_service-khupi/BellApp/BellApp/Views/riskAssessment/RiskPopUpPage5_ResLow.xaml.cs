using BellApp.ViewModels.riskAssessment;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BellApp.Views.riskAssessment
{
    public partial class RiskPopUpPage5_ResLow : PopupPage
    {
        public RiskPopUpPage5_ResLow(string headerPop)
        {
            InitializeComponent();
            BindingContext = new RiskPopup_5ResLowViewModel(Navigation);
            HeadingPopUp.Text = headerPop;
        }

        private void IsassessalmostCetain_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (IsassessalmostCetain.IsChecked)
            {
                IsassessRare.IsChecked = false;
                Isassesslikely.IsChecked = false;
                IsassessUnlikey.IsChecked = false;
                IsssessPosible.IsChecked = false;
            }
        }

        private void Isassesslikely_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (Isassesslikely.IsChecked)
            {
                IsassessRare.IsChecked = false;
                IsassessalmostCetain.IsChecked = false;
                IsassessUnlikey.IsChecked = false;
                IsssessPosible.IsChecked = false;
            }

        }

        private void IsssessPosible_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (IsssessPosible.IsChecked)
            {
                IsassessRare.IsChecked = false;
                IsassessalmostCetain.IsChecked = false;
                Isassesslikely.IsChecked = false;
                IsassessUnlikey.IsChecked = false;
            }
        }

        private void IsassessUnlikey_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (IsassessUnlikey.IsChecked)
            {
                IsassessalmostCetain.IsChecked = false;
                Isassesslikely.IsChecked = false;
                IsssessPosible.IsChecked = false;
                IsassessRare.IsChecked = false;
            }
        }
        private void IsassessRare_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (IsassessRare.IsChecked)
            {
                IsassessalmostCetain.IsChecked = false;
                Isassesslikely.IsChecked = false;
                IsssessPosible.IsChecked = false;
                IsassessUnlikey.IsChecked = false;
            }
        }
    }
}