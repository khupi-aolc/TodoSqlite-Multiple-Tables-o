using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BellApp.Datas
{
    public interface IDatabase
    {
        SQLiteConnection GetConnection();
    }
}
