using Microsoft.AspNetCore.Mvc;
using Moq;
using Euro.TaskManagement.Api.Abstraction;
using Euro.TaskManagement.Api.Controllers;
using Euro.TaskManagement.Api.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Euro.TaskManagement.Tests
{
    public class ProductControllerTest
    {
        private readonly StaffController controller;
        private readonly Mock<IProductService> mockServ;
        public ProductControllerTest()
        {
            mockServ = new Mock<IProductService>();
            controller = new StaffController();
           
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
