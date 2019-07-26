using Autofac;
using Guesthouse.Services.Mappers;

namespace Guesthouse.Services.IoC.Modules
{
    public class MapperModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.Initialize())
                .SingleInstance();
        }
    }
}