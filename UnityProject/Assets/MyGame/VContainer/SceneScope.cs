using VContainer;
using VContainer.Unity;

namespace MyGame.VContainer
{
    public class SceneScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // Hello World Presenter is in base.autoInjectGameObjects (check sample scene) 
        }
    }
}