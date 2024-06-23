using Zenject;

namespace Splash
{
    public class SplashInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SplashManager>()
                .FromNewComponentOnNewGameObject()
                .AsSingle()
                .NonLazy();
        }
    }
}