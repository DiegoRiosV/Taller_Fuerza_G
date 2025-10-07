using Fuerza_G_Taller.Configuration;
using Fuerza_G_Taller.Models;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace Fuerza_G_Taller.Repositories
{
    public class ServiceRepository : IRepository<Service>
    {
        private readonly DatabaseConnectionManager _connectionManager;

        public ServiceRepository(DatabaseConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public IEnumerable<Service> GetAll()
        {
            var list = new List<Service>();
            using var conn = _connectionManager.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM service";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Service
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    Type = reader.GetString("type"),
                    Price = reader.GetDecimal("price"),
                    Description = reader.GetString("description"),
                    CreatedAt = reader.GetDateTime("created_at"),
                    UpdatedAt = reader.IsDBNull(reader.GetOrdinal("updated_at")) ? null : reader.GetDateTime("updated_at"),
                    IsActive = reader.GetBoolean("is_active"),
                    ModifiedByUserId = reader.IsDBNull(reader.GetOrdinal("modified_by_user_id")) ? null : reader.GetInt32("modified_by_user_id")
                });
            }

            return list;
        }

        public Service? GetById(int id)
        {
            using var conn = _connectionManager.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM service WHERE id=@id";
            cmd.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32) { Value = id });

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Service
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    Type = reader.GetString("type"),
                    Price = reader.GetDecimal("price"),
                    Description = reader.GetString("description"),
                    CreatedAt = reader.GetDateTime("created_at"),
                    UpdatedAt = reader.IsDBNull(reader.GetOrdinal("updated_at")) ? null : reader.GetDateTime("updated_at"),
                    IsActive = reader.GetBoolean("is_active"),
                    ModifiedByUserId = reader.IsDBNull(reader.GetOrdinal("modified_by_user_id")) ? null : reader.GetInt32("modified_by_user_id")
                };
            }

            return null;
        }

        public void Add(Service entity)
        {
            using var conn = _connectionManager.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"INSERT INTO service (name, type, price, description) 
                                VALUES (@name, @type, @price, @description)";

            cmd.Parameters.Add(new MySqlParameter("@name", MySqlDbType.VarChar) { Value = entity.Name });
            cmd.Parameters.Add(new MySqlParameter("@type", MySqlDbType.VarChar) { Value = entity.Type });
            cmd.Parameters.Add(new MySqlParameter("@price", MySqlDbType.Decimal) { Value = entity.Price });
            cmd.Parameters.Add(new MySqlParameter("@description", MySqlDbType.VarChar) { Value = entity.Description });

            cmd.ExecuteNonQuery();
        }

        public void Update(Service entity)
        {
            using var conn = _connectionManager.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"UPDATE service 
                                SET name=@name, type=@type, price=@price, description=@description, 
                                    updated_at=NOW() 
                                WHERE id=@id";

            cmd.Parameters.Add(new MySqlParameter("@name", MySqlDbType.VarChar) { Value = entity.Name });
            cmd.Parameters.Add(new MySqlParameter("@type", MySqlDbType.VarChar) { Value = entity.Type });
            cmd.Parameters.Add(new MySqlParameter("@price", MySqlDbType.Decimal) { Value = entity.Price });
            cmd.Parameters.Add(new MySqlParameter("@description", MySqlDbType.VarChar) { Value = entity.Description });
            cmd.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32) { Value = entity.Id });

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = _connectionManager.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM service WHERE id=@id";
            cmd.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32) { Value = id });

            cmd.ExecuteNonQuery();
        }
    }
}
