using System;

namespace Services.InputService.Impl
{
    public class InputService : IInputService, IDisposable
    {
        private readonly InputActions _inputActions;
        
        public InputService()
        {
            _inputActions = new InputActions();
            _inputActions.Enable();
        }


        public void Dispose()
        {
            _inputActions.Disable();
        }
    }
}