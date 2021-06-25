using BellApp.Models.Dtos;
using Xamarin.Forms;
using BellApp.Views;
using System.Windows.Input;
using BellApp.Helpers.Validators;
using BellApp.Helpers.Validators.Rules;
using System.ComponentModel;
using BellApp.Datas;
using System;
using BellApp.Services;
using BellApp.Views.authentication;
using System.Diagnostics;
using System.Linq;
//using BellApp.Services.Routing;
//using Splat;

namespace BellApp.ViewModels.authentication
{
    public class RegistrationViewModel : BaseViewModel
    {

        //private IRoutingService _navigationService;


        //public ICommand CreateNewUserCommand { get; }
        public UsersDto user = new UsersDto();
        APIServices _services = new APIServices();

        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set
            {
                if (_date == value) return;
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        //private UsersDto user = new UsersDto();

        public ValidatableObject<string> Company { get; set; } = new ValidatableObject<string>();
        public ValidatableObject<string> CompanyNo { get; set; } = new ValidatableObject<string>();
        public ValidatableObject<string> JobPosition { get; set; } = new ValidatableObject<string>();
        public ValidatableObject<string> Name { get; set; } = new ValidatableObject<string>();
        public ValidatableObject<string> Email { get; set; } = new ValidatableObject<string>();
        public ValidatablePair<string> Password { get; set; } = new ValidatablePair<string>();

        public Command loginBackCommand { get; }
        public RegistrationViewModel(/*IRoutingService navigationService = null*/)
        {
            //_navigationService = navigationService ?? Locator.Current.GetService<IRoutingService>();
            AddValidationRules();
            loginBackCommand = new Command(backToLogin);
        }

        public void AddValidationRules()
        {
            Company.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Company Required" });
            CompanyNo.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Company Registration Number Required" });
            JobPosition.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Job Position is Required" });
            Name.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Name Required" });

            Email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email Required" });
            Email.Validations.Add(new IsValidEmailRule<string> { ValidationMessage = "Invalid Email" });

            Password.Item1.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password Required" });
            Password.Item1.Validations.Add(new IsValidPasswordRule<string> { ValidationMessage = "Password between 8-20 characters; must contain at least one lowercase letter, one uppercase letter, one numeric digit, and one special character" });
            Password.Item2.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Confirm password required" });
            Password.Validations.Add(new MatchPairValidationRule<string> { ValidationMessage = "Password and confirm password don't match" });

        }

        /*        public ICommand CreateNewUserCommand 
                {
                    get
                    {
                        return new Command(async () =>
                        {
                            if (AreFieldsValid())
                            {
                                var isSuccess = await _services.RegisterAsync(Company, CompanyNo, JobPosition, Name, Email, Password);
                                await _services.RegisterAsync(Company, CompanyNo, JobPosition, Name, Email, Password);

                                if (isSuccess)
                                {

                                    await App.Current.MainPage.DisplayAlert("Success", "Account Created Succesfully", "Ok");

                                    *//*var rootPage = App.Current.MainPage.Navigation.NavigationStack.FirstOrDefault();
                                    App.Current.MainPage.Navigation.InsertPageBefore(new LoginPage(), App.Current.MainPage.Navigation.NavigationStack.First());
                                    await App.Current.MainPage.Navigation.PopToRootAsync();*/
        /*if (rootPage != null)
        {
            //App.IsUserLoggedIn = true;
            App.Current.MainPage.Navigation.InsertPageBefore(new LoginPage(), App.Current.MainPage.Navigation.NavigationStack.First());
            await App.Current.MainPage.Navigation.PopToRootAsync();
        }*/

        /*var mainPage = new MainPage();
        var rootPage = new NavigationPage(mainPage);
        App.INavigation = rootPage.Navigation;*//*
        //await ((RegistrationPage)App.Current.MainPage).Pag.Navigation.PushAsync(new LoginPage());

        *//*var newPage = new ContentPage();
        await App.Current.Navigation.PushAsync(newPage);
        Debug.WriteLine("the new page is now showing");
        var poppedPage = await Navigation.PopAsync();
        Debug.WriteLine("the new page is dismissed");
        Debug.WriteLine(Object.ReferenceEquals(newPage, poppedPage)); //prints "true" ```*/

        /* var rootPage = App.Current.MainPage.Navigation.NavigationStack.FirstOrDefault();
         App.Current.MainPage.Navigation.InsertPageBefore(new LoginPage(), App.Current.MainPage.Navigation.NavigationStack.First());
         await App.Current.MainPage.Navigation.PushAsync(new LoginPage());*//*

        //await _navigationService.PushPage();


    }
    else
    {
        await App.Current.MainPage.DisplayAlert("Failed", "Something went wrong, please try to create the account again", "Ok");
    }
}

});
}
}
*/

        //Insert into sqlite local db
        public ICommand CreateNewUserCommand => new Command(async () =>
        {
            //Insert into sqlite local db
            if (AreFieldsValid())
            {

                try
                {

                    Database database = new Database();

                    user.Company = Company.ToString();
                    user.CompanyNo = CompanyNo.ToString();
                    user.JobPosition = JobPosition.ToString();
                    user.Name = Name.ToString();
                    user.Email = Email.ToString();
                    user.Password = Password.ToString();
                    //user.DateCreated = Date;

                    //database.CheckEmail();
                    var checkMail = database.CheckEmail(user);
                    if (checkMail == null)
                    {
                        database.Insert(user);
                        var userName = database.Get(user.Id);
                        await App.Current.MainPage.DisplayAlert("Success", "Account For " + userName.Name + " Created Succesfully", "Ok");
                        //await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Required", "Something went wrong", "OK");
                    }

                    Company.Value = string.Empty;
                    CompanyNo.Value = string.Empty;
                    JobPosition.Value = string.Empty;
                    Name.Value = string.Empty;
                    Email.Value = string.Empty;
                    Password.Item1.Value = string.Empty;
                    Password.Item2.Value = string.Empty;
                }
                catch (Exception e)
                {
                    await App.Current.MainPage.DisplayAlert("Failed", "Something went wrong, please try to create the account again", "Ok");
                }
            }
        });

        bool AreFieldsValid() 
        {
            bool isCompanyValid = Company.Validate();
            bool isCompanyNoValid = CompanyNo.Validate();
            bool isJobPostionValid = JobPosition.Validate();
            bool isNameValid = Name.Validate();
            bool isEmailValid = Email.Validate();
            bool isPasswordValid = Password.Validate();

            return isCompanyValid && isCompanyNoValid && isJobPostionValid && isNameValid && isEmailValid && isPasswordValid;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand BackCommand => new Command(Back);
        private async void Back()
        {
            await App.Current.MainPage.Navigation.PopModalAsync();
        }

        private void backToLogin(object obj)
        {
            Application.Current.MainPage = new LoginPage();
        }

     


        /* public async void backToLogin()
             {
                 await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
             }*/


    }


}
