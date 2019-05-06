using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TextbookExchange
{
    public partial class Listing : ContentPage
    {
        private Book book;

        public Listing()
        {
            InitializeComponent();
        }

        public Listing(string Title, string Author, string Published)
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
