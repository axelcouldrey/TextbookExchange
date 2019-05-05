using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TextbookExchange
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                UserName = usernameEntry.Text,
                Password = passwordEntry.Text
            };

            var isValid = AreCredentialsCorrect(user);
            if (isValid)
            {
                App.IsUserLoggedIn = true;
                Navigation.InsertPageBefore(new UserEnvironment(), this);
                await Navigation.PopAsync();
            }
            else
            {
                LoginLabel.Text = "Login failed";
                passwordEntry.Text = string.Empty;
            }
        }

        async void OnFacebookButtonClicked(object sender, EventArgs e)
        {
            //add await to external signup here.
        }

        bool AreCredentialsCorrect(User user)
        {
            //Check each user name for match - then subseqently if password matches.
            return user.UserName == Constants.Username && user.Password == Constants.Password;
        }
    }
}
