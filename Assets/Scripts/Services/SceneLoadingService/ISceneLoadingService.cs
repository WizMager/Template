using System;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Services.SceneLoadingService
{
    public interface ISceneLoadingService
    {
        UniTask LoadFromSplash(Action onSceneLoaded = null);
        UniTask LoadScene(AssetReference scene, Action onSceneLoaded = null);
    }
}