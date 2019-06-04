using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TextbookExchange
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserEnvironment : TabbedPage
    {
        User user;

        public UserEnvironment(int userID)
        {
            this.user = App.Database.GetUser(userID);
            this.Title = "Home";

            //var navigationPage1 = new NavigationPage(new ProfilePage(this.user));
            //navigationPage1.Title = "Profile";
            //var navigationPage2 = new NavigationPage(new MyListings(this.user));
            //navigationPage2.Title = "My Listings";
            //var navigationPage3 = new NavigationPage(new PubListings(this.user));
            //navigationPage3.Title = "Public Listings";

            ToolbarItem logOut = new ToolbarItem
            {
                Text = "Log Out"
            };
            ToolbarItems.Add(logOut);
            logOut.Clicked += OnLogoutButtonClicked;

            this.Children.Add(new ProfilePage(this.user, this));
            this.Children.Add(new MyListings(this.user));
            this.Children.Add(new PubListings(this.user));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasBackButton(this, false);
            //NavigationPage.SetHasNavigationBar(this, false);
        }

        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }

        //async void OnListingClicked(object sender, EventArgs e)
        //{
        //    //var db = new SQLite.SQLiteConnection(App.DB_PATH);
        //    //var result = db.Table<Book>().Where()
        //    //await Navigation.PushAsync(new Listing());
        //}

        public class ProfilePage : ContentPage
        {
            UserEnvironment uE;
            User user;

            public ProfilePage(User user, UserEnvironment uE)
            {
                this.uE = uE;
                this.user = user;

                this.Title = "Profile";
                this.BackgroundColor = Color.White;

                string F_Name = "First Name: " + user.FirstName;
                string L_Name = "Last Name: " + user.LastName;
                string Uni = "University: " + user.University;
                string Email = "Email: " + user.Email;

                string hiddenPass = "";
                for(int k = 0; k < user.Password.Length; ++k)
                {
                    hiddenPass += "*";
                }

                string Pass = "Password: " + hiddenPass;

                var firstNameLabel = new Label { Text = F_Name, FontSize = 12, VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.Center };
                var lastNameLabel = new Label { Text = L_Name, FontSize = 12, VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.Center };
                var uniLabel = new Label { Text = Uni, FontSize = 12, VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.Center };
                var emailLabel = new Label { Text = Email, FontSize = 12, VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.Center };
                var passLabel = new Label { Text = Pass, FontSize = 12, VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.Center };

                Button button = new Button
                {
                    Text = "Update Profile",
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.Center
                };
                button.Clicked += OnUpdateInfoButtonCLicked;

                StackLayout s1 = new StackLayout();

                s1.Children.Add(
                    new Label
                    {
                        Text = "Filler",
                        TextColor = Color.White,
                    });

                s1.Children.Add(firstNameLabel);
                s1.Children.Add(lastNameLabel);
                s1.Children.Add(uniLabel);
                s1.Children.Add(emailLabel);
                s1.Children.Add(passLabel);
                s1.Children.Add(button);

                this.Content = s1;
            }

            async void OnUpdateInfoButtonCLicked(object sender, EventArgs e)
            {
                Navigation.InsertPageBefore(new Profile(this.user), this.uE);
                await Navigation.PopAsync();
            }
        }

        public class MyListings : ContentPage
        {
            UserEnvironment uE;
            User user;

            public MyListings(User user, UserEnvironment uE)
            {
                this.Title = "My Listings";
                this.user = user;
                this.uE = uE;

                ObservableCollection<Listing> listings = new ObservableCollection<Listing>();
                listings = App.Database.GetAllListingWithUser(user.UserID);

                var listView = new ListView();
                listView.ItemsSource = listings;

                Button button = new Button
                {
                    Text = "Add Book",
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.Center
                };
                button.Clicked += OnAddBookButtonClicked;

                StackLayout s1 = new StackLayout();
                s1.Children.Add(listView);
                s1.Children.Add(button);

                this.Content = s1;
            }

            async void OnAddBookButtonClicked(object sender, EventArgs e)
            {
                Navigation.InsertPageBefore(new AddBook(this.user), this.uE);
                await Navigation.PopAsync();
            }
        }

        public class PubListings : ContentPage
        {
            public PubListings(User user)
            {
                this.Title = "Public Listings";


                
            }

           
        }
    }
}
