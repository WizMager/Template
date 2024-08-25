using Services.InitializeService.Impl;
using Services.InputService.Impl;
using Zenject;

namespace Game.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InitializeService>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
        }
    }
}