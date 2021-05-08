using ShopBridge.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Api.Abstraction
{
    public interface IProductRepository
    {
        Task<IEnumerable<Category>> GetAllCategoryAsync();
        Task<Response> CreateProductAsync(List<ProductModel> productModels);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Response> DeleteProductAsync(DeleteProductCommand deleteCommand);
        Task<Response> UpdateProductAsync(List<ProductModel> productModels);
    }
}
