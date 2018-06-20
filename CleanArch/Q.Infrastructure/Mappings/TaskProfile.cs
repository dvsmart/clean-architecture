using AutoMapper;
using Q.Domain.Menu;
using Q.Domain.Task;
using Q.Service.UseCases.Menu;
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

    internal class MenuProfile: Profile
    {
        public MenuProfile()
        {
            CreateMap<MenuItem, MenuItemsOutput>();
            CreateMap<TaskDto, Task>();
        }
    }
}
