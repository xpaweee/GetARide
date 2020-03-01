using System.Reflection;
using Autofac;
using GetARide.Infrastructure.EF;

namespace GetARide.Infrastructure.IoC.Modules
{
    public class SqlModule: Autofac.Module
    {
        protected override void Load(Autofac.ContainerBuilder builder)
        {
            var assembly = typeof(RepositoryModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<ISqlRepository>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        } 
    }
}