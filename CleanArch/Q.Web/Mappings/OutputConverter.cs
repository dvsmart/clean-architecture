using AutoMapper;
using Q.Domain.Assessment;
using Q.Domain.Asset;
using Q.Domain.CustomEntity;
using Q.Domain.Event;
using Q.Domain.Task;
using Q.Domain.User;
using Q.Infrastructure.Mappings;
using Q.Web.Models;
using Q.Web.Models.Assessment;
using Q.Web.Models.Asset;
using Q.Web.Models.CustomEntity;
using Q.Web.Models.Event;
using Q.Web.Models.User;

namespace Q.Web.Mappings
{
    public class OutputConverter : IOutputConverter
    {
        private readonly IMapper _mapper;

        public OutputConverter()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TaskProfile>();
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<AssessmentProfile>();
                cfg.AddProfile<AssetPropertiesProfile>();
                cfg.AddProfile<EventProfile>();
                cfg.AddProfile<CustomEntityProfile>();
            })
            .CreateMapper();
        }

        public T Map<T>(object source)
        {
            var model = _mapper.Map<T>(source);
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
                .ForMember(x => x.RoleName, o => o.MapFrom(s => s.UserRole.RoleName));
            CreateMap<CreateNewUserRequest, User>();
        }
    }

    public class AssessmentProfile: Profile
    {
        public AssessmentProfile()
        {
            CreateMap<Assessment, AssessmentListModel>()
                .ForMember(x => x.AssessmentType, o => o.MapFrom(s => s.AssessmentType.Name))
                .ForMember(x => x.AssessmentScope, o => o.MapFrom(s => s.AssessmentScope.Name));
            CreateMap<Assessment, CreateAssessmentRequest>()
                .ForMember(x => x.AssessmentType, o => o.ResolveUsing(s => s.AssessmentType.Name))
                .ForMember(x => x.Scope, o => o.ResolveUsing(s => s.AssessmentScope.Name))
                .ForMember(x => x.PublishedBy, o => o.MapFrom(s => "Publisher"));
        }
    }

    public class AssetPropertiesProfile : Profile
    {
        public AssetPropertiesProfile()
        {
            CreateMap<AssetProperty, AssetProperties>()
                .ForMember(x => x.AssetId, o => o.ResolveUsing(s => s.Asset.Id))
                .ForMember(x => x.AssetType, o => o.ResolveUsing(s => s.Asset.AssetType.Name))
                .ForMember(x => x.PortfolioName, o => o.MapFrom(s => "some PorfolioName"))
                .ForMember(x => x.SubPortfolioName, o => o.MapFrom(s => "sub PorfolioName"));
            CreateMap<CreateAssetPropertyRequest, AssetProperty>();
        }
    }

    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventModel>().ForMember(x => x.RecurrenceType, o => o.MapFrom(s => s.RecurrenceType.Name));
        }
    }

    public class CustomEntityProfile: Profile
    {
        public CustomEntityProfile()
        {
            CreateMap<CustomEntityGroup, CustomEntityGroupModel>();
            CreateMap<CustomEntity, CustomEntityTemplateModel>();
        }
    }

}
