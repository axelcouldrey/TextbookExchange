using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace TextbookExchange
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            var user = new User()
            {
                UserName = usernameEntry.Text,
                Email = emailEntry.Text,
                Password = passwordEntry.Text,
                ConfirmPassword = confirmPasswordEntry.Text,
            };

            // Sign up logic goes here
            if (AreDetailsValid(user))
            {
                var rootPage = Navigation.NavigationStack.FirstOrDefault();

                using (var db = new SQLiteConnection((App.DB_PATH)))
                {
                    db.CreateTable<User>();
                    var numberOfRows = db.Insert(user);

                    if (numberOfRows > 0)
                        messageLabel.Text = "User added";
                    else
                        messageLabel.Text = "Failure to register (databse error)";
                }

                if (rootPage != null)
                {
                    App.IsUserLoggedIn = true;
                    Navigation.InsertPageBefore(new Profile(), Navigation.NavigationStack.First());
                    await Navigation.PopToRootAsync();
                }
            }
            else
            {
                messageLabel.Text = "Sign up failed";
            }
        }

        async void OnBackButtonClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new Profile(), Navigation.NavigationStack.First());
            await Navigation.PopToRootAsync();
        }

        bool AreDetailsValid(User user)
        {
            return (!string.IsNullOrWhiteSpace(user.UserName) && !string.IsNullOrWhiteSpace(user.Email) 
                && user.Email.Contains("@") && user.Email.Contains(".") 
                && !string.IsNullOrWhiteSpace(user.Password) && user.ConfirmPassword.Equals(user.Password));
        }
    }
}
