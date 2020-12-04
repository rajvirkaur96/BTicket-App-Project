using BTicketSystem.Models;
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
    public partial class InfoPage : ContentPage
    {
        UserInfo userData;
        public InfoPage()
        {
            InitializeComponent();

            lblName.Text = " " + App._LoginUserName;
            lblEmail.Text = "Email : " + App._LoginUserEmail;
            lblContact.Text = "Contact Number : " + App._LoginUserContact;
            lblID.Text = "User ID : " + App._LoginUserID;

           // getUSerData();

        }

       
    }
}