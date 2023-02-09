using Models.Projects;
using Models.Projects.Dtos;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.IServices.IProjects
{
    public interface ITaskService
    {
        Task<bool> CreateProjectTask(ProjectTaskDto task);
        Task<List<ProjectTaskDto>> ProjectTaskList();
    }
}
