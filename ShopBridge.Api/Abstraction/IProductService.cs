using System.Collections.Generic;
using System.Threading.Tasks;
using ShopBridge.Api.Model;

namespace ShopBridge.Api.Abstraction
{
    public interface IProductService
    {
        Task<Response> UpsertProductAsync(IEnumerable<Product> createProductCommand);
        Task<List<Product>> GetAllProductsAsync();
        Task<Response> DeleteProductAsync(DeleteProductCommand deleteUserCommand);
    }
}
