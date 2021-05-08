using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Api.Repository
{
    public static class SqlQueries
    {
        public const string GetAllCategory = @"Select Id as CategoryID
                                                      ,Name as CategoryName
                                               From Category";
        public const string GetAllProducts = @"Select ProductId 
                                                      ,Name as ProductName
                                                      ,SellingPrice
                                                         ,CostPrice
                                                        ,Quantity
                                                        ,c.CategoryName
                                                        ,s.SupplierName
                                               From Product JOIN Category
                                                On c.Id = p.CategoryId
                                                JOIN Supplier On s.Id = p.SupplierId";
        public const string DeleteProduct = @"Delete * from Product Where ProductID= @ProductID";

        public const string CreateProduct = @" INSERT INTO [dbo].[Product]([Name],[Quantity],[SellingPrice],[CostPrice],[CategoryId],[SupplierID]) 
                                                        VALUES(@Name,@Quantity,@SellingPrice,@CostPrice,CategoryId,@SupplierID)
                                                        Select @@Identity";
        public const string UpdateProduct = @" Update [dbo].[Product] set [Name] = @Name,[Quantity]= @Quantity,[SellingPrice]= @SellingPrice,[CostPrice]=@CostPrice,
                                            [CategoryId]=@CategoryId,[SupplierID]=@SupplierID where Id=@ProductId ";
    }
}
