using Zenject;

namespace Splash
{
    public class SplashInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //MainThreadDispatcher.Initialize(); use this and after MainThreadDispatcher.Enqueue if need do something heavy

            Container.Bind<SplashManager>()
                .FromNewComponentOnNewGameObject()
                .AsSingle()
                .NonLazy();
        }
    }
}