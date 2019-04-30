using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TextbookExchange
{
    public partial class Profile : ContentPage
    {
        public Profile()
        {
            InitializeComponent();
        }

        private async void UpdateProfileButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = true;
            Navigation.InsertPageBefore(new UserEnvironment(), this);
            await Navigation.PopAsync();
        }


    }
}
