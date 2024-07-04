using UnityEngine.AddressableAssets;

namespace Services.SceneLoadingService
{
    public interface ISceneLoadingService
    {
        void LoadScene(AssetReference scene);
        void UnLoadScene(AssetReference scene);
    }
}