using BellApp.Models.Dtos;
using BellApp.Views;
using BellApp.Views.authentication;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;


namespace BellApp.ViewModels.authentication
{
    class ForgotPasswordViewModel : BaseViewModel
    {
        public Command SendForgotPasswordCommand { get; }

        public Command BackCommand { get; }

        private string forgotEmail;
        public string ForgotEmail
        {
            get { return forgotEmail; }
            set
            {
                if (forgotEmail == value) return;
                forgotEmail = value;
                OnPropertyChanged(nameof(ForgotEmail));
            }
        }

        public ForgotPasswordViewModel()
        {
            BackCommand = new Command(OnBackClicked);
        }

        private void OnBackClicked(object obj)
        {
            Application.Current.MainPage = new LoginPage();
        }


    }
}
