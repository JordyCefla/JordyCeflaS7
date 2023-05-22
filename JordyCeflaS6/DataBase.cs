using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace JordyCeflaS6
{
    public interface DataBase
    {
        SQLiteAsyncConnection GetConnection();

    }
}
