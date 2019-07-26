using Autofac;
using Guesthouse.Services.IoC.Modules;
using Microsoft.Extensions.Configuration;

namespace Guesthouse.Services.IoC
{
    public class ServicesModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public ServicesModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<MapperModule>();
        }
    }
}