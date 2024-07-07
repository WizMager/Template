using UnityEngine;
using Views;

namespace Utils
{
    public class GameField : MonoBehaviour
    {
        [SerializeField] private AView[] testObject;

        public AView[] TestObject => testObject;
    }
}