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
            CreateMap<TaskStatus, TaskStatusModel>();
            CreateMap<TaskPriority, TaskPriorityModel>();
        }
    }
   
}
