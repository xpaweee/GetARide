using Autofac;
using GetARide.Infrastructure.Settings;
using GetARide.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;

namespace GetARide.Infrastructure.IoC.Modules
{
    public class SettingsModule : Autofac.Module
    {
        public IConfiguration _configuration { get; }
        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        protected override void Load(Autofac.ContainerBuilder builder)
        {
        
            builder.RegisterInstance(_configuration.GetSettings<GeneralSettings>())
                .SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<JwtSettings>())
                .SingleInstance();
            
        }
    }
}