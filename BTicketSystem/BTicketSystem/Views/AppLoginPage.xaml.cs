using BTicketSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BTicketSystem.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppLoginPage : ContentPage
    {
        public AppLoginPage()
        {
            InitializeComponent();

            MyElementStyles();
        }

        private void MyElementStyles()
        {
            var nav = new NavigationPage(new ContentPage { Title = "User Login" });
            nav.BarBackgroundColor = Xamarin.Forms.Color.BlueViolet;

        }


        public ICommand RegisterNewUserCommand => new Command(OnRegisterNow);
        public async void OnRegisterNow()
        {
            Console.WriteLine("I an here");
            await Navigation.PushAsync(new CreateAccount());
        }


        private async void RegisterNewUserCommand1(object s, EventArgs e)
        {
            Console.WriteLine("RegisterNewUserCommand1 ::Here");

            await Navigation.PushAsync(new NavigationPage(new CreateAccount()));
        }


        //public static string userLoginName;
        //static int userLoginId;

        async void onlogin(object s, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(loginName.Text) && !string.IsNullOrWhiteSpace(loginPassword.Text))
                {
                    UserInfo user = await App.Database.updateUserValidation(loginName.Text, loginPassword.Text);
                    if (user != null && !string.IsNullOrWhiteSpace(user.PersonEmail))
                    {
                        App._LoginUserName = "User ::" + user.PersonName;
                        App._LoginUserID = user.UserId;
                        App._LoginUserEmail = user.PersonEmail;
                        App._LoginUserContact = user.PersonContact;

                        await DisplayAlert("Alert", "logged in successfully.", "OK");

                        await Navigation.PushAsync(new MainViewPage());
                    }
                    else
                    {
                        await DisplayAlert("Toast", "Icorrect Email or password", "OK");
                    }

                }
                else
                {
                    //userDialogs.Toast("I am a toast. Great for showing small pieces of transient information.");
                    await DisplayAlert("Toast", "Please Enter Email and Password.", "OK");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            ///await Navigation.PushAsync(new NavigationPage(new MainViewPage()));
        }

    }
}