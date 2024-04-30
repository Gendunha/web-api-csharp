using Dapper;
using Microsoft.Data.Sqlite;

namespace web_api_csharp.Models.Repos
{
    public class WorkshopRepository : IWorkshopRepository
    {
        public List<Workshop> Get()
        {
            using (SqliteConnection conn = BaseRepository.Connection())
            {
                string query = @"SELECT * FROM workshops;";
                conn.Open();

                return conn.Query<Workshop>(query).ToList();
            }
        }

        public object GetById(int id)
        {
            using (SqliteConnection conn = BaseRepository.Connection())
            {
                string query = @"SELECT * FROM workshops WHERE id=@id;";
                conn.Open();

                return conn.Query(query, new { id }).FirstOrDefault();
            }
        }

        public void Create(Workshop model)
        {
            using (SqliteConnection conn = BaseRepository.Connection())
            {
                string query = @"INSERT INTO workshops('name') VALUES (@name);";
                conn.Open();

                var result = conn.Query(query, model);
            }
        }

        public void Update(Workshop model)
        {
            using (SqliteConnection conn = BaseRepository.Connection())
            {
                string query = @"UPDATE workshops SET name=@name WHERE id=@id;";
                conn.Open();

                conn.Query(query, model);
            }
        }

        public void Delete(int id)
        {
            using (SqliteConnection conn = BaseRepository.Connection())
            {
                string query = @"DELETE FROM workshops WHERE id=@id;";
                conn.Open();

                conn.Query(query, new { id });
            }
        }
    }
}
