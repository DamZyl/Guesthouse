using Autofac;
using Guesthouse.Infrastructure.Auth;

namespace Guesthouse.Infrastructure.IoC.Modules
{
    public class AuthModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JwtHandler>()
                .As<IJwtHandler>()
                .SingleInstance();
        }
    }
}