using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Splash
{
    public class SplashManager : MonoBehaviour
    {
        private void Start()
        {
            Addressables.LoadSceneAsync("Assets/Scenes/Game.unity");
        }
    }
}