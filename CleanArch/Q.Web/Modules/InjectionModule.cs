using Autofac;
using Q.Infrastructure;
using Q.Infrastructure.Mappings;
using Q.Services.Interfaces;
using Q.Services.Service.Menu;
using Q.Services.Service.Task;
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
        }
    }
}
