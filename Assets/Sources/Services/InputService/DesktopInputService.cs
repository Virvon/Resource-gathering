using System;
using UnityEngine;
using Zenject;

namespace Sources.Services.InputService
{
    public class DesktopInputService : ITickable, IInputService
    {
        public event Action<Vector2> Clicked;
        
        public void Tick()
        {
            if(Input.GetMouseButtonUp(0))
                Clicked?.Invoke(Input.mousePosition);
        }
    }
}