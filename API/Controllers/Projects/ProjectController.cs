using Infrastructure.IServices.IProjects;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Models.Projects.Dtos;

using System.Threading.Tasks;

namespace API.Controllers.Projects
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateProject(ProjectDto projectDto)
        {
            await _projectService.CreateProejct(projectDto);
            return Ok();
        }
    }
}
