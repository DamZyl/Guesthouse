using System.Reflection;
using Autofac;

namespace Guesthouse.Services.IoC.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ServiceModule).Assembly)
                .AsImplementedInterfaces();
        }
    }
}