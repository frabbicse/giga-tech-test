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
using System.Net;
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

            return _mapper.Map<List<Project>, List<ProjectDto>>(projects);
        }

        public async Task<bool> AddMembertoProject(ProjectMemberDto projectMember)
        {
            try
            {

                var r = _context.TaskMembers.Where(x => x.MemberId == projectMember.MemberId && x.ProjectId == projectMember.ProjectId).Any();
                if (!r)
                {
                    var taskToMember = new ProjectMember
                    {
                        ProjectId = projectMember.ProjectId,
                        MemberId = projectMember.MemberId
                    };
                    _context.ProjectMembers.Add(taskToMember);

                }
                else
                {
                    var taskToMember = new ProjectMember
                    {
                        Id = projectMember.Id,
                        ProjectId = projectMember.ProjectId,
                        MemberId = projectMember.MemberId
                    };
                    _context.ProjectMembers.Update(taskToMember);

                }

                var result = await _context.SaveChangesAsync() > 0;
                if (result) return true;
                return false;
            }
            catch (Exception e)
            {
                throw new RestException(HttpStatusCode.InternalServerError, "Not Inserted.");
            }
        }
    }
}
