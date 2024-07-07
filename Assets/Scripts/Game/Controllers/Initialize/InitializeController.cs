using Game.Bootstrap.Interfaces;
using Generator;
using Providers.GameFieldProvider;
using Services.InitializeService;

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
            foreach (var view in _gameFieldProvider.GameField.AllViewInitializables)
            {
                _initializeService.Initialize(view);
            }
        }
    }
}