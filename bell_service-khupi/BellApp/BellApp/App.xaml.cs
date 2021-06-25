using BellApp.Services;
using BellApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BellApp
{
    public partial class App : Application
    {

     //   public static string _PopupType { get; set; }
        public App(string dbPath)
        {
            InitializeComponent();

            DependencyService.RegisterSingleton<DataContext>(new DataContext(dbPath));
            MainPage = new LoginPage();

        }

    
    protected override void OnStart()
        {

           
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
