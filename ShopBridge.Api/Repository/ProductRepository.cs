using ShopBridge.Api.Abstraction;
using ShopBridge.Api.Model;
using ShopBridge.Api.SqlDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Api.Repository
{
    public class ProductRepository : IProductRepository
    {
        protected readonly ISqlRepository sqlRepository;
        protected readonly IConnectionFactory connectionFactory;

        public ProductRepository()
        {
            sqlRepository = new SqlBaseRepository(connectionFactory);

        }
        public async Task<Response> CreateProductAsync(List<ProductModel> productModels)
        {
            Response response = new Response();

            try
            {
                string insertUserRoleQuery = SqlQueries.CreateProduct;
                StringBuilder queryTransaction = new StringBuilder();

                foreach (ProductModel products in productModels)
                {
                    queryTransaction.AppendLine(
                        insertUserRoleQuery
                            .Replace("@Name", products.ProductName.ToString()))
                            .Replace("@Quantity", products.Quantity.ToString())
                            .Replace("@SellingPrice", products.SellingPrice.ToString())
                            .Replace("@CostPrice", products.CostPrice.ToString())
                            .Replace("@CategoryId", products.CategoryId.ToString())
                            .Replace("@SupplierID", products.CategoryId.ToString());
                }


                var result = await sqlRepository.ExecuteAsync<int>(queryTransaction.ToString(), commandTimeout: 300);
                response.IsSuccess = result > 0;
            }
            catch (Exception ex)
            {
                return null;
            }

            return response;
        }

        public async Task<Response> DeleteProductAsync(DeleteProductCommand deleteCommand)
        {
            Response response = new Response();

            try
            {
                int result = await sqlRepository.ExecuteAsync<int>(SqlQueries.DeleteProduct,
                     new
                     {
                         deleteCommand.ProductId
                     },
                     commandTimeout: 300);
                response.IsSuccess = result > 0;
            }
            catch (Exception ex)
            {
                return null;
            }

            return response;
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            try
            {

                return await sqlRepository.QueryAsync<Category>(SqlQueries.GetAllCategory);
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            try
            {
                return await sqlRepository.QueryAsync<Product>(SqlQueries.GetAllProducts);
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public async Task<Response> UpdateProductAsync(List<ProductModel> productModels)
        {
            Response response = new Response();

            try
            {
                string insertUserRoleQuery = SqlQueries.UpdateProduct;
                StringBuilder queryTransaction = new StringBuilder();

                foreach (ProductModel products in productModels)
                {
                    queryTransaction.AppendLine(
                        insertUserRoleQuery
                            .Replace("@Name", products.ProductName.ToString()))
                            .Replace("@Quantity", products.Quantity.ToString())
                            .Replace("@SellingPrice", products.SellingPrice.ToString())
                            .Replace("@CostPrice", products.CostPrice.ToString())
                            .Replace("@CategoryId", products.CategoryId.ToString())
                            .Replace("@SupplierID", products.CategoryId.ToString());
                }


                var result = await sqlRepository.ExecuteScalarAsync<int>(queryTransaction.ToString(), commandTimeout: 300);
                response.IsSuccess = result > 0;
            }
            catch (Exception ex)
            {
                return null;
            }

            return response;
        }
    }
}
