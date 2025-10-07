using System.Data;
namespace Fuerza_G_Taller.Factories
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
