using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using GetARide.Core.Repositories;
using GetARide.Infrastructure.IoC.Modules;
using GetARide.Infrastructure.Mappers;
using GetARide.Infrastructure.Repositories;
using GetARide.Infrastructure.Services;
using GetARide.Infrastructure.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace GetARide.Api
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IdentityModelEventSource.ShowPII = true;


            var appSettingsSection = Configuration.GetSection("JwtSettings");
            services.Configure<JwtSettings>(appSettingsSection);
            
            var appSettings = appSettingsSection.Get<JwtSettings>();
           
            
            services.AddControllers();
            // services.AddScoped<IUserService,UserService>();
            // services.AddScoped<IUserRepository,UserRepository>();
            // services.AddSingleton(AutoMapperConfig.Initialize());
            services.AddOptions();
            services.AddAuthentication(x => 
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x=>
            {
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidIssuer = appSettings.Issuer,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(appSettings.Key))
                };
            }
            );
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
          // Register your own things directly with Autofac, like:
        //   builder.RegisterModule(new CommandModule());
        //   builder.RegisterModule(new SettingsModule(Configuration));
          builder.RegisterModule(new ContainerModule(Configuration));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            var jwtSettings = app.ApplicationServices.GetServices<JwtSettings>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
