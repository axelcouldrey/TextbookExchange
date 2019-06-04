using System;
using System.Linq;
using Xamarin.Forms;

namespace TextbookExchange
{
    public partial class SignUpPage : ContentPage
    {
        private string confirmPassword;
        private int EmailUsed;

        public SignUpPage()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        //Method called when sign up button clicked
        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            var user = new User()
            {
                Email = emailEntry.Text,
                Password = passwordEntry.Text,
                FirstName = firstName.Text,
                LastName = lastName.Text,
                University = university.Text
            };

            this.confirmPassword = confirmPasswordEntry.Text;

            //Sign up logic checking if input details are valid
            if (AreDetailsValid(user))
            {
                App.Database.SaveUser(user);
                App.IsUserLoggedIn = true;

                //await Navigation.PushAsync(new UserEnvironment());

                //Navigation.InsertPageBefore(new UserEnvironment(), this);
                //await Navigation.PopAsync();

                var rootPage = Navigation.NavigationStack.FirstOrDefault();


                if (rootPage != null)
                {
                    App.IsUserLoggedIn = true;
                    Navigation.InsertPageBefore(new UserEnvironment(user.UserID), this);
                    await Navigation.PopAsync();
                }
            }
            else
            {
                if(EmailUsed == 1)
                    messageLabel.Text = "E-mail already in Use";
                else
                    messageLabel.Text = "Please re-enter information correctly";
            }
        }

        //Return true if details are valid(Email not already in use & inputs correct)
        bool AreDetailsValid(User user)
        {
            User temp = App.Database.GetUser(user.Email);

            EmailUsed = 0;

            if(temp == null)
            {
                return (!string.IsNullOrWhiteSpace(user.Email)
                    && user.Email.Contains("@") && user.Email.Contains(".")
                    && !string.IsNullOrWhiteSpace(user.Password) && this.confirmPassword.Equals(user.Password)
                    && !string.IsNullOrEmpty(user.FirstName) && !string.IsNullOrEmpty(user.LastName) && !string.IsNullOrEmpty(user.University));
            }

            EmailUsed = 1;
            return false;
        }
    }
}
