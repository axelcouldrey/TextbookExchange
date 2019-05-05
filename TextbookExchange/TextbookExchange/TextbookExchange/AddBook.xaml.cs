using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using SQLite;
using Xamarin.Forms;

namespace TextbookExchange
{
    public partial class AddBook : ContentPage
    {
        private SQLiteConnection conn;

        public AddBook()
        {
            InitializeComponent();
            Contract.Ensures(Contract.Result<SQLiteConnection>() != null);


            conn = new SQLiteConnection("DataTrigger Source = Dev.db;Version = 3;new= true;");
        }

        async void OnSubmitButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            //Navigation.InsertPageBefore(new AddBook(), this);
            //await Navigation.PopAsync();
            SQLiteConnection conn;
            //conn.
            //InsertData(conn);
        }



        private void InsertData(SQLiteConnection conn)
        {
            //SQLiteCommand sqlite_cmd;
            //sqlite_cmd = conn.CreateCommand("DataTrigger Source = Dev.db;Version = 3;new= true;");
            //sqlite_cmd.CommandText = "INSERT INTO DevDB (Title, Author, YearPublish) VALUES('book title ', 1); ";sqlite_cmd.ExecuteQuery();


        }
    }
}
