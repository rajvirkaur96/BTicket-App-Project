using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BTicketSystem.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateBookingPage : ContentPage
    {
        public CreateBookingPage()
        {
            InitializeComponent();

            logedInUserBind.Text = App._LoginUserName;

            _ticketTimePicker.Time = DateTime.Now.TimeOfDay;

            entryDate.SetValue(DatePicker.MinimumDateProperty, DateTime.Now);
            entryDate.SetValue(DatePicker.MaximumDateProperty, DateTime.Now.AddDays(180));
        }


        async void OnBookTicketClicked(object sender, EventArgs args)
        {

            if (await ValidateEntriesAsync())
            {
                try
                {
                    await App.Database.SaveBookingAsync(new Models.TicketBookingInfo
                    {
                        DepartureFrom = depFrom,
                        ArriveTo = arriveTo,
                        TicketDate = entryDate.Date,
                        TicketTime = _ticketTimePicker.Time,
                        AirLine = airLine,
                        TicketType = ticketType,
                       
                        PersonId = App._LoginUserID
                    });
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                //make fields empty after saving
                entryDate.SetValue(DatePicker.MinimumDateProperty, DateTime.Now);
                entryDate.SetValue(DatePicker.MaximumDateProperty, DateTime.Now.AddDays(180));
                _ticketTimePicker.Time = DateTime.Now.TimeOfDay;

                airLine = arriveTo = ticketType  = depFrom = "";
               

                //display save alert message
                await DisplayAlert("Alert", "Booking done successfully.", "OK");

                //opening Main Page
                await Application.Current.MainPage.Navigation.PopAsync();
            }

        }

        private string depFrom;
        private string arriveTo;
        private string airLine;
        private string ticketType;
        void OnDepFromSelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem;
            depFrom = selectedItem.ToString();
        }

        void OnArriveToSelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem;
            arriveTo = selectedItem.ToString();
        }
        //OnTcketTypeSelectedIndexChanged

       
        void OnAirlineSelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem;
            airLine = selectedItem.ToString();
        }

        void OnTcketTypeSelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem;
            ticketType = selectedItem.ToString();
        }



        private async Task<bool> ValidateEntriesAsync()
        {
            bool fieldsStatus = true;
            if (string.IsNullOrWhiteSpace(depFrom))
            {
                fieldsStatus = false;
            }

            if (string.IsNullOrWhiteSpace(arriveTo))
            {
                fieldsStatus = false;
            }

            if (string.IsNullOrWhiteSpace(airLine))
            {
                fieldsStatus = false;
            }
            if (!fieldsStatus)
            {
                await DisplayAlert("Alert", "Please fill enpty fields.", "OK");
            }

            return fieldsStatus;
        }

    }
}