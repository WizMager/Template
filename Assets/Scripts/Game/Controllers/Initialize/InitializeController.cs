using Ai.BehaviorExtensions;
using Game.Bootstrap.Interfaces;
using Generator;
using Providers.GameFieldProvider;
using Services.InitializeService;
using UnityEngine;
using Zenject;

namespace Game.Controllers.Initialize
{
    [Install(EExecutionPriority.Urgent, 1)]
    public class InitializeController : IStartable
    {
        private readonly IGameFieldProvider _gameFieldProvider;
        private readonly IInitializeService _initializeService;
        private readonly DiContainer _container;

        public InitializeController
        (
            IGameFieldProvider gameFieldProvider, 
            IInitializeService initializeService,
            DiContainer container
        )
        {
            _gameFieldProvider = gameFieldProvider;
            _initializeService = initializeService;
            _container = container;
        }
        
        public void Start()
        {
            foreach (var view in _gameFieldProvider.GameField.AllViewInitializables)
            {
                _initializeService.Initialize(view);
            }
            
            foreach (var aiView in _gameFieldProvider.GameField.AllAiViewInitializables)
            {
                if (aiView.BehaviorTree == null)
                {
                    Debug.LogError("AiView has no linked behavior tree");
                    continue;
                }
                
                aiView.BehaviorTree.QueueAllTasksForInject(_container);
                aiView.BehaviorTree.EnableBehavior();
            }
        }
    }
}