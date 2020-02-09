using System.Reflection;
using Autofac;
using GetARide.Core.Repositories;

namespace GetARide.Infrastructure.IoC.Modules
{
    public class RepositoryModule : Autofac.Module
    {
         protected override void Load(Autofac.ContainerBuilder builder)
        {
            var assembly = typeof(RepositoryModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IRepository>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}