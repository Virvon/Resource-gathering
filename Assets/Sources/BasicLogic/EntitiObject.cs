using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sources.BasicLogic
{
    public class EntitiObject : MonoBehaviour
    {
        private readonly Dictionary<Type, object> _components = new();

        public TComponent Get<TComponent>()
            where TComponent : class
        {
            Type type = typeof(TComponent);

            if (_components.TryGetValue(type, out object component) == false)
                throw new NullReferenceException();

            return component as TComponent;
        }

        public void Add<TComponent>(TComponent component)
        {
            if (_components.TryAdd(typeof(TComponent), component) == false)
                throw new ArgumentException($"The component of type {typeof(TComponent)} is already registered");
        }
    }
}