using BellApp.ViewModels.riskAssessment;
using Xamarin.CommunityToolkit.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.Extensions;

namespace BellApp.Views.riskAssessment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RiskAssPage1 : ContentPage
    {
        public static bool collapsed = false;

        public ImageButton opacity;
        public Command RememberMeCommand { get; }
        public double scrollSection;
        RiskAssViewModel tabbed = new RiskAssViewModel();
        private int Nextcount = 1;
        public double ScreenheightFirstSection = Application.Current.MainPage.Height;
        public RiskAssPage1()
        {
            InitializeComponent();
            this.BindingContext = new RiskAssViewModel();
        }


       public void OnExpanderTapped(object sender, EventArgs e)
         {
            // tabbed.Access.Opacity = 10;
        }




       // ScrollView scrollView = new ScrollView {};

        public async void ScrolledUp(object sender, EventArgs e)
        {
            await DisplayAlert("Error", scrollSection.ToString(), "OK");

            try
            {
               //await scrollView.ScrollToAsync(0, yaxis, false);
                await scrollView.ScrollToAsync(userName, ScrollToPosition.End, true);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");

            }
           
        }


       
        
        public async void Next(object sender, EventArgs e)
        {
            
            bool clicked = true;
            if (Nextcount <= 6 && Nextcount != 1  )
            {
              //  Nextcount++;
               // await DisplayAlert("Error", Nextcount.ToString(), "OK");
            }

            try
            {
                if (Nextcount==1 && clicked == true)
                { 
                  await scrollView.ScrollToAsync(protectiveClothing, ScrollToPosition.Start, true);
                   clicked = false;
                }

                if (Nextcount ==2 && clicked == true)
                {
                    await scrollView.ScrollToAsync(hasToBeDone, ScrollToPosition.Start, true);
                    clicked = false;
                }

                if (Nextcount == 3 && clicked == true)
                {
                    await scrollView.ScrollToAsync(SlipTrip, ScrollToPosition.Start, true);
                    clicked = false;
                }

                if (Nextcount == 4 && clicked == true)
                {
                    await scrollView.ScrollToAsync(customHazards, ScrollToPosition.Start, true);
                    clicked = false;
                }

                if (Nextcount == 5 && clicked == true)
                {
                    await scrollView.ScrollToAsync(lblremovedHazards, ScrollToPosition.Start, true);
                    clicked = false;
                }

                if (Nextcount == 6 && clicked == true)
                {
                    await scrollView.ScrollToAsync(lbltaskContinue, ScrollToPosition.Start, true);
                    clicked = false;
                }

                if (Nextcount == 7 && clicked == true)
                {
                    await scrollView.ScrollToAsync(lblRemovedHazard, ScrollToPosition.Start, true);
                    clicked = false;
                }




            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");

            }

        }

        public async void Previous(object sender, EventArgs e)
        {
            // await DisplayAlert("Error", "Previous", "OK");
            if (Nextcount !< 1 && Nextcount <= 6)
            {
                Nextcount--;
            }
           

            bool clicked = true;

            try
            {

                if (clicked ==true && Nextcount <= 2 && Nextcount < 3)
                {
                    await scrollView.ScrollToAsync(userName, ScrollToPosition.Start, true);
                    clicked = false;
                }

                if (clicked == true && Nextcount >= 2 && Nextcount <= 3)
                {
                    await scrollView.ScrollToAsync(protectiveClothing, ScrollToPosition.Start, true);
                    clicked = false;
                }

                if (clicked == true && Nextcount >= 3 && Nextcount <= 4)
                {
                    await scrollView.ScrollToAsync(hasToBeDone, ScrollToPosition.Start, true);
                    clicked = false;
                }

                if (clicked == true && Nextcount >= 4 && Nextcount <= 5)
                {
                    await scrollView.ScrollToAsync(SlipTrip, ScrollToPosition.Start, true);
                    clicked = false;
                }
                
                if (clicked == true && Nextcount >=5 && Nextcount <= 6)
                {
                    await scrollView.ScrollToAsync(customHazards, ScrollToPosition.Start, true);
                    clicked = false;
                }

                if (clicked == true && Nextcount >= 6 && Nextcount <= 7)
                {
                    await scrollView.ScrollToAsync(proceed, ScrollToPosition.Start, true);
                    clicked = false;
                }
                
            


            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");

            }

        }




        public void OnScrollViewScrolled(object sender, ScrolledEventArgs e)
        {
            Console.WriteLine($"ScrollX: {e.ScrollX}, ScrollY: {e.ScrollY}");
            // await scrollView.ScrollToAsync(0, 150, true);
           //  lblNamHeading.Text = e.ScrollY.ToString();
            // var contentSize = scrollView.ContentSize.Height;
           // var ben = protectiveClothing.X;
           // var contentSizeCheck = ((View)scrollView.Children[protectiveClothing.RotationX]).Height;
          //  lblNamHeading.Text = ben.ToString();

            scrollSection = e.ScrollY;
            if (e.ScrollY < 800)
            {
                pgbar1.Opacity = 0.3;
                lblHeading.Text = "USER CREDENTIALS";
                Nextcount = 1;
            }
            
            if(e.ScrollY > 800)
            {
                Nextcount = 2;
                pgbar1.Opacity = 0.9;
                pgbar2.Opacity = 0.3;
                lblHeading.Text = "WHAT ARE YOU WEARING";
            }
            
            if (e.ScrollY > 1480)
            {
                Nextcount = 3;

                pgbar2.Opacity = 0.9;
                pgbar3.Opacity = 0.3;
                lblHeading.Text = "STOP. STEP BACK.THINK";
            }
            if (e.ScrollY > 2100)
            {
                Nextcount = 4;
                pgbar3.Opacity = 0.9;
                pgbar4.Opacity = 0.3;
                lblHeading.Text = "IDENTIFY ASSESS";
            }
            
            if (e.ScrollY > 2750)
            {
                Nextcount = 5;
                pgbar4.Opacity = 0.9;
                pgbar5.Opacity = 0.3;
                lblHeading.Text = "ADD CUSTOM HAZARDS";
            } 
            
            if (e.ScrollY > 2950)
            {
                Nextcount = 6;
                pgbar5.Opacity = 0.9;
                pgbar6.Opacity = 0.3;
                lblHeading.Text = "MITIGATE / ELIMINATE / CONTROL";
            }

            if (e.ScrollY > 3401)
            {
                Nextcount = 7;
                pgbar6.Opacity = 0.9;
               
                lblHeading.Text = "PROCEED";
            }

            

        }

       

        public bool Expand
        {
            get { return collapsed; }
            set
            {
                if (collapsed == value) return;
                collapsed = value;
                OnPropertyChanged(nameof(Expand));
            }

        }


        public ImageButton Opacity
        {
            get { return opacity; }
            set
            {
               opacity = value;
                
            }

        }





        public void OnToggled(object sender, ToggledEventArgs e)
        {
            // Perform an action after examining e.Value
            //Debug.WriteLine("RiskAssessment: ");
            //Application.Current.MainPage.DisplayAlert("Alert", "You can write RiskAssessment!!!", "Ok");

        }

        protected override bool OnBackButtonPressed()
        {

      
            Application.Current.MainPage = new HomeCarouselPage();
            base.OnBackButtonPressed();
            return true;
        }


      





    }
}
