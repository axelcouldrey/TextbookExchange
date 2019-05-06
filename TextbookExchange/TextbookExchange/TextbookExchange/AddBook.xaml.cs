using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using SQLite;
using Xamarin.Forms;

namespace TextbookExchange
{
    public partial class AddBook : ContentPage
    {

        public AddBook()
        {
            InitializeComponent();
        }

        async void OnSubmitButtonClicked(object sender, EventArgs e)
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
    }
}
