using Microsoft.Data.Sqlite;
using System.Reflection;
using Dapper;
using web_api_csharp.Helpers;

namespace web_api_csharp.Models.Repos
{
    public class WellRepository : IWellRepository
    {
        public List<Well> Get()
        {
            using (SqliteConnection conn = BaseRepository.Connection())
            {
                string query = @"SELECT wells.*, companies.*, workshops.*, fields.* FROM wells 
                                                                            INNER JOIN companies ON company_id == companies.id 
                                                                            INNER JOIN workshops ON workshop_id == workshops.id 
                                                                            INNER JOIN fields ON field_id == fields.id;";
                conn.Open();
                var wells = conn.Query<Well, Company, Workshop, Field, Well>(query, (well, company, workshop, field) =>
                {
                    well.Company = company;
                    well.Field = field;
                    well.Workshop = workshop;
                    return well;
                });
                return wells.ToList();
            }
        }

        public object GetById(int id)
        {
            using (SqliteConnection conn = BaseRepository.Connection())
            {
                string query = @"SELECT wells.id, wells.name, companies.id as CompanyId, companies.name as CompanyName, workshops.id as WorkshopId, workshops.name as WorkshopName, fields.id as FieldId, fields.name as FieldName 
                        FROM wells 
                        INNER JOIN companies ON wells.company_id = companies.id 
                        INNER JOIN workshops ON wells.workshop_id = workshops.id 
                        INNER JOIN fields ON wells.field_id = fields.id
                        WHERE wells.id = @id;";
                conn.Open();
                var result = conn.Query<Well, Company, Workshop, Field, Well>(
                    query,
                    (well, company, workshop, field) => {
                        well.Company = company;
                        well.Workshop = workshop;
                        well.Field = field;
                        return well;
                    },
                    new { id },
                    splitOn: "id, CompanyId, WorkshopId, FieldId"
                ).FirstOrDefault();
                return result;
            }
        }

        public void Create(WellRequest model)
        {
            using (SqliteConnection conn = BaseRepository.Connection())
            {
                string query = @"INSERT INTO wells (name, company_id, field_id, workshop_id) VALUES (@name, @company_id, @field_id, @workshop_id);";
                conn.Open();

                var result = conn.Query(query, model);
            }
        }

        public void Update(WellRequest model)
        {
            using (SqliteConnection conn = BaseRepository.Connection())
            {
                //string query = @"UPDATE wells SET name=@name, company_id=@company_id, workshop_id=@workshop_id, field_id=@field_id WHERE id=@id;";
                string query = @"UPDATE wells SET ";
                conn.Open();

                foreach (PropertyInfo prop in model.GetType().GetProperties())
                {
                    if (prop.Name == "id") continue;
                    if (prop.GetValue(model, null) != null)
                    {
                        query += String.Format("{0}={1} ", prop.Name, prop.GetValue(model, null));
                    }
                }
                query += "WHERE id=" + model.id;
                var result = conn.Query(query);
            }
        }

        public void Delete(int id)
        {
            using (SqliteConnection conn = BaseRepository.Connection())
            {
                string query = @"DELETE FROM wells WHERE id=@id;";
                conn.Open();

                conn.Query(query, new { id });
            }
        }
    }
}
