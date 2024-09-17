using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3BusinessLogicLayer.Interfaces
{
    public interface IProductService
    {
        Task<ProductModel?> GetById(int ProductId);
        Task<List<ProductModel>> GetAll();

        Task<int> CreateProduct(ProductModel Product);
        Task UpdateProduct(ProductModel Product);
        Task DeleteProduct(int ProductId);
    }
}
