using System;
using Configs.SceneReferenceBase;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Services.SceneLoadingService.Impl
{
    public class SceneLoadingService : ISceneLoadingService
    {
        private readonly ISceneReferenceBase _sceneReferenceBase;

        private SceneInstance _loadedScene;

        public SceneLoadingService(ISceneReferenceBase sceneReferenceBase)
        {
            _sceneReferenceBase = sceneReferenceBase;
        }
        
        public async UniTask LoadFromSplash(Action onSceneLoaded = null)
        {
            var levelScene = Addressables.LoadSceneAsync(_sceneReferenceBase.ScenesList[0]);
            
            await levelScene.Task.AsUniTask();
            
            var gameScene = Addressables.LoadSceneAsync(_sceneReferenceBase.MainScene, LoadSceneMode.Additive);
            
            await gameScene.Task.AsUniTask();

            var resulScene = levelScene.Result;
            _loadedScene = resulScene;
            
            SceneManager.SetActiveScene(resulScene.Scene);
            
            onSceneLoaded?.Invoke();
        }
        
        public async UniTask LoadScene(AssetReference scene, Action onSceneLoaded = null)
        {
            var oldScene = Addressables.UnloadSceneAsync(_loadedScene);
            var newScene = Addressables.LoadSceneAsync(scene);
            
            await UniTask.WhenAll(oldScene.Task.AsUniTask(), newScene.Task.AsUniTask());
            
            var resulScene = oldScene.Result;
            _loadedScene = resulScene;
            
            SceneManager.SetActiveScene(resulScene.Scene);

            onSceneLoaded?.Invoke();
        }
    }
}