using System;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Guesthouse.Core.Repositories;
using Guesthouse.Infrastructure.Auth;
using Guesthouse.Infrastructure.Database;
using Guesthouse.Infrastructure.IoC;
using Guesthouse.Infrastructure.IoC.Modules;
using Guesthouse.Infrastructure.Repositories;
using Guesthouse.Services.IoC;
using Guesthouse.Services.Mappers;
using Guesthouse.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Guesthouse.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IContainer Container { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<SqlOptions>(Configuration.GetSection("sql"));
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(x => x.SerializerSettings.Formatting = Formatting.Indented);
            
            services.AddDbContext<DatabaseContext>();

            var jwtSection = Configuration.GetSection("Jwt");
            services.Configure<JwtOptions>(jwtSection);
            var jwtOptions = new JwtOptions();
            jwtSection.Bind(jwtOptions);
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(cfg =>
                {
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),
                        ValidIssuer = jwtOptions.Issuer,
                        ValidateAudience = false,
                        ValidateLifetime = jwtOptions.ValidateLifetime
                    };
                });
            
            services.AddAuthorization(x => x.AddPolicy("Admin", p => p.RequireRole("Admin")));
            services.AddAuthorization(x => x.AddPolicy("Employee", p => p.RequireRole("Employee")));
            services.AddAuthorization(x => x.AddPolicy("User", p => p.RequireRole("User")));

            services.AddTransient<DbInitializer>();
            
            var builder =  new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule(new InfrastructureModule(Configuration));
            builder.RegisterModule(new ServicesModule(Configuration));
            Container = builder.Build();

            return new AutofacServiceProvider(Container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DbInitializer initDb)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            initDb.SeedData().Wait();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
