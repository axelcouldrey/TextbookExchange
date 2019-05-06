using SQLite;
using System;
namespace TextbookExchange
{
    public class User
    {
        public int ID { get; set; }

        [MaxLength(25)]
        public string UserName { get; set; }

        [MaxLength(15)]
        public string Password { get; set; }

        [MaxLength(15)]
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
    }
}
