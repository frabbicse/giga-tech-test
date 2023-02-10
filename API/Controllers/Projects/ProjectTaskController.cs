using Infrastructure.IServices.IProjects;
using Infrastructure.Services.Projects;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Models.Projects.Dtos;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers.Projects
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public ProjectTaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTask(ProjectTaskDto taskDto)
        {
            await _taskService.CreateProjectTask(taskDto);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectTaskDto>>> GetProjectTasks(int projectId)
        {
            return await _taskService.ProjectTaskList(projectId);
        }

        [HttpPatch]
        public async Task<ActionResult<bool>> UpdateTask(ProjectTaskDto projectTaskDto)
        {
            return await _taskService.UpdateProjectTask(projectTaskDto);
        }
    }
}
