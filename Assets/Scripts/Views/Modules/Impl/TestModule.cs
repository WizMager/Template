using UniRx;
using UnityEngine;

namespace Views.Modules.Impl
{
    public class TestModule : AModule
    {
        public override void Initialize(AView view, CompositeDisposable disposable)
        {
            Debug.Log($"Initialize Module: {view.name}/{disposable.Count}  ");
        }
    }
}