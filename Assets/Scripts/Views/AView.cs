using System.Collections.Generic;
using UnityEngine;
using Views.Modules;

namespace Views
{
    public abstract class AView : MonoBehaviour, IViewInitializable 
    {
        [SerializeField] protected List<AModule> modules = new ();
        
        public virtual void Initialize()
        {
            foreach (var module in modules)
            {
                module.Initialize();
            }
        }
    }
}