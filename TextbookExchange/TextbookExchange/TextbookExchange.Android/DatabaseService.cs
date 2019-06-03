using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using SQLitePCL;
using SQLitePCL.lib;
using TextbookExchange.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using SQLite.Net;

[assembly:Dependency(typeof(DatabaseService))]
namespace TextbookExchange.Droid
{
    public class DatabaseService : IDatabaseConnection
    {

        public SQLite.SQLiteConnection DbConnection()
        {
            var dbName = "TEDatabase.db";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);

            return new SQLite.SQLiteConnection(path);
        }

      

        //public DatabaseService(){}

        //public SQLite.Net.SQLiteConnection GetConnection()
        //{
        //    var sqliteFilename = "UserDatabase.db";
        //    string documentsDirectoryPath = 
        //    var path = Path.Combine(documentsDirectoryPath, sqliteFilename);

        //    //var connection = new SQLiteConnection(path);
        //    //return connection;

        //    // This is where we copy in our pre-created database
        //    if (!File.Exists(path))
        //    {
        //        using (var binaryReader = new BinaryReader(Android.App.Application.Context.Assets.Open(sqliteFilename)))
        //        {
        //            using (var binaryWriter = new BinaryWriter(new FileStream(path, FileMode.Create)))
        //            {
        //                byte[] buffer = new byte[2048];
        //                int length = 0;
        //                while ((length = binaryReader.Read(buffer, 0, buffer.Length)) > 0)
        //                {
        //                    binaryWriter.Write(buffer, 0, length);
        //                }
        //            }
        //        }
        //    }

        //    var plat = new SQLitePlatformAndroid();
        //    var conn = new SQLite.Net.SQLiteConnection(plat, path);

        //    return conn;
        //}

        //public string GetLocalFilePath(string fileName)
        //{
        //    string fileLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        //    string fullPath = Path.Combine(fileLocation, fileName);

        //    string docFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        //    string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

        //    //if (!Directory.Exists(libFolder))
        //    //{
        //    //    Directory.CreateDirectory(libFolder);
        //    //}
           
        //    return fullPath;         
        //}



        //void ReadWriteStream(Stream readStream, Stream writeStream)
        //{
        //    int Length = 256;
        //    Byte[] buffer = new Byte[Length];
        //    int bytesRead = readStream.Read(buffer, 0, Length);
        //    while (bytesRead >= 0)
        //    {
        //        writeStream.Write(buffer, 0, bytesRead);
        //        bytesRead = readStream.Read(buffer, 0, Length);
        //    }
        //    readStream.Close();
        //    writeStream.Close();
        //}
    }
}