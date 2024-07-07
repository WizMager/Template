using UniRx;
using UnityEngine;

namespace Views.Modules
{
    public abstract class AModule : MonoBehaviour
    {
        public virtual void Initialize(AView view, CompositeDisposable disposable)
        {
        }
    }
}