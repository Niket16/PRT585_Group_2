using _2DataAccessLayer.Services;
using _3BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3tierApp.Models;

namespace WebApplication3tierApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CustomerController : BaseController
    {

        private readonly ICustomerService _CustomerService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService CustomerService, ILogger<CustomerController> logger)
        {
            _CustomerService = CustomerService;
            _logger = logger;
        }

        [HttpGet("", Name = "GetAllCustomers")]
        public async Task<List<CustomerDto>> GetAll()
        {
            var result = await _CustomerService.GetAll();
            return result.Select(x => x.ToCustomerDto()).ToList();
        }

        [HttpGet("{CustomerId}", Name = "GetCustomer")]
        public async Task<CustomerDto?> Get(int CustomerId)
        {
            var result = await _CustomerService.GetById(CustomerId);
            return result?.ToCustomerDto();
        }

        [HttpPost, Route("")]
        public async Task<int> Create([FromBody] CustomerDto requestDto)
        {
            var CustomerModel = requestDto.ToCustomerModel();
            return await _CustomerService.CreateCustomer(CustomerModel);
        }

        [HttpPut, Route("update")]
        public async Task<IActionResult> Update([FromBody] CustomerDto requestDto)
        {
            await _CustomerService.UpdateCustomer(requestDto.ToCustomerModel());
            return Ok();
        }

        [HttpDelete, Route("{CustomerId}")]
        public async Task<IActionResult> Delete(int CustomerId)
        {
            await _CustomerService.DeleteCustomer(CustomerId);
            return Ok();
        }
    }
}
