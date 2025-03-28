using System;
using Sources.Infrastructure;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.BasicLogic.Building
{
    public class Building : MonoBehaviour
    {
        [SerializeField] private int _spawnAmount;
        [SerializeField] private float _spawnCooldown;
        [SerializeField] private ResourceType _resourceType;

        private float _passedTime;
        
        public event Action<int> AmountChanged;

        public int Amount { get; private set; }
        public ResourceType ResourceType => _resourceType;

        private void Update()
        {
            _passedTime += Time.deltaTime;

            if (_passedTime >= _spawnCooldown)
            {
                _passedTime = 0;
                Amount += _spawnAmount;
                AmountChanged?.Invoke(Amount);
            }
        }

        public void CollectResorces(ResourcesBank resourcesBank)
        {
            resourcesBank.GetCell(_resourceType).TryAdd(Amount);
            Amount = 0;
            AmountChanged?.Invoke(Amount);
        }
    }
}