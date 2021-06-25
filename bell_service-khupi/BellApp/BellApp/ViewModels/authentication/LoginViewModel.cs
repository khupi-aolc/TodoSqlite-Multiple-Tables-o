using BellApp.Models.Dtos;
using BellApp.Views;
using BellApp.Views.authentication;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using BellApp.Helpers.Behaviors;
using BellApp.Helpers.Validators;
using BellApp.Helpers.Validators.Rules;
using System.Windows.Input;

namespace BellApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public Command RememberMeCommand { get; }
        public Command ForgotPasswordCommand { get; }
        public Command CreateNewAccountCommand { get; }

        //t-k #begin
        LoginDto user = new LoginDto();

        //t-k #end

        private bool isChecked;
        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                if (isChecked == value) return;
                isChecked = value;
                OnPropertyChanged(nameof(IsChecked));
            }
        }

        /*private string username;
        public string Username
        {
            get { return username; }
            set
            {
                if (username == value) return;
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                if (password == value) return;
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }*/

        //t-k #begin
        public ValidatablePair<string> Username { get; set; } = new ValidatablePair<string>();
        public ValidatablePair<string> Password { get; set; } = new ValidatablePair<string>();

        //t-k #end

        public LoginViewModel()
        {
            AddValidationRules();
            LoginCommand = new Command(OnLoginClicked);
            //RememberMeCommand = new Command(() => IsChecked = !IsChecked);
            //ForgotPasswordCommand = new Command(OnForgotPasswordClicked);
            CreateNewAccountCommand = new Command(OnCreateNewAccountClicked);
        }
        public void AddValidationRules()
        {
            Username.Item1.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Username Required" });
            Username.Item1.Validations.Add(new IsValidEmailRule<string> { ValidationMessage = "Invalid Username" });
            Password.Item1.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password Required" });
        }



        bool AreFieldsValid()
        {
            bool IsUsernameValid = Username.Validate();
            bool IsPasswordvalid = Password.Validate();

            return IsPasswordvalid && IsUsernameValid;
        }

        private async void OnLoginClicked(object obj)
        {
            if (AreFieldsValid())
            {

                try
                {

                    /*Database database = new Database();
                    user.Company = Company.ToString();
                    user.CompanyNo = CompanyNo.ToString();
                    user.JobPosition = JobPosition.ToString();
                    user.Name = Name.ToString();
                    user.Email = Email.ToString();
                    user.Password = Password.ToString();
                    user.DateCreated = Date;

                    database.Insert(user);*/

                    /*//var userName = database.Get(user.Id);
                    if (userName != null)
                    {
                        await App.Current.MainPage.DisplayAlert("Success", "Account For " + userName.Name + " Created Succesfully", "Ok");
                    }*//*
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Required", "Something went wrong", "OK");
                    }*/

                    /*Company.Value = string.Empty;
                    CompanyNo.Value = string.Empty;
                    JobPosition.Value = string.Empty;
                    Name.Value = string.Empty;
                    Email.Item1.Value = string.Empty;
                    Password.Item1.Value = string.Empty;
                    Password.Item2.Value = string.Empty;*/

                    if (user.Username == "Khupi@test.co.za" && user.Password == "Test12345678@")
                    {
                        Application.Current.MainPage = new HomeCarouselPage();
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Login Fail", "Please enter correct Username and Password", "Ok");
                    }
                }
                catch (Exception e)
                {
                    await App.Current.MainPage.DisplayAlert("Failed", e + "Something went wrong, please try to create the account again", "Ok");
                }
            }

            /*if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                await App.Current.MainPage.DisplayAlert("", "Please Enter Email and Password", "Ok");
            else
            {
                if (Username == "Khupi" && Password == "Test12345678@")
                {
                    Application.Current.MainPage = new HomeCarouselPage();
                }
                else 
                {
                    await App.Current.MainPage.DisplayAlert("Login Fail", "Please enter correct Username and Password", "Ok");
                }
            }*/

            /*LoginDto details = new LoginDto 
            {
                Username = Username,
                Password = Password
            };*/

            //Application.Current.MainPage = new HomeCarouselPage();

            //if (await DataStore.Login(details))
            //{
            //    Application.Current.MainPage = new HomePage();
            //}

            //// Change this to a thread safe system
            //await Application.Current.MainPage.DisplayAlert("Bell app", "Failed to login", "Ok");
        }

        /*private void OnForgotPasswordClicked(object obj)
        {
            Application.Current.MainPage = new ForgotPassword();
        }*/

        private void OnCreateNewAccountClicked(object obj)
        {
            Application.Current.MainPage = new RegistrationPage();
        }
    }
}

