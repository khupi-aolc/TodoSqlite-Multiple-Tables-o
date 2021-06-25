using System.Collections.Generic;
using BellApp.Views.Installation;
using BellApp.Views.riskAssessment;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BellApp.Models;
using Xamarin.Forms;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BellApp.ViewModels
{
   public class CarouselViewModel : INotifyPropertyChanged
    {
        readonly IList<Carousel> source;

      
        public ObservableCollection<Carousel> Carousels { get;  set; }
        public IList<Carousel> EmptyCarousels { get;  set; }
        public Carousel PreviousCarousel { get; set; }
        public Carousel CurrentCarousel { get; set; }
        public Carousel CurrentItem { get; set; }
        public int PreviousPosition { get; set; }
        public int CurrentPosition { get; set; }
        public int Position { get; set; }

        public ICommand FilterCommand => new Command<string>(FilterItems);
        public ICommand ItemChangedCommand => new Command<Carousel>(ItemChanged);
        public ICommand PositionChangedCommand => new Command<int>(PositionChanged);
        public ICommand DeleteCommand => new Command<Carousel>(RemoveCarousel);
        public ICommand FavoriteCommand => new Command<Carousel>(FavoriteCarousel);

      

      
        public void StartInstallion()
        {
                   Application.Current.MainPage = new NavigationPage(new InstallationPage1());
        }
        
       


        public void StartRiskAssessment()
        {
           
            Application.Current.MainPage = new NavigationPage(new RiskAssPage1());
        }

        public CarouselViewModel()
        {
          

            source = new List<Carousel>();
            CreateCarouselCollection();

            CurrentItem = Carousels.Skip(3).FirstOrDefault();
            OnPropertyChanged("CurrentItem");
            Position = 3;
            OnPropertyChanged("Position");
        }

        void CreateCarouselCollection()
        {
            source.Add(new Carousel
            {
                bell_riskName = "Risk \n Assessment",
                bell_installationName = "Installation",
                Bell_ServiceName = "Service",
                bell_MCAName = "MCA",
                bell_partsName = "Parts",
                bell_firName = "FIR",
                InstallCommand = new Command(StartInstallion),
                RiskAssessmentCommand = new Command(StartRiskAssessment),


                Width = Application.Current.MainPage.Height,
                bell_risk = "bell_risk",
                bell_installation = "bell_installation",
                Bell_Service = "Bell_Service",
                bell_MCA = "bell_MCA",
                bell_parts = "bell_parts",
                bell_fir = "bell_fir"
            }); 
            
            source.Add(new Carousel
            {
 
                bell_riskName = "Risk Assessment",
                bell_installationName = "Installation",
                Bell_ServiceName = "Service",
               
                Width = Application.Current.MainPage.Height,
                bell_risk = "bell_risk",
                bell_installation = "bell_installation",
                Bell_Service = "Bell_Service",
              
            });
            
             Carousels = new ObservableCollection<Carousel>(source);
        }

        void FilterItems(string filter)
        {
            var filteredItems = source.Where(Carousel => Carousel.bell_riskName.ToLower().Contains(filter.ToLower())).ToList();
            foreach (var Carousel in source)
            {
                if (!filteredItems.Contains(Carousel))
                {
                    Carousels.Remove(Carousel);
                }
                else
                {
                    if (!Carousels.Contains(Carousel))
                    {
                        Carousels.Add(Carousel);
                    }
                }
            }
        }

        void ItemChanged(Carousel item)
        {
            PreviousCarousel = CurrentCarousel;
            CurrentCarousel = item;
            OnPropertyChanged("PreviousCarousel");
            OnPropertyChanged("CurrentCarousel");
        }

        void PositionChanged(int position)
        {
            PreviousPosition = CurrentPosition;
            CurrentPosition = position;
            OnPropertyChanged("PreviousPosition");
            OnPropertyChanged("CurrentPosition");
        }

        void RemoveCarousel(Carousel Carousel)
        {
            if (Carousels.Contains(Carousel))
            {
                Carousels.Remove(Carousel);
            }
        }

        void FavoriteCarousel(Carousel Carousel)
        {
            Carousel.IsFavorite = !Carousel.IsFavorite;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }


}

