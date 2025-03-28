using System;
using UnityEngine;
using Zenject;

namespace Sources.Services.InputService
{
    public class MobileInputService : IInputService, ITickable
    {
        private bool _isActive = true;
        private bool _isClickStarted = false;
        private bool _isDragged;

        private Vector2 _clickStartPosition;
        
        public event Action<Vector2> Clicked;
        public event Action<Vector2> Dragged;
        public event Action<Vector2> ClickStarted; 
        
        public void SetActive(bool isActive)
        {
            _isActive = isActive;

            if (_isActive == false)
                _isClickStarted = false;
        }

        public void Tick()
        {
            if (_isActive == false || Input.touchCount == 0)
                return;

            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _clickStartPosition = touch.position;
                _isClickStarted = true;
                ClickStarted?.Invoke(_clickStartPosition);
            }

            if (touch.phase == TouchPhase.Moved && _isClickStarted)
                Dragged?.Invoke(Input.mousePosition);

            if (touch.phase == TouchPhase.Ended && _clickStartPosition == touch.position)
            {
                Clicked?.Invoke(Input.mousePosition);
                _isClickStarted = false;
            }
        }
    }
}