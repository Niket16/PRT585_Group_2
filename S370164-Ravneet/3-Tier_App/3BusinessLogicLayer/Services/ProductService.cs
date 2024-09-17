

using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Interfaces;
using _3BusinessLogicLayer.Interfaces;

namespace _3BusinessLogicLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDal _ProductDal;
        //private readonly IProductBalService _ProductBalService;
        public ProductService(IProductDal ProductDal
        //ILoggingService loggingService,
        //IProductDal ProductDal,
        //IAuditDal auditDal
        // IProductBalanceService balsvc
        )
        {
            _ProductDal = ProductDal;
            // _ProductBalService = balsvc;
        }

        public async Task<ProductModel?> GetById(int ProductId)
        {
            return _ProductDal.GetById(ProductId);
        }

        public async Task<List<ProductModel>> GetAll()
        {
            return _ProductDal.GetAll();
        }

        public async Task<int> CreateProduct(ProductModel Product)
        {
            //write validations here
            var newProductId = _ProductDal.CreateProduct(Product);
            return newProductId;
        }

        public async Task UpdateProduct(ProductModel Product)
        {
            //write validations here 
            _ProductDal.UpdateProduct(Product);
        }

        public async Task DeleteProduct(int ProductId)
        {
            try
            {
                //if(balservice.getBal(ProductId) = 0)
                _ProductDal.DeleteProduct(ProductId);
            }
            catch (Exception e)
            {
                //_loggingService.WriteLog(LoggingLevel.Error, "Layer", $"Error delete Product Id:{ProductId}. {e.Message}", e.StackTrace);
            }
        }
    }
}
