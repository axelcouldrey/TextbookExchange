using SQLite;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace TextbookExchange
{
    public class DataAccess
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();

        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Listing> Listings { get; set; }
        public ObservableCollection<Book> Books { get; set; }

        public DataAccess()
        {
            //Database currently local - Azure services can be implemented
            //Get the Database Connection here saving locally
            database = DependencyService.Get<IDatabaseConnection>().DbConnection();

            //CreateTable creates only if Table doesn't exist.
            database.CreateTable<User>();
            database.CreateTable<Listing>();
            database.CreateTable<Book>();

            //Lists to store table objects
            this.Users = new ObservableCollection<User>(database.Table<User>());
            this.Listings = new ObservableCollection<Listing>(database.Table<Listing>());
            this.Books = new ObservableCollection<Book>(database.Table<Book>());

            //Initialise with placeholders if table is empty 
            if (!database.Table<User>().Any())
            {
                InitialiseUsers();
            }

            if (!database.Table<Listing>().Any())
            {
                InitialiseListings();
            }

            if (!database.Table<Book>().Any())
            {
                InitialiseBooks();
            }

        }

        public void InitialiseUsers()
        {
            this.Users.Add(new User
            {
                UserID = 0,
                Password = "xxx",
                Email = "xxx",
                FirstName = null,
                LastName = null,
                University = null
            });
        }

        public void InitialiseListings()
        {
            this.Listings.Add(new Listing
            {
                BookRef = 0,
                Live = false,
                ListingID = 0,
                UserRef = 0
            });
        }

        public void InitialiseBooks()
        {
            this.Books.Add(new Book
            {
                BookID = 0,
                Author = "Auth",
                Title = "Tit",
                Published = "Pub"
            });
        }

        //Databse access methods to be used to save/delete/update/get table objects 
        public int SaveUser(User user)
        {
            lock(collisionLock)
            {
                if(user.UserID != 0)
                {
                    database.Update(user);
                    return user.UserID;
                }
                else
                {
                    database.Insert(user);
                    return user.UserID;
                }
            }
        }

        public void SaveAllUsers()
        {
            lock(collisionLock)
            {
                foreach(var user in this.Users)
                {
                    if(user.UserID != 0)
                    {
                        database.Update(user);
                    }
                    else
                    {
                        database.Insert(user);
                    }
                }
            }
        }

        public User GetUser(int id)
        {
            lock(collisionLock)
            {
                return database.Table<User>().FirstOrDefault(user => user.UserID == id);
            }
        }

        public User GetUser(string userEmail)
        {
            lock(collisionLock)
            {
                return database.Table<User>().FirstOrDefault(email => email.Email == userEmail);
            }
        }


        public int DeleteUser(User user)
        {
            var id = user.UserID;

            if (id != 0)
            {
                lock(collisionLock)
                {
                    database.Delete<User>(id);
                }
            }

            this.Users.Remove(user);
            return id;
        }

        public int SaveListing(Listing list)
        {
            lock (collisionLock)
            {
                if (list.ListingID != 0)
                {
                    database.Update(list);
                    return list.ListingID;
                }
                else
                {
                    database.Insert(list);
                    return list.ListingID;
                }
            }
        }

        public void SaveAllListings()
        {
            lock (collisionLock)
            {
                foreach (var list in this.Listings)
                {
                    if (list.ListingID != 0)
                    {
                        database.Update(list);
                    }
                    else
                    {
                        database.Insert(list);
                    }
                }
            }
        }

        public Listing GetListing(int id)
        {
            lock (collisionLock)
            {
                return database.Table<Listing>().FirstOrDefault(list => list.ListingID == id);
            }
        }

        public ObservableCollection<Listing> GetAllListingWithBook(int bookRef)
        {
            lock(collisionLock)
            {
                ObservableCollection<Listing> listings = new ObservableCollection<Listing>();
                List<Listing> genListings = new List<Listing>();

                genListings = database.Table<Listing>().ToList();

                foreach (Listing listn in genListings)
                {
                    if (listn.BookRef == bookRef)
                    {
                        listings.Add(listn);
                    }
                }

                return listings;
            }
        }

        public ObservableCollection<Listing> GetAllListingWithUser(int userRef)
        {
            lock (collisionLock)
            {
                ObservableCollection<Listing> listings = new ObservableCollection<Listing>();
                List<Listing> genListings = new List<Listing>();

                genListings = database.Table<Listing>().ToList();

                foreach(Listing listn in genListings)
                {
                    if(listn.UserRef == userRef)
                    {
                        listings.Add(listn);
                    }
                }

                return listings;
            }
        }


        public int DeleteListing(Listing list)
        {
            var id = list.ListingID;

            if (id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete<Listing>(id);
                }
            }

            this.Listings.Remove(list);
            return id;
        }

        public int SaveBook(Book book)
        {
            lock (collisionLock)
            {
                if (book.BookID != 0)
                {
                    database.Update(book);
                    return book.BookID;
                }
                else
                {
                    database.Insert(book);
                    return book.BookID;
                }
            }
        }

        public void SaveAllBooks()
        {
            lock (collisionLock)
            {
                foreach (var book in this.Books)
                {
                    if (book.BookID != 0)
                    {
                        database.Update(book);
                    }
                    else
                    {
                        database.Insert(book);
                    }
                }
            }
        }

        public Book GetBook(int id)
        {
            lock (collisionLock)
            {
                return database.Table<Book>().FirstOrDefault(book => book.BookID == id);
            }
        }


        public int DeleteBook(Book book)
        {
            var id = book.BookID;

            if (id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete<Book>(id);
                }
            }

            this.Books.Remove(book);
            return id;
        }
    }
}
