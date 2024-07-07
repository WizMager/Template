using System.Collections.Generic;
using Views;

namespace Services.InitializeService
{
    public interface IInitializeService
    {
        List<IViewInitializable> ViewInitializables { get; }
        
        void Initialize(IViewInitializable viewInitializable);
    }
}