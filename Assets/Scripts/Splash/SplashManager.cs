using Services.SceneLoadingService;
using UnityEngine;
using Zenject;

namespace Splash
{
    public class SplashManager : MonoBehaviour
    {
        [Inject] private ISceneLoadingService _sceneLoadingService;
        
        private void Start()
        {
            //TODO: open loadingWindow
            _sceneLoadingService.LoadFromSplash(() =>
            {
                //TODO: close loadingWindow
            });
        }
    }
}