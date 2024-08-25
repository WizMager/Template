using Services.CameraService.Impl;
using UnityEngine;
using Views.Impl;
using Zenject;

namespace Game.Installers
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField] private VirtualCameraView _virtualCameraView;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CameraService>().AsSingle().WithArguments(_virtualCameraView.Cameras);
        }
    }
}