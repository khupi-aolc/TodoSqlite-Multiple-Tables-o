using BellApp.Datas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(BellApp.Connection.SQLiteConnection))]
namespace BellApp.Connection
{
    class SQLiteConnection : IDatabase
    {
        public SQLite.SQLiteConnection GetConnection()
        {
            var filename = "BellApp.db";
            var documentspath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentspath, filename);
            var connection = new SQLite.SQLiteConnection(path);
            return connection;

        }
    }
}
