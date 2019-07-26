using Autofac;
using Guesthouse.Infrastructure.IoC.Modules;
using Microsoft.Extensions.Configuration;

namespace Guesthouse.Infrastructure.IoC
{
    public class InfrastructureModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public InfrastructureModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<AuthModule>();
        }
    }
}