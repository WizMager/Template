using System.Collections.Generic;
using System.Linq;
using Alchemy.Inspector;
using UnityEngine;
using Views;
using Views.Impl;

namespace Utils
{
    public class GameField : MonoBehaviour
    {
        [SerializeField] private List<AAiView> aiViews;
        [SerializeField] private List<AView> testObject;
        
        public IViewInitializable[] AllViewInitializables
        {
            get
            {
                var list = new List<IViewInitializable>();
                list.AddRange(testObject);

                return list.ToArray();
            }
        }
        
        public IAi[] AllAiViewInitializables
        {
            get
            {
                var list = new List<IAi>();
                
                list.AddRange(aiViews);

                return list.ToArray();
            }
        }
        
        [Button]
        public virtual void AutoFill()
        {
            ClearAllFields();

            testObject = new List<AView>(FindObjectsOfType<AView>().Where(view => view is not AAiView));

            aiViews = new List<AAiView>(FindObjectsOfType<AAiView>().ToArray());
            
            Debug.Log("Autofill Complete");
        }

        private void ClearAllFields()
        {
            testObject = null;
        }
    }
}