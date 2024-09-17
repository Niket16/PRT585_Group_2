using Microsoft.AspNetCore.Mvc;

namespace WebApplication3tierApp.Controllers
{    
    [Route("KaiInterface")]
    [ApiController]
    [Produces("application/json")]
    public class KaiInterfaceController : ControllerBase
    {
        private readonly ILogger<KaiInterfaceController> _logger;

        public KaiInterfaceController(ILogger<KaiInterfaceController> logger) 
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetKaiInterface")]
        public IEnumerable<KaiInterface> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new KaiInterface
            {
                Date = DateTime.Now.AddDays(index),
                Data = $"Data for item {index}"
            })
            .ToArray();
        }

        [HttpGet("GetItemDetails/{id}", Name = "GetItemDetails")]
        public IActionResult GetItemDetails(int id)
        {
            var itemDetails = new KaiInterface
            {
                Date = DateTime.Now,
                Data = $"Details for item {id}"
            };

            return new JsonResult(itemDetails);
        }
    }
}
