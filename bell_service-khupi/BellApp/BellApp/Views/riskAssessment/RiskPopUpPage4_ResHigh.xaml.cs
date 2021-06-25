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
    public partial class RiskPopUpPage4_ResHigh : PopupPage
    {
        public RiskPopUpPage4_ResHigh(string headerPop)
        {
            InitializeComponent();
            BindingContext = new RiskPopup_4ResHighViewModel(Navigation, headerPop);
            HeadingPopUp.Text = headerPop;
        }

      
    }
}