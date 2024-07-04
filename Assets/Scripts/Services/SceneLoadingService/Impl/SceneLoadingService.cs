using Configs.SceneReferenceBase;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using Zenject;

namespace Services.SceneLoadingService.Impl
{
    public class SceneLoadingService : ISceneLoadingService, IInitializable
    {
        private readonly ISceneReferenceBase _sceneReferenceBase;

        private SceneInstance _loadedScene;

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
            var gameScene = Addressables.LoadSceneAsync(_sceneReferenceBase.MainScene);
            var levelScene = Addressables.LoadSceneAsync(_sceneReferenceBase.ScenesList[0], LoadSceneMode.Additive);

            await UniTask.WhenAll(gameScene.Task.AsUniTask(), levelScene.Task.AsUniTask());

            var resulScene = levelScene.Result;
            _loadedScene = resulScene;
            
            SceneManager.SetActiveScene(resulScene.Scene);
        }
        
        public async UniTask LoadScene(AssetReference scene, ReactiveCommand onLoadedSceneCommand = null)
        {
            var oldScene = Addressables.UnloadSceneAsync(_loadedScene);
            var newScene = Addressables.LoadSceneAsync(scene);
            
            await UniTask.WhenAll(oldScene.Task.AsUniTask(), newScene.Task.AsUniTask());
            
            var resulScene = oldScene.Result;
            _loadedScene = resulScene;
            
            SceneManager.SetActiveScene(resulScene.Scene);

            onLoadedSceneCommand?.Execute();
        }
    }
}