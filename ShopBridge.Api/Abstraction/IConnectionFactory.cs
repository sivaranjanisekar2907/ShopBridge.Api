using System;
using System.Data;
using System.Threading.Tasks;

namespace ShopBridge.Api.Abstraction
{
    public interface IConnectionFactory : IDisposable
    {
        // Fetch the Connection String
        Task<IDbConnection> CreateConnectionAsync();
    }
}
