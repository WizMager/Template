using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Views.Modules;

namespace Views
{
    public abstract class AView : MonoBehaviour, IViewInitializable, IDisposable 
    {
        [SerializeField] protected List<AModule> modules = new ();

        private readonly CompositeDisposable _disposable = new ();
        
        public virtual void Initialize()
        {
            foreach (var module in modules)
            {
                module.Initialize(this, _disposable);
            }
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}