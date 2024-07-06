using Game.Bootstrap.Interfaces;
using Generator;
using UnityEngine;

namespace Test
{
    [Install(EExecutionPriority.Normal, 12)]
    public class TestController : IUpdatable
    {
        public void Update()
        {
            Debug.Log("TestSystem Update");
        }
    }
}