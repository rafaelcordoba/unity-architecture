using MyGame.Application.Hello;
using MyGame.Common.Logging;
using MyGame.Configs;
using MyGame.Infrastructure;
using MyGame.Infrastructure.Hello;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using ILogger = MyGame.Common.Logging.ILogger;

namespace MyGame.VContainer
{
    public class RootScope : LifetimeScope
    {
        [SerializeField] private ServerConfig serverConfig;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance<IServerConfig>(serverConfig);
            
            builder.Register<ILogger, UnityLogger>(Lifetime.Singleton);
            
            builder.Register<IGreetingService, ServerApi>(Lifetime.Singleton);
            builder.Register<HelloUseCase>(Lifetime.Singleton);
        }
    }
}