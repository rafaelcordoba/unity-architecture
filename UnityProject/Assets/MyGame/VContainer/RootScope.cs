using MyGame.Application.Hello;
using MyGame.Common.Logging;
using MyGame.Common.Net;
using MyGame.Common.Serialization;
using MyGame.Common.System;
using MyGame.Configs;
using MyGame.Infrastructure;
using MyGame.Infrastructure.Hello;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using HttpClientHandler = MyGame.Common.Net.HttpClientHandler;
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
            builder.Register<IJsonSerializer, NewtonSoftJsonSerializer>(Lifetime.Singleton);
            builder.Register<IRandomFactory, SystemRandomFactory>(Lifetime.Singleton);
            
            builder.Register<IGreetingService, ServerApi>(Lifetime.Singleton);
            builder.Register<HelloUseCase>(Lifetime.Singleton);
            builder.Register<IHttpHandler, HttpClientHandler>(Lifetime.Singleton);
        }
    }
}