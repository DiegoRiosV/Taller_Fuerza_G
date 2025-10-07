namespace Fuerza_G_Taller.Repositories
{
    public interface IRepositoryFactory
    {
        IRepository<T> CreateRepository<T>() where T : class;
    }
}
