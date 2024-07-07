using System.Collections.Generic;
using Views;
using Zenject;

namespace Services.InitializeService.Impl
{
    public class InitializeService : IInitializeService
    {
        private readonly DiContainer _diContainer;

        public List<IViewInitializable> ViewInitializables { get; } = new ();

        public InitializeService(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void Initialize(IViewInitializable viewInitializable)
        {
            _diContainer.Inject(viewInitializable);
            
            viewInitializable.Initialize();
            
            ViewInitializables.Add(viewInitializable);
        }
    }
}