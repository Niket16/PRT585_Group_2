using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Interfaces
{
    public interface IProductDal
    {
        // Getters
        ProductModel? GetById(int ProductId);
        List<ProductModel> GetAll();

        // Actions
        int CreateProduct(ProductModel Product);
        void UpdateProduct(ProductModel Product);
        void DeleteProduct(int ProductId);
    }
}
