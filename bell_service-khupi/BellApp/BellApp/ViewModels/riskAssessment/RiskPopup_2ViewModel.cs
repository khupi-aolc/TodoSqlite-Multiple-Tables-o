using BellApp.Views.riskAssessment;
using Prism.Navigation.Xaml;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BellApp.ViewModels.riskAssessment
{
    public class RiskPopup_2ViewModel : BaseViewModel
    {

        private bool isExtremeFatal;
        private bool isMajor;
        private bool isModerate;
        private bool isSignificant;
        private bool isMinor;

        public bool IsExtremeFatal
        {
            get { return isExtremeFatal; }
            set
            {
                if (isExtremeFatal == value) return;
                isExtremeFatal = value;
                OnPropertyChanged(nameof(IsExtremeFatal));
            }
        }

        public bool IsMajor
        {
            get { return isMajor; }
            set
            {
                if (isMajor == value) return;
                isMajor = value;
                OnPropertyChanged(nameof(IsMajor));
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

        public bool IsSignificant
        {
            get { return isSignificant; }
            set
            {
                if (isSignificant == value) return;
                isSignificant = value;
                OnPropertyChanged(nameof(IsSignificant));
            }
        }

        public bool IsMinor
        {
            get { return isMinor; }
            set
            {
                if (isMinor == value) return;
                isMinor = value;
                OnPropertyChanged(nameof(IsMinor));
            }
        }

        public INavigation Navigation { get; set; }
        public string Headerpop { get; set; }
        public RiskPopup_2ViewModel(INavigation navigation, string headerpop)
        {
            Navigation = navigation;
            Headerpop = headerpop;


        }


        public Command Next_SecondPopup
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PopPopupAsync();
                    Navigation.PushPopupAsync(new RiskPopUpPage3(Headerpop));
                });
            }
        }

        public Command Previous_SecondPopup
        {
            get
            {
                return new Command((Value) =>
                {
                    Navigation.PopPopupAsync();
                    Navigation.PushPopupAsync(new RiskPopUpPage1(Headerpop));
                });
            }
        }

    }
}
