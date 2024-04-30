using Microsoft.Data.Sqlite;

namespace web_api_csharp.Models.Repos
{
    public class BaseRepository
    {
        private static string DbFile
        {
            get { return Environment.CurrentDirectory + "\\gzpr.db"; }
        }

        public static SqliteConnection Connection()
        {
            return new SqliteConnection(String.Format("Data Source={0}", DbFile));
        }
    }
}
