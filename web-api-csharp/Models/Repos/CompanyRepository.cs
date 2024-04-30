using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace web_api_csharp.Models.Repos
{
    public class CompanyRepository : ICompanyRepository
    {

        public List<Company> Get()
        {
            using (SqliteConnection conn = BaseRepository.Connection())
            {
                string query = @"SELECT * FROM companies;";
                conn.Open();

                return conn.Query<Company>(query).ToList();
            }
        }

        public object GetById(int id)
        {
            using (SqliteConnection conn = BaseRepository.Connection())
            {
                string query = @"SELECT * FROM companies WHERE id=@id;";
                conn.Open();

                return conn.Query(query, new { id }).FirstOrDefault();
            }
        }

        public void Create(Company model)
        {
            using (SqliteConnection conn = BaseRepository.Connection())
            {
                string query = @"INSERT INTO companies ('name') VALUES (@name);";
                conn.Open();

                var result = conn.Query(query, model);
            }
        }

        public void Update(Company model)
        {
            using (SqliteConnection conn = BaseRepository.Connection())
            {
                string query = @"UPDATE companies SET name=@name WHERE id=@id;";
                conn.Open();

                conn.Execute(query, new { name = model.Name, id = model.Id });
            }
        }

        public void Delete(int id)
        {
            using (SqliteConnection conn = BaseRepository.Connection())
            {
                string query = @"DELETE FROM companies WHERE id=@id;";
                conn.Open();

                conn.Query(query, new { id });
            }
        }
    }
}
