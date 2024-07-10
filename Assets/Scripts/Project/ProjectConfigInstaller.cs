using Configs.SceneReferenceBase;
using Configs.SceneReferenceBase.Impl;
using UnityEngine;
using Zenject;

namespace Project
{
    [CreateAssetMenu(menuName = "Installer/" + nameof(ProjectConfigInstaller), fileName = nameof(ProjectConfigInstaller))]
    public class ProjectConfigInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private SceneReferenceBase sceneReferenceBase;
        
        public override void InstallBindings()
        {
            Container.Bind<ISceneReferenceBase>().FromInstance(sceneReferenceBase).AsSingle();
        }
    }
}