using System.Collections.Generic;
using UnityEngine;
using Views.Modules;

namespace Views
{
    public abstract class AView : MonoBehaviour 
    {
        [SerializeField] protected List<AModule> modules = new ();
    }
}