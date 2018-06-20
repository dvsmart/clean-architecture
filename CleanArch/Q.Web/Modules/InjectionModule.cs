using Autofac;
using Q.Infrastructure;
using Q.Infrastructure.Mappings;
using System.Reflection;

namespace Q.Web.Modules
{
    public class InjectionModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Repository<>))
           .As(typeof(IRepository<>))
           .InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IOutputConverter).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(OutputConverter).Assembly)
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
