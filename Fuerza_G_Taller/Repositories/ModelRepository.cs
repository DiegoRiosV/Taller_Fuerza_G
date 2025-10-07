using Fuerza_G_Taller.Configuration;
using Fuerza_G_Taller.Models;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace Fuerza_G_Taller.Repositories
{
    public class ModelRepository : IRepository<Model>
    {
        private readonly DatabaseConnectionManager _connectionManager;

        public ModelRepository(DatabaseConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public IEnumerable<Model> GetAll()
        {
            var list = new List<Model>();
            using var conn = _connectionManager.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM model";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Model
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    BrandId = reader.GetInt32("brand_id"),
                    CreatedAt = reader.GetDateTime("created_at"),
                    UpdatedAt = reader.IsDBNull(reader.GetOrdinal("updated_at")) ? null : reader.GetDateTime("updated_at"),
                    IsActive = reader.GetBoolean("is_active"),
                    ModifiedByUserId = reader.IsDBNull(reader.GetOrdinal("modified_by_user_id")) ? null : reader.GetInt32("modified_by_user_id")
                });
            }
            return list;
        }

        public Model? GetById(int id)
        {
            using var conn = _connectionManager.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM model WHERE id=@id";
            cmd.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32) { Value = id });

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Model
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    BrandId = reader.GetInt32("brand_id"),
                    CreatedAt = reader.GetDateTime("created_at"),
                    UpdatedAt = reader.IsDBNull(reader.GetOrdinal("updated_at")) ? null : reader.GetDateTime("updated_at"),
                    IsActive = reader.GetBoolean("is_active"),
                    ModifiedByUserId = reader.IsDBNull(reader.GetOrdinal("modified_by_user_id")) ? null : reader.GetInt32("modified_by_user_id")
                };
            }
            return null;
        }

        public void Add(Model entity)
        {
            using var conn = _connectionManager.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO model (name, brand_id) VALUES (@name, @brand_id)";
            cmd.Parameters.Add(new MySqlParameter("@name", MySqlDbType.VarChar) { Value = entity.Name });
            cmd.Parameters.Add(new MySqlParameter("@brand_id", MySqlDbType.Int32) { Value = entity.BrandId });

            cmd.ExecuteNonQuery();
        }

        public void Update(Model entity)
        {
            using var conn = _connectionManager.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE model SET name=@name, brand_id=@brand_id, updated_at=NOW() WHERE id=@id";

            cmd.Parameters.Add(new MySqlParameter("@name", MySqlDbType.VarChar) { Value = entity.Name });
            cmd.Parameters.Add(new MySqlParameter("@brand_id", MySqlDbType.Int32) { Value = entity.BrandId });
            cmd.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32) { Value = entity.Id });

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = _connectionManager.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM model WHERE id=@id";
            cmd.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32) { Value = id });

            cmd.ExecuteNonQuery();
        }
    }
}
