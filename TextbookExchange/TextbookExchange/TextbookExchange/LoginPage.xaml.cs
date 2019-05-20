using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            //var db = new SQLiteConnection(App.DB_PATH);
            //var result = db.Table<User>().Where(x => x.UserName == usernameEntry.Text && x.Password == passwordEntry.Text).ToList();

            //return (result.Count() > 0);
            return user.UserName == Constants.Username && user.Password == Constants.Password;    

            //Check each user name for match - then subseqently if password matches.??
           
        }
    }
}
