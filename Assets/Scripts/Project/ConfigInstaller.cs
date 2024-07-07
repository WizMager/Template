using Configs.SceneReferenceBase;
using Configs.SceneReferenceBase.Impl;
using UnityEngine;
using Zenject;

namespace Project
{
    [CreateAssetMenu(menuName = "Installer/" + nameof(ConfigInstaller), fileName = nameof(ConfigInstaller))]
    public class ConfigInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private SceneReferenceBase sceneReferenceBase;
        
        public override void InstallBindings()
        {
            Container.Bind<ISceneReferenceBase>().FromInstance(sceneReferenceBase).AsSingle();
        }
    }
}