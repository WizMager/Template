using Services.SceneLoadingService.Impl;
using Zenject;

namespace Project
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            
            Container.BindInterfacesAndSelfTo<SceneLoadingService>().AsSingle();
        }
    }
}