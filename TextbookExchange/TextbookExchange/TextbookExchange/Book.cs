using System;
using SQLite;

namespace TextbookExchange
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Published { get; set; }
    }
}
