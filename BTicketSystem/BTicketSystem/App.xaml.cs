using BTicketSystem.Data;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BTicketSystem
{
    public partial class App : Application
    {

        static Database database;
        public static string _LoginUserName { get; set; }
        public static int _LoginUserID { get; set; }

        public static string _LoginUserEmail { get; set; }

        public static string _LoginUserContact { get; set; }
        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TicketBookingDB.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();

            MainPage = new NavigationPage(new BTicketSystem.Views.AppLoginPage());
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
