using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextbookExchange
{
    public class Listing
    {
        [PrimaryKey, AutoIncrement]
        public int ListingID { get; set; }

        public int UserRef { get; set; }

        public int BookRef { get; set; }
         
        [NotNull]
        public bool Live { get; set; }

    }
}
