using Services.SceneLoadingService.Impl;
using Zenject;

namespace Project
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SceneLoadingService>().AsSingle();
        }
    }
}