using System;

namespace _Scirpts
{
    public class InputService: Zenject.IInitializable, IDisposable
    {
        private InputSystem_Actions _playerInput;
        public InputSystem_Actions PlayerInput => _playerInput;

        public void Initialize()
        {
            _playerInput = new InputSystem_Actions();
            
            _playerInput.Enable();
        }

        public void Dispose()
        {
            _playerInput.Disable();
        }
    }
}