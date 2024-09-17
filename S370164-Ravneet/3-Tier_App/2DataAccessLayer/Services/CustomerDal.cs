using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Context;
using _2DataAccessLayer.Context.Models;
using _2DataAccessLayer.Interfaces;
using _2DataAccessLayer.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Services
{
    public class CustomerDal : ICustomerDal
    {
        //private readonly TestDBEntities context;
        private DBEntitiesContext _db;
        public CustomerDal(DBEntitiesContext dbctx)
        {
            this._db = dbctx; // new TestDBEntities();
        }


        public List<CustomerModel> GetAll()
        {
            var result = _db.Customers.ToList();

            var returnObject = new List<CustomerModel>();
            foreach (var item in result)
            {
                returnObject.Add(item.ToCustomerModel());
            }

            return returnObject;
        }

        public CustomerModel? GetById(int CustomerId)
        {
            var result = _db.Customers.SingleOrDefault(x => x.CustomerId == CustomerId);
            return result?.ToCustomerModel();
        }


        public int CreateCustomer(CustomerModel Customer)
        {
            var newCustomer = Customer.ToCustomer();
            _db.Customers.Add(newCustomer);
            _db.SaveChanges();
            return newCustomer.CustomerId;
        }


        public void UpdateCustomer(CustomerModel Customer)
        {
            var existingCustomer = _db.Customers
                .SingleOrDefault(x => x.CustomerId == Customer.CustomerId);

            if (existingCustomer == null)
            {
                throw new ApplicationException($"Customer {Customer.CustomerId} does not exist.");
            }
            Customer.ToCustomer(existingCustomer);

            _db.Update(existingCustomer);
            _db.SaveChanges();
        }

        public void DeleteCustomer(int CustomerId)
        {
            var efModel = _db.Customers.Find(CustomerId);
            _db.Customers.Remove(efModel);
            _db.SaveChanges();


        }

    }

}
