using System.Collections.Generic;
using Game.Bootstrap.Interfaces;
using Zenject;
using IInitializable = Zenject.IInitializable;

namespace Game.Bootstrap
{
    public class Bootstrap : IInitializable, ITickable, IFixedTickable, ILateTickable
    {
        private readonly List<IStartable> _startables = new ();
        private readonly List<IUpdatable> _updatables = new();
        private readonly List<IFixedUpdatable> _fixedUpdatables = new();
        private readonly List<ILateUpdatable> _lateUpdatables = new();

        public Bootstrap(List<IController> controllers)
        {
            foreach (var controller in controllers)
            {
                if (controller is IStartable startable)
                {
                    _startables.Add(startable);
                }
                
                if (controller is IUpdatable updatable)
                {
                    _updatables.Add(updatable);
                }
                
                if (controller is IFixedUpdatable fixedUpdatable)
                {
                    _fixedUpdatables.Add(fixedUpdatable);
                }
                
                if (controller is ILateUpdatable lateUpdatable)
                {
                    _lateUpdatables.Add(lateUpdatable);
                }
            }
        }
        
        public void Initialize()
        {
            foreach (var startable in _startables)
            {
                startable.Start();
            }
        }
        
        public void Tick()
        {
            
            foreach (var updatable in _updatables)
            {
                updatable.Update();
            }
        }
        
        public void FixedTick()
        {
            foreach (var fixedUpdatable in _fixedUpdatables)
            {
                fixedUpdatable.FixedUpdate();
            }
        }
        
        public void LateTick()
        {
            foreach (var lateUpdatable in _lateUpdatables)
            {
                lateUpdatable.LateUpdate();
            }
        }
    }
}