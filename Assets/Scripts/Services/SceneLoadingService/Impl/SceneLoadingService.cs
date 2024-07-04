using Configs.SceneReferenceBase;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using Zenject;

namespace Services.SceneLoadingService.Impl
{
    public class SceneLoadingService : ISceneLoadingService, IInitializable
    {
        private readonly ISceneReferenceBase _sceneReferenceBase;

        public SceneLoadingService(ISceneReferenceBase sceneReferenceBase)
        {
            _sceneReferenceBase = sceneReferenceBase;
        }

        public async void Initialize()
        {
            await LoadFromSplash();
        }
        
        private async UniTask LoadFromSplash()
        {
            var gameScene = Addressables.LoadSceneAsync(_sceneReferenceBase.MainScene, LoadSceneMode.Additive);
            //var levelScene = Addressables.LoadSceneAsync(_sceneReferenceBase.ScenesList[0], LoadSceneMode.Additive);

            //await UniTask.WhenAll(gameScene.Task.AsUniTask(), levelScene.Task.AsUniTask());

            //SceneManager.SetActiveScene(levelScene.Result.Scene);
        }
        
        public void LoadScene(AssetReference scene)
        {
            
        }

        public void UnLoadScene(AssetReference scene)
        {
            
        }
    }
}