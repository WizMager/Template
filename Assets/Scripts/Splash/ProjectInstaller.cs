using Services.SceneLoadingService.Impl;
using Zenject;

namespace Splash
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SceneLoadingService>().AsSingle();
        }
    }
}