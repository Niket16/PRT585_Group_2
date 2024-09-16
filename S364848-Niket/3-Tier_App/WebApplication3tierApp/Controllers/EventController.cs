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
    public class EventController : BaseController
    {

        private readonly IEventService _EventService;
        private readonly ILogger<EventController> _logger;

        public EventController(IEventService EventService, ILogger<EventController> logger)
        {
            _EventService = EventService;
            _logger = logger;
        }

        [HttpGet("", Name = "GetAllEvents")]
        public async Task<List<EventDto>> GetAll()
        {
            var result = await _EventService.GetAll();
            return result.Select(x => x.ToEventDto()).ToList();
        }

        [HttpGet("{EventId}", Name = "GetEvent")]
        public async Task<EventDto?> Get(int EventId)
        {
            var result = await _EventService.GetById(EventId);
            return result?.ToEventDto();
        }

        [HttpPost, Route("")]
        public async Task<int> Create([FromBody] EventDto requestDto)
        {
            var EventModel = requestDto.ToEventModel();
            return await _EventService.CreateEvent(EventModel);
        }

        [HttpPut, Route("update")]
        public async Task<IActionResult> Update([FromBody] EventDto requestDto)
        {
            await _EventService.UpdateEvent(requestDto.ToEventModel());
            return Ok();
        }

        [HttpDelete, Route("{EventId}")]
        public async Task<IActionResult> Delete(int EventId)
        {
            await _EventService.DeleteEvent(EventId);
            return Ok();
        }
    }
}
