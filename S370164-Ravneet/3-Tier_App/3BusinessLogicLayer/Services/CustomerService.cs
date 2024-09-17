

using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Interfaces;
using _3BusinessLogicLayer.Interfaces;

namespace _3BusinessLogicLayer.Services
{
    public class CustomerService :  ICustomerService
    {
        private readonly ICustomerDal _CustomerDal;
        //private readonly ICustomerBalService _CustomerBalService;
        public CustomerService(ICustomerDal CustomerDal
        //ILoggingService loggingService,
        //ICustomerDal CustomerDal,
        //IAuditDal auditDal
       // ICustomerBalanceService balsvc
        ) 
        {
            _CustomerDal = CustomerDal;
            // _CustomerBalService = balsvc;
        }

        public async Task<CustomerModel?> GetById(int CustomerId)
        {           
            return _CustomerDal.GetById(CustomerId);
        }

        public async Task<List<CustomerModel>> GetAll()
        {            
            return _CustomerDal.GetAll();
        }

        public async Task<int> CreateCustomer(CustomerModel Customer)
        {
            //write validations here
            var newCustomerId = _CustomerDal.CreateCustomer(Customer);
            return newCustomerId;
        }

        public async Task UpdateCustomer(CustomerModel Customer)
        {
            //write validations here 
            _CustomerDal.UpdateCustomer(Customer);
        }

        public async Task DeleteCustomer(int CustomerId)
        {            
            try
            {
                //if(balservice.getBal(CustomerId) = 0)
                _CustomerDal.DeleteCustomer(CustomerId);
            }
            catch (Exception e)
            {
                //_loggingService.WriteLog(LoggingLevel.Error, "Layer", $"Error delete Customer Id:{CustomerId}. {e.Message}", e.StackTrace);
            }
        }
    }
}
