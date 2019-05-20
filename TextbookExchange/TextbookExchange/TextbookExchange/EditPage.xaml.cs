using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TextbookExchange
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPage : TabbedPage
    {
        public EditPage()
        {
            InitializeComponent();
        }

        async void OnAddBookButtonClicked(object sender, System.EventArgs e)
        {
            App.IsUserLoggedIn = false;

            Book book = new Book()
            {
                Title = titleEntry.Text,
                Author = authorEntry.Text,
                Published = yearEntry.Text
            };


            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Book>();
                var numberOfRows = conn.Insert(book);

                if (numberOfRows > 0)
                {
                    await DisplayAlert("Success", "Added book", "Continue");
                }
                else
                {
                    await DisplayAlert("Failed", "Fail to add book", "Continue");
                }
            }

            await Navigation.PushAsync(new UserEnvironment());
        }

        async void OnUpdateBookClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new UserEnvironment());
        }

        async void OnDeleteBookClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new UserEnvironment());
        }
    }
    // Stash01
    // Stash02
    // GitHub Desktop
}