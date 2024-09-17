using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Interfaces
{
    public interface ICustomerDal
    {
        // Getters
        CustomerModel? GetById(int CustomerId);
        List<CustomerModel> GetAll();

        // Actions
        int CreateCustomer(CustomerModel Customer);
        void UpdateCustomer(CustomerModel Customer);
        void DeleteCustomer(int CustomerId);
    }
}
