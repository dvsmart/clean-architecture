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
        }
    }
}
