using AutoMapper;

using Models.Projects;
using Models.Projects.Dtos;

namespace Infrastructure.Common
{
    public class Automapping : Profile
    {
        public Automapping()
        {
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<ProjectTask, ProjectTaskDto>().ReverseMap();
            CreateMap<ProjectMember, ProjectMemberDto>().ReverseMap();
            CreateMap<TaskMember, TaskMemberDto>().ReverseMap();

        }
    }
}
