using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopBridge.Api.Model
{
    public class Product
    {
        [Required]
        public string ProductName { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public decimal? SellingPrice { get; set; }
        public decimal? CostPrice { get; set; }
        public List<Category> Categories { get; set; }
        public Supplier Supplier { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
    }
}
