using KoboldUi.Windows;
using UnityEngine;

namespace Ui.LoadingUi
{
    public class LoadingWindow : AWindow
    {
        [SerializeField] private LoadingView loadingView;
        
        protected override void AddControllers()
        {
            AddController<LoadingController, LoadingView>(loadingView);
        }
    }
}