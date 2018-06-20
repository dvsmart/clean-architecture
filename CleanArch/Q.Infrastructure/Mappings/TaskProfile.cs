using AutoMapper;
using Q.Domain.Task;
using Q.Service.UseCases.Task;

namespace Q.Infrastructure.Mappings
{
    internal class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<Task, TaskDto>();
            CreateMap<TaskDto, Task>();
        }
    }
}
