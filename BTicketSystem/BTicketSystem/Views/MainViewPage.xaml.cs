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
    public partial class MainViewPage : ContentPage
    {
        public MainViewPage()
        {
            InitializeComponent();

            logedInUserBind.Text = App._LoginUserName;
        }



        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listConfirmBookings.ItemsSource = await App.Database.GetBookingAsync();

        }

        async void OnImageNameTappedAsync(object sender, EventArgs args)
        {
            try
            {
                await this.Navigation.PushAsync(new CreateBookingPage());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //on button click
        async void OnAddButtonClicked(object sender, EventArgs args)
        {
            try
            {
                await this.Navigation.PushAsync(new CreateBookingPage());
                //Navigation.PushAsync(new MakeBooking());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        async void OnUserAboutUsBtnClicked(Object sender,EventArgs args)
        {
            try
            {
                await this.Navigation.PushAsync(new NavigationPage(new InfoPage()));
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }

        //command invoke on text click
        //public ICommand RegisterNewUserCommand => new Command(OnRegisterNow);
        // public async void OnRegisterNow()
        // {
        //    Console.WriteLine("I an here");
        //     await Navigation.PushAsync(new CreateAccount());
        // }


    }
}