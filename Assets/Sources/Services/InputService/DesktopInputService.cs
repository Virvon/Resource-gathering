using System;
using UnityEngine;
using Zenject;

namespace Sources.Services.InputService
{
    public class DesktopInputService : ITickable, IInputService
    {
        private bool _isActive = true;
        
        public event Action<Vector2> Clicked;
        
        public void SetActive(bool isActive) =>
            _isActive = isActive;

        public void Tick()
        {
            if (_isActive == false)
                return;
            
            if(Input.GetMouseButtonUp(0) && _isActive)
                Clicked?.Invoke(Input.mousePosition);
        }
    }
}