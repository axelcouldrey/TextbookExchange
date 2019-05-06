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
using TextbookExchange.Droid;
using Xamarin.Forms;

[assembly:Dependency(typeof(DatabaseService))]
namespace TextbookExchange.Droid
{
    public class DatabaseService: IDBInterface
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "UserDatabase.db";
            string documentsDirectoryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(documentsDirectoryPath, sqliteFilename);
            var connection = new SQLiteConnection(path);
            return connection;

            // This is where we copy in our pre-created database
            if (!File.Exists(path))
            {
                using (var binaryReader = new BinaryReader(Android.App.Application.Context.Assets.Open(sqliteFilename)))
                {
                    using (var binaryWriter = new BinaryWriter(new FileStream(path, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int length = 0;
                        while ((length = binaryReader.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            binaryWriter.Write(buffer, 0, length);
                        }
                    }
                }
            }
            //var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            //var conn = new SQLite.Net.SQLiteConnection(plat, path);

            //return conn;
            return null;
        }

        void ReadWriteStream(Stream readStream, Stream writeStream)
        {
            int Length = 256;
            Byte[] buffer = new Byte[Length];
            int bytesRead = readStream.Read(buffer, 0, Length);
            while (bytesRead >= 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = readStream.Read(buffer, 0, Length);
            }
            readStream.Close();
            writeStream.Close();
        }
    }
}