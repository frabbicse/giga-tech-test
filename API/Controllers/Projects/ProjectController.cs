using Infrastructure.IServices.IProjects;
using Infrastructure.Services.Projects;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Models.Projects.Dtos;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers.Projects
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpGet]
        public async Task<ActionResult<List<ProjectDto>>> GetProjects()
        {
            return await _projectService.ProjectList();
        }
        [HttpPost("add-member-project")]
        public async Task<ActionResult<bool>> AddTaskMember(ProjectMemberDto projectMemeberDto)
        {
            return await _projectService.AddMembertoProject(projectMemeberDto);
        }
    }
}
