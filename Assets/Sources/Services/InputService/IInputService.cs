using System;
using UnityEngine;

namespace Sources.Services.InputService
{
    public interface IInputService
    {
        event Action<Vector2> Clicked;
    }
}