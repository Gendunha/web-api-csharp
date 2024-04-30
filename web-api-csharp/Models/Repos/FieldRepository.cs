using Dapper;
using Microsoft.Data.Sqlite;

namespace web_api_csharp.Models.Repos
{
    public class FieldRepository : IFieldRepository
    {
        public List<Field> Get()
        {
            using (SqliteConnection conn = BaseRepository.Connection())
            {
                string query = @"SELECT * FROM fields;";
                conn.Open();

                return conn.Query<Field>(query).ToList();
            }
        }

        public object GetById(int id)
        {
            using (SqliteConnection conn = BaseRepository.Connection())
            {
                string query = @"SELECT * FROM fields WHERE id=@id;";
                conn.Open();

                return conn.Query(query, new { id }).FirstOrDefault();
            }
        }

        public void Create(Field model)
        {
            using (SqliteConnection conn = BaseRepository.Connection())
            {
                string query = @"INSERT INTO fields ('name') VALUES (@name);";
                conn.Open();

                var result = conn.Query(query, model);
            }
        }

        public void Update(Field model)
        {
            using (SqliteConnection conn = BaseRepository.Connection())
            {
                string query = @"UPDATE fields SET name=@name WHERE id=@id;";
                conn.Open();

                conn.Query(query, model);
            }
        }

        public void Delete(int id)
        {
            using (SqliteConnection conn = BaseRepository.Connection())
            {
                string query = @"DELETE FROM fields WHERE id=@id;";
                conn.Open();

                conn.Query(query, new { id });
            }
        }
    }
}
