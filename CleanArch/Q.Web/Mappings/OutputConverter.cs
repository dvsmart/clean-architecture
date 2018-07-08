using AutoMapper;
using Q.Domain.Task;
using Q.Domain.User;
using Q.Infrastructure.Mappings;
using Q.Web.Models;
using Q.Web.Models.User;

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
                cfg.AddProfile<UserProfile>();
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

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserListModel>()
                .ForMember(x => x.FirstName, o => o.MapFrom(s => s.UserProfile.FirstName))
                .ForMember(x => x.LastName, o => o.MapFrom(s => s.UserProfile.LastName))
                .ForMember(x => x.Address, o => o.MapFrom(s => s.UserProfile.Address))
                .ForMember(x => x.City, o => o.MapFrom(s => s.UserProfile.City))
                .ForMember(x => x.RoleName, o => o.MapFrom(s => s.UserRole.RoleName))
                .ForMember(x => x.UserType, o => o.MapFrom(s => s.UserType.Name));
            CreateMap<CreateNewUserRequest, User>();
        }
    }

}
