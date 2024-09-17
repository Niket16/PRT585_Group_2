using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _1CommonInfrastructure.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }  // int
        public string ProductName { get; set; }  // nvarchar(400)
        public string Category { get; set; }  // nvarchar(400)
        public decimal Price { get; set; }  // decimal
        public int StockQuantity { get; set; }  // int
    }


}
