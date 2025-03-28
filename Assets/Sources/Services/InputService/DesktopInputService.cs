using System;
using UnityEngine;
using Zenject;

namespace Sources.Services.InputService
{
    public class DesktopInputService : ITickable, IInputService
    {
        private bool _isActive = true;
        private bool _isClickStarted = false;
        private bool _isDragged;

        private Vector3 _clickStartPosition;
        
        public event Action<Vector2> Clicked;
        public event Action<Vector2> Dragged;
        public event Action<Vector2> ClickStarted; 
        
        public void SetActive(bool isActive) =>
            _isActive = isActive;

        public void Tick()
        {
            if (_isActive == false)
                return;

            if (Input.GetMouseButtonDown(0))
            {
                _clickStartPosition = Input.mousePosition;
                _isClickStarted = true;
                ClickStarted?.Invoke(_clickStartPosition);
            }

            if (Input.GetMouseButton(0) && _isClickStarted)
                Dragged?.Invoke(Input.mousePosition);

            if (Input.GetMouseButtonUp(0) && _clickStartPosition == Input.mousePosition)
            {
                Clicked?.Invoke(Input.mousePosition);
                _isClickStarted = false;
            }
        }
    }
}