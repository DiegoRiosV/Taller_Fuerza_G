using System.Data;
using Fuerza_G_Taller.Configuration;
using Fuerza_G_Taller.Factories;
using Microsoft.AspNetCore.Connections;
using MySql.Data.MySqlClient;

namespace Fuerza_G_Taller.Factories
{
    public class MySqlConnectionFactory : IDbConnectionFactory
    {
        private readonly DatabaseConnectionManager _connectionManager;

        public MySqlConnectionFactory(DatabaseConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public IDbConnection CreateConnection()
        {
            return new MySqlConnection(_connectionManager.ConnectionString);
        }
    }
}
