using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guesthouse.Core.Repositories;
using Guesthouse.Infrastructure.Database;
using Guesthouse.Infrastructure.Mappers;
using Guesthouse.Infrastructure.Repositories;
using Guesthouse.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Guesthouse.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(x => x.SerializerSettings.Formatting = Formatting.Indented);
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(cfg =>
            {
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });


            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration
                .GetConnectionString("GuesthouseDatabase"), b => b.MigrationsAssembly("Guesthouse.Api")));

            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddSingleton(AutoMapperConfig.Initialize());
            services.AddSingleton<IJwtHandler, JwtHandler>();
            services.AddTransient<DbInitializer>();
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
