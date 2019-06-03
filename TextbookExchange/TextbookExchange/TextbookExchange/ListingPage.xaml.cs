using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TextbookExchange
{
    public partial class ListingPage : ContentPage
    {
        private Book book;

        public ListingPage()
        {
            InitializeComponent();
        }

        public ListingPage(string Title, string Author, string Published)
        {
            book = new Book
            {
                Title = Title,
                Author = Author,
                Published = Published
            };
        }
    }
}
