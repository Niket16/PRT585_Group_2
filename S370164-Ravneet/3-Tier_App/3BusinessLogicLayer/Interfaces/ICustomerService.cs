using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3BusinessLogicLayer.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerModel?> GetById(int CustomerId);
        Task<List<CustomerModel>> GetAll();

        Task<int> CreateCustomer(CustomerModel Customer);
        Task UpdateCustomer(CustomerModel Customer);
        Task DeleteCustomer(int CustomerId);
    }
}
