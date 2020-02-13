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
            services.AddCors();
            services.AddControllers();
            var appSettingsSection = Configuration.GetSection("JWT");
            services.Configure<JwtSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<JwtSettings>();

            // services.AddOptions();
            services.AddAuthentication(x => 
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            })
            .AddJwtBearer(x=>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(appSettings.Key)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

            }
            );
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
          builder.RegisterModule(new ContainerModule(Configuration));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
    
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });

        }
    }
}
