using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TextbookExchange
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserEnvironment : TabbedPage
    {
        public UserEnvironment()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Book>();
                var books = conn.Table<Book>().ToList();
                bookListings.ItemsSource = books;
            }
        }

        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            //  TODO: Log out
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }

        async void OnEditBookButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new AddBook(), this);
            await Navigation.PopAsync();
        }

        async void OnListingClicked(object sender, EventArgs e)
        {
            //var db = new SQLite.SQLiteConnection(App.DB_PATH);
            //var result = db.Table<Book>().Where()


            await Navigation.PushAsync(new Listing());


        }
    }
}
