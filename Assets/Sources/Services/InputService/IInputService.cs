using System;
using UnityEngine;

namespace Sources.Services.InputService
{
    public interface IInputService
    {
        event Action<Vector2> Clicked;
        event Action<Vector2> Dragged;
        event Action<Vector2> ClickStarted; 
            
        void SetActive(bool isActive);
    }
}