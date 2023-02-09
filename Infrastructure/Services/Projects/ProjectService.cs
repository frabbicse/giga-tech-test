using Infrastructure.Common;
using Infrastructure.IServices.IHelperService;
using Infrastructure.IServices.IProjects;
using Infrastructure.Security;

using Models.Projects;
using Models.Projects.Dtos;

using Persistance;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Projects
{
    public class ProjectService : IProjectService
    {
        private readonly GigaTechContext _context;
        private readonly IDateFormat _dateFormat;
        private readonly IUserAccessor _userAccessor;

        public ProjectService(GigaTechContext context, IDateFormat dateFormat, IUserAccessor userAccessor)
        {
            _context = context;
            _dateFormat = dateFormat;
            _userAccessor = userAccessor;
        }
        public async Task<bool> CreateProejct(ProjectDto projectDto)
        {
            try
            {
                var project = new Project
                {
                    Name = projectDto.Name,
                    Description = projectDto.Description,
                    ProjectTypeId = projectDto.ProjectTypeId,
                    InsertDate = _dateFormat.Now,
                    PostedBy = projectDto.PostedBy
                };
                _context.Projects.Add(project);
                await _context.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {

                throw new RestException(System.Net.HttpStatusCode.BadRequest, "Not Inserted");
            }
        }

        public Task<List<ProjectDto>> ProjectList()
        {
            throw new NotImplementedException();
        }
    }
}
