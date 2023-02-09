using Infrastructure.Common;
using Infrastructure.IServices.IHelperService;
using Infrastructure.IServices.IProjects;

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
    public class TaskService : ITaskService
    {
        private readonly GigaTechContext _context;
        private readonly IDateFormat _dateFormat;

        public TaskService(GigaTechContext context, IDateFormat dateFormat)
        {
            _context = context;
            _dateFormat = dateFormat;
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
                    ProjectId= taskDto.ProjectId,
                    PostedBy    = taskDto.PostedBy,
                    InsertDate  = _dateFormat.Now
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

        public Task<List<ProjectTaskDto>> ProjectTaskList()
        {
            throw new NotImplementedException();
        }
    }
}
