using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Maps
{
    public static class ProductMapExtensions
    {
        public static ProductModel ToProductModel(this Product src)
        {
            var dst = new ProductModel();

            dst.ProductId = src.ProductId;
            dst.ProductName = src.ProductName;
            dst.Category = src.Category;
            dst.Price = src.Price;
            dst.StockQuantity = src.StockQuantity;


            return dst;
        }

        public static Product ToProduct(this ProductModel src, Product dst = null)
        {
            if (dst == null)
            {
                dst = new Product();
            }

            dst.ProductId = src.ProductId;
            dst.ProductName = src.ProductName;
            dst.Category = src.Category;
            dst.Price = src.Price;
            dst.StockQuantity = src.StockQuantity;

            return dst;
        }
    }
}
