using Game.Bootstrap.Interfaces;
using Generator;
using Providers.GameFieldProvider;
using Services.InitializeService;
using UnityEngine;

namespace Game.Controllers.Initialize
{
    [Install(EExecutionPriority.Urgent, 1)]
    public class InitializeController : IStartable
    {
        private readonly IGameFieldProvider _gameFieldProvider;
        private readonly IInitializeService _initializeService;
        
        public InitializeController(
            IGameFieldProvider gameFieldProvider, 
            IInitializeService initializeService
        )
        {
            _gameFieldProvider = gameFieldProvider;
            _initializeService = initializeService;
        }
        
        public void Start()
        {
            foreach (var go in _gameFieldProvider.GameField.TestObject)
            {
                Debug.Log(go.gameObject.transform.name);
                
                _initializeService.Initialize(go);
            }
            
            Debug.Log(_initializeService.ViewInitializables.Count);
        }
    }
}