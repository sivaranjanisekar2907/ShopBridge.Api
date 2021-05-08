using Microsoft.AspNetCore.Mvc;
using Moq;
using ShopBridge.Api.Abstraction;
using ShopBridge.Api.Controllers;
using ShopBridge.Api.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ShopBridge.Tests
{
    public class ProductControllerTest
    {
        private readonly ProductController controller;
        private readonly Mock<IProductService> mockServ;
        public ProductControllerTest()
        {
            mockServ = new Mock<IProductService>();
            controller = new ProductController();
           
        }

        [Fact]
        public async Task ToValidate_ProductDetails_OutPutTestAsync()
        {
            // Arrange
            mockServ.Setup(repo => repo.GetAllProductsAsync()).ReturnsAsync(MockObjects.GetProductData());

            // Act 
            var result = await controller.GetAllProductsAsync();

            // Assert 
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var actualTerms = Assert.IsType<List<Product>>(actionResult.Value);
            Assert.IsType<List<Product>>(actualTerms);
        }


        /// <summary>
        /// Test case to check whether controller returns the data
        /// </summary>
        /// <returns></returns>
        [Theory]
        [InlineData(1)]
        public async Task ToValidate_DeleteProduct_OutputTestAsync(int productID)
        {
            // Arrange
            var delete = MockObjects.DeleteProduct(productID);
            mockServ.Setup(repo => repo.DeleteProductAsync(delete));

            // Act 
            var result = await controller.DeleteProductAsync(delete);

            // Assert 
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var actualTerms = Assert.IsType<List<Product>>(actionResult.Value);
            Assert.IsType<List<Product>>(actualTerms);

        }
    }
}
