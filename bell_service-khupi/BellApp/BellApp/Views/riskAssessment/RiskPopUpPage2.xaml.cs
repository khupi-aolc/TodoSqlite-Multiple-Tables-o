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
    public partial class RiskPopUpPage2 : PopupPage
    {
        public RiskPopUpPage2(string headerPop)
        {
            InitializeComponent();
            BindingContext = new RiskPopup_2ViewModel(Navigation, headerPop);
            HeadingPopUp.Text = headerPop + "-IMPACT";
        }

        private void IsextremeFatal_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (IsextremeFatal.IsChecked)
            {
                IssMajor.IsChecked = false;
                IsModerate.IsChecked = false;
                IsSignificant.IsChecked = false;
                IsMinor.IsChecked = false;
            }
        }

        private void IsMajor_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (IssMajor.IsChecked)
            {
                IsextremeFatal.IsChecked = false;
                IsModerate.IsChecked = false;
                IsSignificant.IsChecked = false;
                IsMinor.IsChecked = false;
            }

        }

        private void IsModerate_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (IsModerate.IsChecked)
            {
                IssMajor.IsChecked = false;
                IsextremeFatal.IsChecked = false;
                IsSignificant.IsChecked = false;
                IsMinor.IsChecked = false;
            }
        }

        private void IsSignificant_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (IsSignificant.IsChecked)
            {
                IssMajor.IsChecked = false;
                IsextremeFatal.IsChecked = false;
                IsModerate.IsChecked = false;
                IsMinor.IsChecked = false;
            }
        }
        private void IsMinor_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (IsMinor.IsChecked)
            {
                IssMajor.IsChecked = false;
                IsextremeFatal.IsChecked = false;
                IsModerate.IsChecked = false;
                IsSignificant.IsChecked = false;
            }
        }
    }
}