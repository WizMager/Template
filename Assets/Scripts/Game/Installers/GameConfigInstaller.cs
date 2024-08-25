using UnityEngine;
using Zenject;

namespace Game.Installers
{
    [CreateAssetMenu(menuName = "Installer/" + nameof(GameConfigInstaller), fileName = nameof(GameConfigInstaller))]
    public class GameConfigInstaller: ScriptableObjectInstaller
    {
        //[SerializeField] private PrefabBase prefabBase;
        
        public override void InstallBindings()
        {
            //Container.Bind<IPrefabBase>().FromInstance(prefabBase).AsSingle();
        }
    }
}