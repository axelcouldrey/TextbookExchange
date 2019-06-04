using System;
using Xamarin.Forms;

namespace TextbookExchange
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            //On constructor assign toolbar signup clickable icon
            var toolbarItem = new ToolbarItem { Text = "Sign up" };

            toolbarItem.Clicked += async (sender, e) =>
                { await Navigation.PushAsync(new SignUpPage() { BindingContext = new User() }); };

            ToolbarItems.Add(toolbarItem);
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var user = new User()
            {
                Email = emailEntry.Text,
                Password = passwordEntry.Text
            };

     
            if (AreCredentialsCorrect(user))
            {
                App.IsUserLoggedIn = true;
                user = App.Database.GetUser(user.Email);
                Navigation.InsertPageBefore(new UserEnvironment(user.UserID), this);
                await Navigation.PopAsync();
            }
            else
            {
                LoginLabel.Text = "Login failed";
                passwordEntry.Text = string.Empty;
            }
        }

        //Checking if the user is already in the databse and if the passwarod is correct
        public bool AreCredentialsCorrect(User user)
        {
            User temp = App.Database.GetUser(user.Email);

            if(temp == null)
                return false;
            else
            {
                if(temp.Password.Equals(user.Password))
                    return true;

                return false;
            }
        }
    }
}
