using System.Collections.Generic;
using Alchemy.Inspector;
using UnityEngine;
using Views;
using Views.Impl;

namespace Utils
{
    public class GameField : MonoBehaviour
    {
        [SerializeField] private AAiView[] aiViews;
        [SerializeField] private AView[] testObject;
        
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

            testObject = FindObjectsOfType<AView>();

            aiViews = FindObjectsOfType<AAiView>();
            
            Debug.Log("Autofill Complete");
        }

        private void ClearAllFields()
        {
            testObject = null;
        }
    }
}