using _1CommonInfrastructure.Models;

namespace WebApplication3tierApp.Models
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }


    }

    public static class ProductDtoMapExtensions
    {
        public static ProductDto ToProductDto(this ProductModel src)
        {
            var dst = new ProductDto();
            dst.ProductId = src.ProductId;
            dst.ProductName = src.ProductName;
            dst.Category = src.Category;
            dst.Price = src.Price;
            dst.StockQuantity = src.StockQuantity;

            return dst;
        }

        public static ProductModel ToProductModel(this ProductDto src)
        {
            var dst = new ProductModel();
            dst.ProductId = src.ProductId;
            dst.ProductName = src.ProductName;
            dst.Category = src.Category;
            dst.Price = src.Price;
            dst.StockQuantity = src.StockQuantity;

            return dst;
        }
    }
}
