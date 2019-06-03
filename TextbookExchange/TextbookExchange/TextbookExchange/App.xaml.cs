using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TextbookExchange
{
    public partial class App : Application
    {
        static DataAccess databse;

        public static bool IsUserLoggedIn { get; set; }
        //public static string DB_PATH = string.Empty;

        public App()
        {
            InitializeComponent();

            if (!IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new MainPage());
            }
        }

        public static DataAccess Database
        {
            get
            {
                if(databse == null)
                {
                    databse = new DataAccess();
                }

                return databse;
            }

        }

        //public App(string dbPath)
        //{
        //    InitializeComponent();

        //    DB_PATH = dbPath;

        //    if (!IsUserLoggedIn)
        //    {
        //        MainPage = new NavigationPage(new LoginPage());
        //    }
        //    else
        //    {
        //        MainPage = new NavigationPage(new MainPage());
        //    }
        //}

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
