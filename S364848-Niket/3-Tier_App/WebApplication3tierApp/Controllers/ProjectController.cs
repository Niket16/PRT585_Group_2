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
    public class ProjectController : BaseController
    {

        private readonly IProjectService _ProjectService;
        private readonly ILogger<ProjectController> _logger;

        public ProjectController(IProjectService ProjectService, ILogger<ProjectController> logger)
        {
            _ProjectService = ProjectService;
            _logger = logger;
        }

        [HttpGet("", Name = "GetAllProjects")]
        public async Task<List<ProjectDto>> GetAll()
        {
            var result = await _ProjectService.GetAll();
            return result.Select(x => x.ToProjectDto()).ToList();
        }

        [HttpGet("{ProjectId}", Name = "GetProject")]
        public async Task<ProjectDto?> Get(int ProjectId)
        {
            var result = await _ProjectService.GetById(ProjectId);
            return result?.ToProjectDto();
        }

        [HttpPost, Route("")]
        public async Task<int> Create([FromBody] ProjectDto requestDto)
        {
            var ProjectModel = requestDto.ToProjectModel();
            return await _ProjectService.CreateProject(ProjectModel);
        }

        [HttpPut, Route("update")]
        public async Task<IActionResult> Update([FromBody] ProjectDto requestDto)
        {
            await _ProjectService.UpdateProject(requestDto.ToProjectModel());
            return Ok();
        }

        [HttpDelete, Route("{ProjectId}")]
        public async Task<IActionResult> Delete(int ProjectId)
        {
            await _ProjectService.DeleteProject(ProjectId);
            return Ok();
        }
    }
}
