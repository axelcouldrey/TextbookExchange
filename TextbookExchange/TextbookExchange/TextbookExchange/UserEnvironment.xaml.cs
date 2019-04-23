using System;
using System.Collections.Generic;
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
        public UserEnvironment()
        {
            InitializeComponent();
        }

        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            //  TODO: Log out
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }

        async void OnAddBookButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new AddBook(), this);
            await Navigation.PopAsync();
        }
    }
}
