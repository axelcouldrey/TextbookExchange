using System;
using SQLite;

namespace TextbookExchange
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int BookID { get; set; }

        [NotNull]
        public string Title { get; set; }
        [NotNull]
        public string Author { get; set; }
        [NotNull]
        public string Published { get; set; }
       
    }
}
