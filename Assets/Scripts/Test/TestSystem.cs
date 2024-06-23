using Game.Bootstrap.Interfaces;
using Generator;
using UnityEngine;

namespace Test
{
    [Install(EExecutionPriority.Normal, 12)]
    public class TestSystem : IUpdatable
    {
        public void Update()
        {
            Debug.Log("TestSystem Update");
        }
    }
}