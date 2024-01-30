using Dapper;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace NoteTakingApp
{
    public class SqliteDataAccess
    {
        public static ObservableCollection<Note> LoadNotes()
        {
            using(IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Note>("select * from Notes", new DynamicParameters());
                return new ObservableCollection<Note>(output);
            }
        }

        public static void SaveNote(Note note) 
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Notes(Title, NoteText) values (@Title, @NoteText)", note);
            }
        }
        
        public static void DeleteNote(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("DELETE FROM Notes WHERE Id = @Id", new { Id = id });
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
