using AutoMapper;
using Q.Domain.Task;
using Q.Infrastructure.Mappings;
using Q.Web.Models;

namespace Q.Web.Mappings
{
    public class OutputConverter : IOutputConverter
    {
        private readonly IMapper mapper;

        public OutputConverter()
        {
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TaskProfile>();
            })
            .CreateMapper();
        }

        public T Map<T>(object source)
        {
            T model = mapper.Map<T>(source);
            return model;
        }
    }

    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<Task, TaskModel>();
            CreateMap<Task, TaskListModel>()
                    .ForMember(x => x.Status, o => o.MapFrom(s => s.TaskStatus.Name))
                    .ForMember(x => x.Priority, o => o.MapFrom(s => s.TaskPriority.Name));
            CreateMap<TaskStatus, TaskStatusModel>();
            CreateMap<TaskPriority, TaskPriorityModel>();
            CreateMap<TaskModel, Task>()
                    .ForMember(x => x.TaskStatus, o => o.Ignore())
                    .ForMember(x => x.TaskPriority, o => o.Ignore())
                    .ForMember(x => x.AddedBy, o => o.MapFrom(x => x.CreatedBy));

        }
    }
   
}
