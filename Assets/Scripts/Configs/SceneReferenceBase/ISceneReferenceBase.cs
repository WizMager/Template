using System.Collections.Generic;
using UnityEngine.AddressableAssets;

namespace Configs.SceneReferenceBase
{
    public interface ISceneReferenceBase
    {
        AssetReference MainScene { get; }
        List<AssetReference> ScenesList { get; }
    }
}