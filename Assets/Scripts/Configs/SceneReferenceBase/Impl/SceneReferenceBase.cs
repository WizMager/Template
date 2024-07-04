using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Configs.SceneReferenceBase.Impl
{
    [CreateAssetMenu(menuName = "Configs/" + nameof(SceneReferenceBase), fileName = nameof(SceneReferenceBase))]
    public class SceneReferenceBase : ScriptableObject, ISceneReferenceBase
    {
        [SerializeField] private AssetReference mainScene;
        [SerializeField] private List<AssetReference> scenesList;

        public List<AssetReference> ScenesList
        {
            get
            {
                Debug.Log(scenesList.Count);
                Debug.Log(scenesList[0]);
                return scenesList;
            }
        }

        public AssetReference MainScene => mainScene;
    }
}