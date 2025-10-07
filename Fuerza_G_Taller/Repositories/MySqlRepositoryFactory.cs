using Fuerza_G_Taller.Configuration;
using Fuerza_G_Taller.Models;
using System;

namespace Fuerza_G_Taller.Repositories
{
    public class MySqlRepositoryFactory : IRepositoryFactory
    {
        private readonly DatabaseConnectionManager _connectionManager;

        public MySqlRepositoryFactory(DatabaseConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public IRepository<T> CreateRepository<T>() where T : class
        {
            if (typeof(T) == typeof(Brand))
                return new BrandRepository(_connectionManager) as IRepository<T>;
            if (typeof(T) == typeof(Model))
                return new ModelRepository(_connectionManager) as IRepository<T>;
            if (typeof(T) == typeof(Owner))
                return new OwnerRepository(_connectionManager) as IRepository<T>;
            if (typeof(T) == typeof(Vehicle))
                return new VehicleRepository(_connectionManager) as IRepository<T>;
            if (typeof(T) == typeof(Service))
                return new ServiceRepository(_connectionManager) as IRepository<T>;
            if (typeof(T) == typeof(Technician))
                return new TechnicianRepository(_connectionManager) as IRepository<T>;

            throw new NotSupportedException($"No repository available for type {typeof(T).Name}");
        }
    }
}
