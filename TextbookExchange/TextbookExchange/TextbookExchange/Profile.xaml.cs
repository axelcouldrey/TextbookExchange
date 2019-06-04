using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TextbookExchange
{
    public partial class Profile : ContentPage
    {
        User user;
        StackLayout s1;

        Entry FNameEntry;
        Entry LNameEntry;
        Entry UniEntry;
        Entry EmailEntry;
        Entry PassEntry;

        public Profile(User user)
        {
            InitializeComponent();
            this.user = user;

            this.Title = "Update Profile";
            this.BackgroundColor = Color.White;

            FNameEntry = new Entry { Placeholder = user.FirstName };
            LNameEntry = new Entry { Placeholder = user.LastName };
            UniEntry = new Entry { Placeholder = user.University };
            EmailEntry = new Entry { Placeholder = user.Email };

            string hiddenPass = "";
            for (int k = 0; k < user.Password.Length; ++k)
            {
                hiddenPass += "*";
            }

            PassEntry = new Entry { Placeholder = hiddenPass };

            Button button = new Button
            {
                Text = "Update",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            button.Clicked += UpdateProfileButtonClicked;

            s1 = new StackLayout();

            s1.Children.Add(
                new Label
                {
                    Text = "Filler",
                    TextColor = Color.White,
                });

            s1.Children.Add(FNameEntry);
            s1.Children.Add(LNameEntry);
            s1.Children.Add(UniEntry);
            s1.Children.Add(EmailEntry);
            s1.Children.Add(PassEntry);
            s1.Children.Add(button);

            this.Content = s1;
        }

        private async void UpdateProfileButtonClicked(object sender, EventArgs e)
        {
            if(FNameEntry.Text != null)
                this.user.FirstName = FNameEntry.Text;

            if(LNameEntry.Text != null)
                this.user.LastName = LNameEntry.Text;

            if (UniEntry.Text != null)
                this.user.University = UniEntry.Text;

            if (EmailEntry.Text != null)
                this.user.Email = EmailEntry.Text;

            if (PassEntry.Text != null)
                this.user.Password = PassEntry.Text;

            App.Database.SaveUser(this.user);

            Navigation.InsertPageBefore(new UserEnvironment(this.user.UserID), this);
            await Navigation.PopAsync();
        }
    }
}
