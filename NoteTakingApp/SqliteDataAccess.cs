using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteTakingApp
{
    public class SqliteDataAccess
    {
        public static List<Note> LoadNotes()
        {
            using(IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Note>("select * from Note", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveNote(Note note) 
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {

            }
        }
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
