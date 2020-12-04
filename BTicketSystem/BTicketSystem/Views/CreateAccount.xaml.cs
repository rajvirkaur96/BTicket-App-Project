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
    public partial class CreateAccount : ContentPage
    {
        public CreateAccount()
        {
            InitializeComponent();
        }


        async void OnButtonClicked(object sender, EventArgs e)
        {
            //Fields null check
            if (!string.IsNullOrWhiteSpace(entryEmail.Text) && !string.IsNullOrWhiteSpace(entryPassword.Text))
            {
                try
                {
                    //Ccreate userifo object to save data
                    await App.Database.SaveUserAsync(new Models.UserInfo
                    {
                        PersonName = entryName.Text,
                        PersonEmail = entryEmail.Text,
                        PersonPassword = entryPassword.Text,
                        PersonContact = entryContact.Text
                    });
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                
                //makee fields empty
                entryName.Text = entryPassword.Text = entryContact.Text = string.Empty;

                //save alert message
                await DisplayAlert("Alert", "Account created successfully.", "OK");

                //open login Page
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }
    }
}