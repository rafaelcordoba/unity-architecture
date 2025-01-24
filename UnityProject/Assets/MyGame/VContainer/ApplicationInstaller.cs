using MyGame.Application.Hello;
using VContainer;

namespace MyGame.VContainer
{
    public static class ApplicationInstaller
    {
        public static void Install(IContainerBuilder builder)
        {
            builder.Register<HelloUseCase>(Lifetime.Singleton);
        }
    }
}