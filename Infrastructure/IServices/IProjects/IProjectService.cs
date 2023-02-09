using Models.Projects.Dtos;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.IServices.IProjects
{
    public interface IProjectService
    {
        Task<bool> CreateProejct(ProjectDto project);
        Task<List<ProjectDto>> ProjectList();
    }
}
