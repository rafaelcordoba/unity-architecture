using MyGame.Common.Logging;
using MyGame.Logging;
using VContainer;
using VContainer.Unity;

namespace MyGame.VContainer
{
    public class RootScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<ILogger, UnityLogger>(Lifetime.Singleton);
            
            ApplicationInstaller.Install(builder);
            InfrastructureInstaller.Install(builder);
        }
    }
}