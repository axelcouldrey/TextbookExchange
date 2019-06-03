using SQLite;
using System;
using System.Collections.Generic;

namespace TextbookExchange
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserID { get; set; }

        [NotNull]
        public string Email { get; set; }

        [MaxLength(15), NotNull]
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string University { get; set; }

    }
}
