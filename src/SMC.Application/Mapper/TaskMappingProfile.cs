using AutoMapper;
using SMC.Application.Commands;
using SMC.Application.Responses;

namespace SMC.Application.Mapper
{
    public class TaskMappingProfile : Profile
    {
        public TaskMappingProfile()
        {
            CreateMap<Core.Entities.Task, TaskResponse>().ReverseMap();
            CreateMap<Core.Entities.Task, CreateTaskCommand>().ReverseMap();
        }
    }
}