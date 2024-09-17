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
    public class ProductController : BaseController
    {

        private readonly IProductService _ProductService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService ProductService, ILogger<ProductController> logger)
        {
            _ProductService = ProductService;
            _logger = logger;
        }

        [HttpGet("", Name = "GetAllProducts")]
        public async Task<List<ProductDto>> GetAll()
        {
            var result = await _ProductService.GetAll();
            return result.Select(x => x.ToProductDto()).ToList();
        }

        [HttpGet("{ProductId}", Name = "GetProduct")]
        public async Task<ProductDto?> Get(int ProductId)
        {
            var result = await _ProductService.GetById(ProductId);
            return result?.ToProductDto();
        }

        [HttpPost, Route("")]
        public async Task<int> Create([FromBody] ProductDto requestDto)
        {
            var ProductModel = requestDto.ToProductModel();
            return await _ProductService.CreateProduct(ProductModel);
        }

        [HttpPut, Route("update")]
        public async Task<IActionResult> Update([FromBody] ProductDto requestDto)
        {
            await _ProductService.UpdateProduct(requestDto.ToProductModel());
            return Ok();
        }

        [HttpDelete, Route("{ProductId}")]
        public async Task<IActionResult> Delete(int ProductId)
        {
            await _ProductService.DeleteProduct(ProductId);
            return Ok();
        }
    }
}
