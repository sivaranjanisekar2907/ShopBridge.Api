using ShopBridge.Api.Abstraction;
using ShopBridge.Api.Model;
using ShopBridge.Api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Api.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        // Update and Create the Product
        // If the ProductID is 0 then it ll create
        public async Task<Response> UpsertProductAsync(IEnumerable<Product> createProductCommand)
        {
            Response response= new Response();
            // For RollBack if any transaction goes wrong
            using (var transaction = TransactionFactory.CreateTransactionScope())
            {
                var command = createProductCommand.First();
                    var categories = await _productRepository.GetAllCategoryAsync();
                    List<ProductModel> productModels = new List<ProductModel>();
                    foreach (var category in command.Categories)
                    {
                        var productModel = new ProductModel
                        {
                            CostPrice = command.CostPrice,
                            SellingPrice = command.SellingPrice,
                            ProductName = command.ProductName,
                            Quantity = command.Quantity,
                            Description = command.Description,
                            CategoryId = categories.FirstOrDefault(c => c.CategoryName == category.CategoryName).CategoryId,
                        };
                        productModels.Add(productModel);

                    }
                if (command.ProductId == 0 || command.ProductId == null)
                {
                    response = await _productRepository.CreateProductAsync(productModels);
                }
                else
                {
                    response = await _productRepository.UpdateProductAsync(productModels);
                }
                
                return response;
            }

        }
        // Fetch all the products
        public async Task<List<Product>> GetAllProductsAsync()
        {
            try
            {
                var products = await _productRepository.GetAllProductsAsync();
                List<Product> lstProducts = products.Select(a => new Product()
                {
                    ProductName = a.ProductName,
                    ProductId= a.ProductId,
                    CostPrice = a.CostPrice,
                    Quantity= a.Quantity,
                    Description =a.Description,
                    SellingPrice= a.SellingPrice,
                    Supplier= a.Supplier,
                    Categories = products.Where(b => b.ProductId == a.ProductId)
                                    .Select(c => new Category()
                                    {
                                        CategoryName = c.Categories.Select(e => e.CategoryName).FirstOrDefault()
                                    }).ToList()
                                    }).ToList();
               
                return lstProducts;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        // Delete the products
        public async Task<Response> DeleteProductAsync(DeleteProductCommand commands)
        {
            var response = await _productRepository.DeleteProductAsync(commands); 
            return response;
        }

      
    }
}

