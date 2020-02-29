using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using GetARide.Api.Framework;
using GetARide.Core.Repositories;
using GetARide.Infrastructure.EF;
using GetARide.Infrastructure.IoC.Modules;
using GetARide.Infrastructure.Mappers;
using GetARide.Infrastructure.Mongo;
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
             
            services.AddAuthorization(x=> x.AddPolicy("admin", p => p.RequireRole("admin")));
            // services.AddAuthorization()
            services.AddMemoryCache();
            services.AddControllers();
            //services.AddTransient   <- nowy obiekt za każdym razem
            //services.AddScoped   <- pojedyncze per żądanie http
            // services.AddScoped<IEventRepository,EventRepository>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IDriverService,DriverService>();
            services.AddSingleton<IJwtHandler,JwtHandler>();
            services.AddSingleton(AutoMapperConfig.Initialize());
            services.AddMemoryCache();
            services.AddEntityFrameworkSqlServer()
                .AddEntityFrameworkInMemoryDatabase()
                .AddDbContext<GetARideContext>();
            MongoConfigurator.Initialize();
           

            // configure jwt authentication
            var appSettingsSection = Configuration.GetSection("jwt");
            services.Configure<JwtSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<JwtSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Key);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    // ValidateIssuerSigningKey = true,
                    // IssuerSigningKey = new SymmetricSecurityKey(key),
                    // ValidateIssuer = false,
                    // ValidateAudience = false
                    ValidIssuer = appSettings.Issuer,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)       

                };
            });

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

           if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            app.UseHttpsRedirection();
            
            app.UseMyExceptionHandler();
            
            
           //app.UseErrorHandler();

            app.UseRouting();

            app.UseAuthentication();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
