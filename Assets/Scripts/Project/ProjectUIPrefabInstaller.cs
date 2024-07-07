using KoboldUi.Utils;
using Ui.LoadingUi;
using UnityEngine;
using Zenject;

namespace Project
{
    [CreateAssetMenu(menuName = "Installer/" + nameof(ProjectUIPrefabInstaller), fileName = nameof(ProjectUIPrefabInstaller))]
    public class ProjectUIPrefabInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private Canvas projectCanvas;

        [SerializeField] private LoadingWindow loadingWindow;
        
        public override void InstallBindings()
        {
            var canvasInstance = Container.InstantiatePrefabForComponent<Canvas>(projectCanvas);
            
            Container.BindWindowFromPrefab(canvasInstance, loadingWindow);
        }
    }
}