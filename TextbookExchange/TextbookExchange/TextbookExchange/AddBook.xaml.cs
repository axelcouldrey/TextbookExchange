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
        Entry BookTitleEntry;
        Entry BookAuthorEntry;
        Entry BookPubDateEntry;

        User user;

        public AddBook(User user)
        {
            //InitializeComponent();

            this.user = user;

            this.Title = "Add Book";
            this.BackgroundColor = Color.White;

            BookTitleEntry = new Entry { Placeholder = "Title" };
            BookAuthorEntry = new Entry { Placeholder = "Author" };
            BookPubDateEntry = new Entry { Placeholder = "Date" };

            Button button = new Button
            {
                Text = "Add",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            button.Clicked += OnSubmitButtonClicked;

            StackLayout s1 = new StackLayout();
            s1.Children.Add(BookTitleEntry);
            s1.Children.Add(BookAuthorEntry);
            s1.Children.Add(BookPubDateEntry);
            s1.Children.Add(button);

            this.Content = s1;
        }

        async void OnSubmitButtonClicked(object sender, EventArgs e)
        {
            Book book = new Book()
            {
                Title = BookTitleEntry.Text,
                Author = BookAuthorEntry.Text,
                Published = BookPubDateEntry.Text
            };

            App.Database.SaveBook(book);

            Listing listing = new Listing()
            {
                Live = true,
                BookRef = book.BookID,
                UserRef = this.user.UserID
            };

            App.Database.SaveListing(listing);

            Navigation.InsertPageBefore(new UserEnvironment(this.user.UserID), this);
            await Navigation.PopAsync();
        }
    }
}
