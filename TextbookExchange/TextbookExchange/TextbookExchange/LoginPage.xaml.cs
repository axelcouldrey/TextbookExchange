using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
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
            var user = new User()
            {
                UserName = usernameEntry.Text,
                Password = passwordEntry.Text
            };

            if (AreCredentialsCorrect(user))
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
            var db =  
            var data = db.Table<Users>(); //Call table
            var data1 = data.Where(x => x.UserName == usernameEntry.Text && x.Password == passwordEntry.Text);

            if (data1 != null)
                LoginLabel.Text = "Login Success";
            else
                LoginLabel.Text = "Username or Password invalid";




            //Check each user name for match - then subseqently if password matches.
            return user.UserName == Constants.Username && user.Password == Constants.Password;
        }
    }
}
