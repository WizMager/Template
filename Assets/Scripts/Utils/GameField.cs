using System.Collections.Generic;
using Alchemy.Inspector;
using UnityEngine;
using Views;

namespace Utils
{
    public class GameField : MonoBehaviour
    {
        [SerializeField] private AView[] testObject;

        public AView[] TestObject => testObject;

        public IViewInitializable[] AllViewInitializables
        {
            get
            {
                var list = new List<IViewInitializable>();
                list.AddRange(testObject);

                return list.ToArray();
            }
        }
        
        [Button]
        public virtual void AutoFill()
        {
            ClearAllFields();

            testObject = FindObjectsOfType<AView>();
            
            Debug.Log("Autofill Complete");
        }

        private void ClearAllFields()
        {
            testObject = null;
        }
    }
}