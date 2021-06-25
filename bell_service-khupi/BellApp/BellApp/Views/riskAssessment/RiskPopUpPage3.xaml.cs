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
    public partial class RiskPopUpPage3 : PopupPage
    {
        public RiskPopUpPage3(string headerPop)
        {
            InitializeComponent();
            BindingContext = new RiskPopup_3ViewModel(Navigation, headerPop);
            HeadingPopUp.Text = headerPop +"-CONTROL";
        }

        private void IsUncontrollable_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (IsUncontrollable.IsChecked)
            {
                IsWeak.IsChecked = false;
                IsModerate.IsChecked = false;
                IsGood.IsChecked = false;
                IsVeryGood.IsChecked = false;
            }
        }

        private void IsWeak_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (IsWeak.IsChecked)
            {
                IsUncontrollable.IsChecked = false;
                IsModerate.IsChecked = false;
                IsGood.IsChecked = false;
                IsVeryGood.IsChecked = false;
            }

        }

        private void IsModerate_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (IsModerate.IsChecked)
            {
                IsUncontrollable.IsChecked = false;
                IsWeak.IsChecked = false;
                IsGood.IsChecked = false;
                IsVeryGood.IsChecked = false;
            }
        }

        private void IsGood_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (IsGood.IsChecked)
            {
                IsUncontrollable.IsChecked = false;
                IsWeak.IsChecked = false;
                IsModerate.IsChecked = false;
               
                IsVeryGood.IsChecked = false;
            }
        }
        private void IsVeryGood_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (IsVeryGood.IsChecked)
            {
                IsUncontrollable.IsChecked = false;
                IsWeak.IsChecked = false;
                IsModerate.IsChecked = false;
                IsGood.IsChecked = false;
               
            }
        }
    }
}