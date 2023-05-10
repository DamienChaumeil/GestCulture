using AppGestCulture.Models;
using SQLite;

namespace AppGestCulture.Data
{

    public class Database
    {
        private SQLiteAsyncConnection connection;
        public Database()
        {
        }

        async Task Init()
        {
            if (connection is not null)
                return;

            connection = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var Tech = await connection.CreateTableAsync<Technicien>();
            var Parc = await connection.CreateTableAsync<Parcelle>();
            var espe = await connection.CreateTableAsync<Espece>();


        }
        
    }
}