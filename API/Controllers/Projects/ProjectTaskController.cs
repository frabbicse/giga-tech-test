using Infrastructure.IServices.IProjects;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Models.Projects.Dtos;

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

    }
}
