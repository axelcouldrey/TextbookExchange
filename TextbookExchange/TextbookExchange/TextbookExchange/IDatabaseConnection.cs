using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextbookExchange
{
    public interface IDatabaseConnection
    {
        SQLiteConnection DbConnection();
        //string GetLocalFilePath(string fileName);
    }
}
