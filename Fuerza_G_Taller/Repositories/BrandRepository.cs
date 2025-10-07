using Fuerza_G_Taller.Configuration;
using Fuerza_G_Taller.Models;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace Fuerza_G_Taller.Repositories
{
    public class BrandRepository : IRepository<Brand>
    {
        private readonly DatabaseConnectionManager _connectionManager;

        public BrandRepository(DatabaseConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public IEnumerable<Brand> GetAll()
        {
            var list = new List<Brand>();
            using var conn = _connectionManager.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM brand";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Brand
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    CreatedAt = reader.GetDateTime("created_at"),
                    UpdatedAt = reader.IsDBNull(reader.GetOrdinal("updated_at")) ? null : reader.GetDateTime("updated_at"),
                    IsActive = reader.GetBoolean("is_active"),
                    ModifiedByUserId = reader.IsDBNull(reader.GetOrdinal("modified_by_user_id")) ? null : reader.GetInt32("modified_by_user_id")
                });
            }
            return list;
        }

        public Brand? GetById(int id)
        {
            using var conn = _connectionManager.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM brand WHERE id=@id";
            cmd.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32) { Value = id });

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Brand
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    CreatedAt = reader.GetDateTime("created_at"),
                    UpdatedAt = reader.IsDBNull(reader.GetOrdinal("updated_at")) ? null : reader.GetDateTime("updated_at"),
                    IsActive = reader.GetBoolean("is_active"),
                    ModifiedByUserId = reader.IsDBNull(reader.GetOrdinal("modified_by_user_id")) ? null : reader.GetInt32("modified_by_user_id")
                };
            }
            return null;
        }

        public void Add(Brand entity)
        {
            using var conn = _connectionManager.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO brand (name) VALUES (@name)";
            cmd.Parameters.Add(new MySqlParameter("@name", MySqlDbType.VarChar) { Value = entity.Name });

            cmd.ExecuteNonQuery();
        }

        public void Update(Brand entity)
        {
            using var conn = _connectionManager.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE brand SET name=@name, updated_at=NOW() WHERE id=@id";

            cmd.Parameters.Add(new MySqlParameter("@name", MySqlDbType.VarChar) { Value = entity.Name });
            cmd.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32) { Value = entity.Id });

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = _connectionManager.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM brand WHERE id=@id";
            cmd.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32) { Value = id });

            cmd.ExecuteNonQuery();
        }
    }
}
