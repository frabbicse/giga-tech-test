using AutoMapper;

using Infrastructure.Common;
using Infrastructure.IServices.IHelperService;
using Infrastructure.IServices.IProjects;
using Infrastructure.Security;

using Microsoft.EntityFrameworkCore;

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
        private readonly IMapper _mapper;

        public ProjectService(GigaTechContext context, IDateFormat dateFormat, IMapper mapper)
        {
            _context = context;
            _dateFormat = dateFormat;
            _mapper = mapper;
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

        
        public async Task<List<ProjectDto>> ProjectList()
        {
            var projects = await _context.Projects.ToListAsync();

            return _mapper.Map<List<Project>,List<ProjectDto>>(projects);
        }
    }
}
