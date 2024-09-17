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
    public class ProductDal : IProductDal
    {
        //private readonly TestDBEntities context;
        private DBEntitiesContext _db;
        public ProductDal(DBEntitiesContext dbctx)
        {
            this._db = dbctx; // new TestDBEntities();
        }


        public List<ProductModel> GetAll()
        {
            var result = _db.Products.ToList();

            var returnObject = new List<ProductModel>();
            foreach (var item in result)
            {
                returnObject.Add(item.ToProductModel());
            }

            return returnObject;
        }

        public ProductModel? GetById(int ProductId)
        {
            var result = _db.Products.SingleOrDefault(x => x.ProductId == ProductId);
            return result?.ToProductModel();
        }


        public int CreateProduct(ProductModel Product)
        {
            var newProduct = Product.ToProduct();
            _db.Products.Add(newProduct);
            _db.SaveChanges();
            return newProduct.ProductId;
        }


        public void UpdateProduct(ProductModel Product)
        {
            var existingProduct = _db.Products
                .SingleOrDefault(x => x.ProductId == Product.ProductId);

            if (existingProduct == null)
            {
                throw new ApplicationException($"Product {Product.ProductId} does not exist.");
            }
            Product.ToProduct(existingProduct);

            _db.Update(existingProduct);
            _db.SaveChanges();
        }

        public void DeleteProduct(int ProductId)
        {
            var efModel = _db.Products.Find(ProductId);
            _db.Products.Remove(efModel);
            _db.SaveChanges();


        }

    }

}
