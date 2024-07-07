using KoboldUi.Utils;
using Services.SceneLoadingService;
using Ui.LoadingUi;
using UnityEngine;
using Zenject;

namespace Splash
{
    public class SplashManager : MonoBehaviour
    {
        [Inject] private ISceneLoadingService _sceneLoadingService;
        [Inject] private SignalBus _signalBus;
        
        private void Start()
        {
            _signalBus.OpenWindow<LoadingWindow>(EWindowLayer.Project);
            
            _sceneLoadingService.LoadFromSplash(() =>
            {
                _signalBus.BackWindow(EWindowLayer.Project);
            });
        }
    }
}