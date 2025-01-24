using MyGame.Domain.Hello;
using MyGame.Infrastructure.Hello;
using VContainer;

namespace MyGame.VContainer
{
    internal static class InfrastructureInstaller
    {
        public static void Install(IContainerBuilder builder)
        {
            builder.Register<IGreetingService, GreetingService>(Lifetime.Singleton);
        }
    }
}