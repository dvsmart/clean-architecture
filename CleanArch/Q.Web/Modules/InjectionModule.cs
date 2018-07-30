using Autofac;
using Q.Infrastructure;
using Q.Infrastructure.Mappings;
using Q.Services.Interfaces;
using Q.Services.Interfaces.Assessment;
using Q.Services.Interfaces.Asset.Properties;
using Q.Services.Interfaces.Generic;
using Q.Services.Interfaces.Reference;
using Q.Services.Interfaces.Task;
using Q.Services.Interfaces.User;
using Q.Services.Service.Assessment;
using Q.Services.Service.Asset.Properties;
using Q.Services.Service.Menu;
using Q.Services.Service.Reference;
using Q.Services.Service.Task;
using Q.Services.Service.User;
using Q.Web.Mappings;
using System.Reflection;

namespace Q.Web.Modules
{
    public class InjectionModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IOutputConverter).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(OutputConverter).Assembly)
                .AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType(typeof(TaskService)).As(typeof(ITaskService)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(TaskPriorityService)).As(typeof(ITaskPriorityService)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(TaskStatusService)).As(typeof(ITaskStatusService)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(MenuService)).As(typeof(IMenuService)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UserService)).As(typeof(IUserService)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(AssetPropertyService)).As(typeof(IAssetPropertyService)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(AssessmentService)).As(typeof(IAssessmentService)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(AssessmentScopeService)).As(typeof(IAssessmentScopeService)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(AssessmentStatusService)).As(typeof(IAssessmentStatusService)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(AssessmentTypeService)).As(typeof(IAssessmentTypeService)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(ReferenceService)).As(typeof(IReferenceService)).InstancePerLifetimeScope();
        }
    }
}
