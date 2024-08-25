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

        public bool TryGetModule<T>(out T findModule) where T : AModule
        {
            findModule = null;
            
            foreach (var module in modules)
            {
                if (module is T needModule)
                {
                    findModule = needModule;
                }
            }

            Debug.Log($"[{name}]: Does not have module with type {typeof(T)}");
            
            return false;
        }
        
        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}