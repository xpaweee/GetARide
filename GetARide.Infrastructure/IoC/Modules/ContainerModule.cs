using Autofac;
using GetARide.Infrastructure.Mappers;
using GetARide.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;

namespace GetARide.Infrastructure.IoC.Modules
{
    public class ContainerModule :  Autofac.Module
    {
        public IConfiguration _configuration { get; }
        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        protected override void Load(Autofac.ContainerBuilder builder)
        {
        
            builder.RegisterInstance(AutoMapperConfig.Initialize())
                .SingleInstance();
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule(new SettingsModule(_configuration));
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<MongoModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<SqlModule>();
        }
    }
}