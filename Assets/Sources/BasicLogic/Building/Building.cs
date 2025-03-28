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
        private int _amount;
        
        public event Action<int> AmountChanged;

        public ResourceType ResourceType => _resourceType;

        private void Update()
        {
            _passedTime += Time.deltaTime;

            if (_passedTime >= _spawnCooldown)
            {
                _passedTime = 0;
                _amount += _spawnAmount;
                AmountChanged?.Invoke(_amount);
            }
        }

        public void CollectResorces(ResourcesBank resourcesBank)
        {
            resourcesBank.GetCell(_resourceType).TryAdd(_amount);
            _amount = 0;
            AmountChanged?.Invoke(_amount);
        }
    }
}