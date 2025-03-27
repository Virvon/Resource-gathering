using UnityEngine;
using Zenject;

namespace Sources.Services.AssetMenagement
{
    public class KeyPrefabFactory<TComponent> : IFactory<string, TComponent>
    {
        private readonly IInstantiator _instantiator;

        public KeyPrefabFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public TComponent Create(string path)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            GameObject newObject = _instantiator.InstantiatePrefab(prefab);

            return newObject.GetComponent<TComponent>();
        }
    }
}