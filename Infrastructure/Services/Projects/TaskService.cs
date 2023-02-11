using AutoMapper;

using Infrastructure.Common;
using Infrastructure.IServices.IHelperService;
using Infrastructure.IServices.IProjects;

using Microsoft.EntityFrameworkCore;

using Models.Auth;
using Models.Projects;
using Models.Projects.Dtos;

using Persistance;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Projects
{
    public class TaskService : ITaskService
    {
        private readonly GigaTechContext _context;
        private readonly IDateFormat _dateFormat;
        private readonly IMapper _mapper;

        public TaskService(GigaTechContext context, IDateFormat dateFormat, IMapper mapper)
        {
            _context = context;
            _dateFormat = dateFormat;
            _mapper = mapper;
        }

        public async Task<bool> AddMembertoTask(TaskMemberDto taskMember)
        {
            try
            {

                var r =  _context.TaskMembers.Where(x => x.MemberId == taskMember.MemberId && x.TaskId == taskMember.TaskId && x.ProjectId == taskMember.ProjectId).Any();
                if (!r)
                {
                    var taskToMember = new TaskMember
                    {
                        MemberId = taskMember.MemberId,
                        TaskId = taskMember.TaskId,
                        ProjectId = taskMember.ProjectId,
                        InsertDate = _dateFormat.Now,
                        PostedBy = taskMember.PostedBy,
                    };
                    _context.TaskMembers.Add(taskToMember);

                }
                else
                {
                    var taskToMember = new TaskMember
                    {
                        Id= taskMember.Id,
                        MemberId = taskMember.MemberId,
                        TaskId = taskMember.TaskId,
                        ProjectId = taskMember.ProjectId,
                        UpdateDate = _dateFormat.Now,
                        ModifiedBy = taskMember.ModifiedBy,
                    };

                    _context.Update<TaskMember>(taskToMember);

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

        public async Task<bool> CreateProjectTask(ProjectTaskDto taskDto)
        {
            try
            {
                var task = new ProjectTask
                {
                    Name = taskDto.Name,
                    Description = taskDto.Description,
                    StartDate = taskDto.StartDate,
                    EndDate = taskDto.EndDate,
                    StatusId = taskDto.StatusId,
                    ProjectId = taskDto.ProjectId,
                    PostedBy = taskDto.PostedBy,
                    InsertDate = _dateFormat.Now
                };

                _context.Tasks.Add(task);
                var result = await _context.SaveChangesAsync() > 0;
                if (result)
                    return true;
                throw new RestException(HttpStatusCode.BadRequest, "Not Inserted.");
            }
            catch (Exception)
            {
                throw new RestException(HttpStatusCode.InternalServerError, "Not Inserted.");
            }
        }

        public async Task<List<ProjectTaskDto>> ProjectTaskList(int projectId)
        {
            try
            {
                var tasks = await _context.Tasks.Where(x => x.ProjectId == projectId).ToListAsync();

                return _mapper.Map<List<ProjectTask>, List<ProjectTaskDto>>(tasks);
            }
            catch (Exception)
            {
                throw new RestException(HttpStatusCode.InternalServerError);
            }
        }

        public async Task<bool> UpdateProjectTask(ProjectTaskDto task)
        {
            try
            {
                if (_context.Tasks.Where(x => x.Id == task.Id).Any())
                {
                    var taskData = _mapper.Map<ProjectTaskDto, ProjectTask>(task);
                    _context.Update(taskData);

                    var result = await _context.SaveChangesAsync() > 0;

                    if (result) return true;
                    return false;
                }
                throw new RestException(HttpStatusCode.NotFound, "Not Found.");
            }
            catch (Exception e)
            {
                throw new RestException(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
