using Euro.TaskManagement.Api.Model;
using System;
using System.Collections.Generic;

namespace Euro.TaskManagement.Tests
{
    public class MockObjects
    {
        public static List<Product> GetProductData()
        {
            var listOfProductData = new List<Product>();
            var producrData = new Product
            {
                ProductName = "Pantene",
                Supplier = new Supplier()
                {
                  SupplierName = "Siva"
                },
                Quantity = 1,
                CostPrice = 25,
                SellingPrice = 100,
                Categories = new List<Category>()
                {
                    new Category()
                    {
                       CategoryName ="HairCare"
                    }
                }
            };


            listOfProductData.Add(producrData);
            return listOfProductData;
        }

        public static DeleteProductCommand DeleteProduct(int productId)
        {
            var delete = new DeleteProductCommand();
            delete.ProductId = productId;
            return delete;

        }
    }
}
