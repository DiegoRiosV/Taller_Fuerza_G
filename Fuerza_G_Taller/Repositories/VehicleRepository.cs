using Fuerza_G_Taller.Configuration;
using Fuerza_G_Taller.Models;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace Fuerza_G_Taller.Repositories
{
    public class VehicleRepository : IRepository<Vehicle>
    {
        private readonly DatabaseConnectionManager _connectionManager;

        public VehicleRepository(DatabaseConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public IEnumerable<Vehicle> GetAll()
        {
            var list = new List<Vehicle>();
            using var conn = _connectionManager.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM vehicle";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Vehicle
                {
                    Id = reader.GetInt32("id"),
                    OwnerId = reader.GetInt32("owner_id"),
                    Plate = reader.IsDBNull(reader.GetOrdinal("plate")) ? null : reader.GetString("plate"),
                    ModelId = reader.IsDBNull(reader.GetOrdinal("model_id")) ? null : reader.GetInt32("model_id"),
                    Year = reader.IsDBNull(reader.GetOrdinal("year")) ? null : reader.GetInt16("year"),
                    Color = reader.IsDBNull(reader.GetOrdinal("color")) ? null : reader.GetString("color"),
                    Type = reader.IsDBNull(reader.GetOrdinal("type")) ? null : reader.GetString("type"),
                    CreatedAt = reader.GetDateTime("created_at"),
                    UpdatedAt = reader.IsDBNull(reader.GetOrdinal("updated_at")) ? null : reader.GetDateTime("updated_at"),
                    IsActive = reader.GetBoolean("is_active"),
                    ModifiedByUserId = reader.IsDBNull(reader.GetOrdinal("modified_by_user_id")) ? null : reader.GetInt32("modified_by_user_id")
                });
            }
            return list;
        }

        public Vehicle? GetById(int id)
        {
            using var conn = _connectionManager.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM vehicle WHERE id=@id";
            cmd.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32) { Value = id });

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Vehicle
                {
                    Id = reader.GetInt32("id"),
                    OwnerId = reader.GetInt32("owner_id"),
                    Plate = reader.IsDBNull(reader.GetOrdinal("plate")) ? null : reader.GetString("plate"),
                    ModelId = reader.IsDBNull(reader.GetOrdinal("model_id")) ? null : reader.GetInt32("model_id"),
                    Year = reader.IsDBNull(reader.GetOrdinal("year")) ? null : reader.GetInt16("year"),
                    Color = reader.IsDBNull(reader.GetOrdinal("color")) ? null : reader.GetString("color"),
                    Type = reader.IsDBNull(reader.GetOrdinal("type")) ? null : reader.GetString("type"),
                    CreatedAt = reader.GetDateTime("created_at"),
                    UpdatedAt = reader.IsDBNull(reader.GetOrdinal("updated_at")) ? null : reader.GetDateTime("updated_at"),
                    IsActive = reader.GetBoolean("is_active"),
                    ModifiedByUserId = reader.IsDBNull(reader.GetOrdinal("modified_by_user_id")) ? null : reader.GetInt32("modified_by_user_id")
                };
            }
            return null;
        }

        public void Add(Vehicle entity)
        {
            using var conn = _connectionManager.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"INSERT INTO vehicle 
                                (owner_id, plate, model_id, year, color, type) 
                                VALUES (@owner_id, @plate, @model_id, @year, @color, @type)";

            cmd.Parameters.Add(new MySqlParameter("@owner_id", MySqlDbType.Int32) { Value = entity.OwnerId });
            cmd.Parameters.Add(new MySqlParameter("@plate", MySqlDbType.VarChar) { Value = (object?)entity.Plate ?? DBNull.Value });
            cmd.Parameters.Add(new MySqlParameter("@model_id", MySqlDbType.Int32) { Value = (object?)entity.ModelId ?? DBNull.Value });
            cmd.Parameters.Add(new MySqlParameter("@year", MySqlDbType.Int16) { Value = (object?)entity.Year ?? DBNull.Value });
            cmd.Parameters.Add(new MySqlParameter("@color", MySqlDbType.VarChar) { Value = (object?)entity.Color ?? DBNull.Value });
            cmd.Parameters.Add(new MySqlParameter("@type", MySqlDbType.VarChar) { Value = (object?)entity.Type ?? DBNull.Value });

            cmd.ExecuteNonQuery();
        }

        public void Update(Vehicle entity)
        {
            using var conn = _connectionManager.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"UPDATE vehicle 
                                SET owner_id=@owner_id, plate=@plate, model_id=@model_id, year=@year, color=@color, type=@type, 
                                    updated_at=NOW() 
                                WHERE id=@id";

            cmd.Parameters.Add(new MySqlParameter("@owner_id", MySqlDbType.Int32) { Value = entity.OwnerId });
            cmd.Parameters.Add(new MySqlParameter("@plate", MySqlDbType.VarChar) { Value = (object?)entity.Plate ?? DBNull.Value });
            cmd.Parameters.Add(new MySqlParameter("@model_id", MySqlDbType.Int32) { Value = (object?)entity.ModelId ?? DBNull.Value });
            cmd.Parameters.Add(new MySqlParameter("@year", MySqlDbType.Int16) { Value = (object?)entity.Year ?? DBNull.Value });
            cmd.Parameters.Add(new MySqlParameter("@color", MySqlDbType.VarChar) { Value = (object?)entity.Color ?? DBNull.Value });
            cmd.Parameters.Add(new MySqlParameter("@type", MySqlDbType.VarChar) { Value = (object?)entity.Type ?? DBNull.Value });
            cmd.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32) { Value = entity.Id });

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = _connectionManager.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM vehicle WHERE id=@id";
            cmd.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32) { Value = id });

            cmd.ExecuteNonQuery();
        }
    }
}
