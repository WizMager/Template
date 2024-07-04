using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine.AddressableAssets;

namespace Services.SceneLoadingService
{
    public interface ISceneLoadingService
    {
        UniTask LoadScene(AssetReference scene, ReactiveCommand onLoadedSceneCommand = null);
    }
}