using Fuerza_G_Taller.Configuration;
using Fuerza_G_Taller.Models;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace Fuerza_G_Taller.Repositories
{
    public class TechnicianRepository : IRepository<Technician>
    {
        private readonly DatabaseConnectionManager _connectionManager;

        public TechnicianRepository(DatabaseConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public IEnumerable<Technician> GetAll()
        {
            var list = new List<Technician>();
            using var conn = _connectionManager.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM technician";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Technician
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    FirstLastName = reader.IsDBNull(reader.GetOrdinal("first_last_name")) ? null : reader.GetString("first_last_name"),
                    SecondLastName = reader.IsDBNull(reader.GetOrdinal("second_last_name")) ? null : reader.GetString("second_last_name"),
                    PhoneNumber = reader.IsDBNull(reader.GetOrdinal("phone_number")) ? null : reader.GetString("phone_number"),
                    Email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString("email"),
                    DocumentNumber = reader.IsDBNull(reader.GetOrdinal("document_number")) ? null : reader.GetString("document_number"),
                    Address = reader.IsDBNull(reader.GetOrdinal("address")) ? null : reader.GetString("address"),
                    BaseSalary = reader.GetDecimal("base_salary"),
                    CreatedAt = reader.GetDateTime("created_at"),
                    UpdatedAt = reader.IsDBNull(reader.GetOrdinal("updated_at")) ? null : reader.GetDateTime("updated_at"),
                    IsActive = reader.GetBoolean("is_active"),
                    ModifiedByUserId = reader.IsDBNull(reader.GetOrdinal("modified_by_user_id")) ? null : reader.GetInt32("modified_by_user_id")
                });
            }

            return list;
        }

        public Technician? GetById(int id)
        {
            using var conn = _connectionManager.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM technician WHERE id=@id";
            cmd.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32) { Value = id });

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Technician
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    FirstLastName = reader.IsDBNull(reader.GetOrdinal("first_last_name")) ? null : reader.GetString("first_last_name"),
                    SecondLastName = reader.IsDBNull(reader.GetOrdinal("second_last_name")) ? null : reader.GetString("second_last_name"),
                    PhoneNumber = reader.IsDBNull(reader.GetOrdinal("phone_number")) ? null : reader.GetString("phone_number"),
                    Email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString("email"),
                    DocumentNumber = reader.IsDBNull(reader.GetOrdinal("document_number")) ? null : reader.GetString("document_number"),
                    Address = reader.IsDBNull(reader.GetOrdinal("address")) ? null : reader.GetString("address"),
                    BaseSalary = reader.GetDecimal("base_salary"),
                    CreatedAt = reader.GetDateTime("created_at"),
                    UpdatedAt = reader.IsDBNull(reader.GetOrdinal("updated_at")) ? null : reader.GetDateTime("updated_at"),
                    IsActive = reader.GetBoolean("is_active"),
                    ModifiedByUserId = reader.IsDBNull(reader.GetOrdinal("modified_by_user_id")) ? null : reader.GetInt32("modified_by_user_id")
                };
            }

            return null;
        }

        public void Add(Technician entity)
        {
            using var conn = _connectionManager.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"INSERT INTO technician 
                                (name, first_last_name, second_last_name, phone_number, email, document_number, address, base_salary) 
                                VALUES (@name, @first_last_name, @second_last_name, @phone_number, @email, @document_number, @address, @base_salary)";

            cmd.Parameters.Add(new MySqlParameter("@name", MySqlDbType.VarChar) { Value = entity.Name });
            cmd.Parameters.Add(new MySqlParameter("@first_last_name", MySqlDbType.VarChar) { Value = (object?)entity.FirstLastName ?? DBNull.Value });
            cmd.Parameters.Add(new MySqlParameter("@second_last_name", MySqlDbType.VarChar) { Value = (object?)entity.SecondLastName ?? DBNull.Value });
            cmd.Parameters.Add(new MySqlParameter("@phone_number", MySqlDbType.VarChar) { Value = (object?)entity.PhoneNumber ?? DBNull.Value });
            cmd.Parameters.Add(new MySqlParameter("@email", MySqlDbType.VarChar) { Value = (object?)entity.Email ?? DBNull.Value });
            cmd.Parameters.Add(new MySqlParameter("@document_number", MySqlDbType.VarChar) { Value = (object?)entity.DocumentNumber ?? DBNull.Value });
            cmd.Parameters.Add(new MySqlParameter("@address", MySqlDbType.VarChar) { Value = (object?)entity.Address ?? DBNull.Value });
            cmd.Parameters.Add(new MySqlParameter("@base_salary", MySqlDbType.Decimal) { Value = entity.BaseSalary });

            cmd.ExecuteNonQuery();
        }

        public void Update(Technician entity)
        {
            using var conn = _connectionManager.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"UPDATE technician 
                                SET name=@name, first_last_name=@first_last_name, second_last_name=@second_last_name,
                                    phone_number=@phone_number, email=@email, document_number=@document_number, address=@address,
                                    base_salary=@base_salary, updated_at=NOW()
                                WHERE id=@id";

            cmd.Parameters.Add(new MySqlParameter("@name", MySqlDbType.VarChar) { Value = entity.Name });
            cmd.Parameters.Add(new MySqlParameter("@first_last_name", MySqlDbType.VarChar) { Value = (object?)entity.FirstLastName ?? DBNull.Value });
            cmd.Parameters.Add(new MySqlParameter("@second_last_name", MySqlDbType.VarChar) { Value = (object?)entity.SecondLastName ?? DBNull.Value });
            cmd.Parameters.Add(new MySqlParameter("@phone_number", MySqlDbType.VarChar) { Value = (object?)entity.PhoneNumber ?? DBNull.Value });
            cmd.Parameters.Add(new MySqlParameter("@email", MySqlDbType.VarChar) { Value = (object?)entity.Email ?? DBNull.Value });
            cmd.Parameters.Add(new MySqlParameter("@document_number", MySqlDbType.VarChar) { Value = (object?)entity.DocumentNumber ?? DBNull.Value });
            cmd.Parameters.Add(new MySqlParameter("@address", MySqlDbType.VarChar) { Value = (object?)entity.Address ?? DBNull.Value });
            cmd.Parameters.Add(new MySqlParameter("@base_salary", MySqlDbType.Decimal) { Value = entity.BaseSalary });
            cmd.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32) { Value = entity.Id });

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = _connectionManager.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM technician WHERE id=@id";
            cmd.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32) { Value = id });

            cmd.ExecuteNonQuery();
        }
    }
}
