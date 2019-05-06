using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextbookExchange
{
    public interface IDBInterface
    {
        SQLiteConnection GetConnection();
    }
}
