using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Api.Model
{
    public class ProductModel
    {
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public decimal? SellingPrice { get; set; }
        public decimal? CostPrice { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
    }
}
