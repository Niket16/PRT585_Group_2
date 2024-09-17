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
    public static class CustomerMapExtensions
    {
        public static CustomerModel ToCustomerModel(this Customer src)
        {
            var dst = new CustomerModel();

            dst.CustomerId = src.CustomerId;
            dst.FirstName = src.FirstName;
            dst.LastName = src.LastName;
            dst.Email = src.Email;
            dst.Phone = src.Phone;
            dst.Address = src.Address;

            return dst;
        }

        public static Customer ToCustomer(this CustomerModel src, Customer dst = null)
        {
            if (dst == null)
            {
                dst = new Customer();
            }

            dst.CustomerId = src.CustomerId;
            dst.FirstName = src.FirstName;
            dst.LastName = src.LastName;
            dst.Email = src.Email;
            dst.Phone = src.Phone;
            dst.Address = src.Address;

            return dst;
        }
    }
}
