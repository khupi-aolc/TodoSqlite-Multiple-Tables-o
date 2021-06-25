using BellApp.Views.riskAssessment;
using Prism.Navigation.Xaml;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BellApp.ViewModels.riskAssessment
{
    public class RiskPopup_3ViewModel : BaseViewModel
    {

        private bool isUncontrollable;
        private bool isWeak;
        private bool isModerate;
        private bool isGood;
        private bool isVeryGood;

        public bool IsUncontrollable
        {
            get { return isUncontrollable; }
            set
            {
                if (isUncontrollable == value) return;
                isUncontrollable = value;
                OnPropertyChanged(nameof(IsUncontrollable));
            }
        }

        public bool IsWeak
        {
            get { return isWeak; }
            set
            {
                if (isWeak == value) return;
                isWeak = value;
                OnPropertyChanged(nameof(IsWeak));
            }
        }

        public bool IsModerate
        {
            get { return isModerate; }
            set
            {
                if (isModerate == value) return;
                isModerate = value;
                OnPropertyChanged(nameof(IsModerate));
            }
        }

        public bool IsGood
        {
            get { return isGood; }
            set
            {
                if (isGood == value) return;
                isGood = value;
                OnPropertyChanged(nameof(IsGood));
            }
        }

        public bool IsVeryGood
        {
            get { return isVeryGood; }
            set
            {
                if (isVeryGood == value) return;
                isVeryGood = value;
                OnPropertyChanged(nameof(IsVeryGood));
            }
        }

        public INavigation Navigation { get; set; }
        public string HeaderPop  { get; set; }
        public RiskPopup_3ViewModel(INavigation navigation , string headerPop)
        {
            Navigation = navigation;
            HeaderPop = headerPop;
        }



        public Command Next_ThrdPopup
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PopPopupAsync();
                    Navigation.PushPopupAsync(new RiskPopUpPage4_ResHigh(HeaderPop));
                });
            }
        }


        public Command Previous_ThrdPopup
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PopPopupAsync();
                    Navigation.PushPopupAsync(new RiskPopUpPage2(HeaderPop));
                });
            }
        }


    }
}
