using Autofac;
using Q.Infrastructure;
using Q.Infrastructure.Mappings;
using Q.Web.Mappings;
using Q.Web.Controllers.Asset;
using Q.Domain;
using System.Reflection;

namespace Q.Web.Modules
{
    public class InjectionModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>));

            builder.RegisterAssemblyTypes(Assembly.Load("Q.Services")).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(IOutputConverter).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(OutputConverter).Assembly)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            

            builder.RegisterAssemblyTypes(typeof(Presenter).Assembly).AsSelf().InstancePerLifetimeScope();
            //builder.RegisterType(typeof(TaskService)).As(typeof(ITaskService)).InstancePerLifetimeScope();
            //builder.RegisterType(typeof(EventService)).As(typeof(IEventService)).InstancePerLifetimeScope();
            //builder.RegisterType(typeof(TaskPriorityService)).As(typeof(ITaskPriorityService)).InstancePerLifetimeScope();
            //builder.RegisterType(typeof(TaskStatusService)).As(typeof(ITaskStatusService)).InstancePerLifetimeScope();
            //builder.RegisterType(typeof(MenuService)).As(typeof(IMenuService)).InstancePerLifetimeScope();
            //builder.RegisterType(typeof(UserService)).As(typeof(IUserService)).InstancePerLifetimeScope();
            //builder.RegisterType(typeof(AssetPropertyService)).As(typeof(IAssetPropertyService)).InstancePerLifetimeScope();
            //builder.RegisterType(typeof(AssessmentService)).As(typeof(IAssessmentService)).InstancePerLifetimeScope();
            //builder.RegisterType(typeof(AssessmentScopeService)).As(typeof(IAssessmentScopeService)).InstancePerLifetimeScope();
            //builder.RegisterType(typeof(AssessmentStatusService)).As(typeof(IAssessmentStatusService)).InstancePerLifetimeScope();
            //builder.RegisterType(typeof(AssessmentTypeService)).As(typeof(IAssessmentTypeService)).InstancePerLifetimeScope();
            //builder.RegisterType(typeof(ReferenceService)).As(typeof(IReferenceService)).InstancePerLifetimeScope();

            //builder.RegisterType(typeof(CEGroupService)).As(typeof(ICEGroupService)).InstancePerLifetimeScope();
            //builder.RegisterType(typeof(CETemplateService)).As(typeof(ICETemplateService)).InstancePerLifetimeScope();
            //builder.RegisterType(typeof(CustomTabService)).As(typeof(ICustomTabService)).InstancePerLifetimeScope();
            //builder.RegisterType(typeof(CustomFieldService)).As(typeof(ICustomFieldService)).InstancePerLifetimeScope();
            //builder.RegisterType(typeof(CEReferenceService)).As(typeof(ICEReferenceService)).InstancePerLifetimeScope();
            //builder.RegisterType(typeof(CustomFieldValueService)).As(typeof(ICustomFieldValueService)).InstancePerLifetimeScope();
            //builder.RegisterType(typeof(CEInstanceService)).As(typeof(ICEInstanceService)).InstancePerLifetimeScope();
        }
    }
}
