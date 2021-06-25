using BellApp.Views.riskAssessment;
using Prism.Navigation.Xaml;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BellApp.ViewModels.riskAssessment
{
    public class RiskPopup_4ResHighViewModel : BaseViewModel
    {

        private bool isassessalmostCetain;
        private bool isassesslikely;
        private bool isssessPosible;
        private bool isassessUnlikey;
        private bool isassessRare;

        public bool IsassessalmostCetain
        {
            get { return isassessalmostCetain; }
            set
            {
                if (isassessalmostCetain == value) return;
                isassessalmostCetain = value;
                OnPropertyChanged(nameof(IsassessalmostCetain));
            }
        }

        public bool Isassesslikely
        {
            get { return isassesslikely; }
            set
            {
                if (isassesslikely == value) return;
                isassesslikely = value;
                OnPropertyChanged(nameof(Isassesslikely));
            }
        }

        public bool IsssessPosible
        {
            get { return isssessPosible; }
            set
            {
                if (isssessPosible == value) return;
                isssessPosible = value;
                OnPropertyChanged(nameof(IsssessPosible));
            }
        }

        public bool IsassessUnlikey
        {
            get { return isassessUnlikey; }
            set
            {
                if (isassessUnlikey == value) return;
                isassessUnlikey = value;
                OnPropertyChanged(nameof(IsassessUnlikey));
            }
        }

        public bool IsassessRare
        {
            get { return isassessRare; }
            set
            {
                if (isassessRare == value) return;
                isassessRare = value;
                OnPropertyChanged(nameof(IsassessRare));
            }
        }

        public INavigation Navigation { get; set; }
        public string HeaderPop { get; set; }
        public RiskPopup_4ResHighViewModel(INavigation navigation, string headerPop)
        {
            Navigation = navigation;
            HeaderPop = headerPop;
        }


        public Command Next_ForthPopup
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PopPopupAsync();
                  //  Navigation.PushPopupAsync(new RiskPopUpPage5_ResLow("Hand And Finger Injury 4"));
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
                    Navigation.PushPopupAsync(new RiskPopUpPage3(HeaderPop));
                });
            }
        }


    }
}
