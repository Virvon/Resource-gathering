using System;
using UnityEngine;

namespace Sources.Infrastructure
{
    [Serializable]
    public class ResourceCell
    {
        [SerializeField] string _name;
        [SerializeField] private ResourceType _type;
        [SerializeField]private int _amount;

        public ResourceCell(ResourceType type, int amount)
        {
            _type = type;
            _amount = amount;
        }
        
        public event Action OnStateChanged;
        public event Action<int> OnAmountChanged;
        
        public ResourceType Type => _type;
        public int Amount => _amount;
        public string Name => _name;
        
        public bool TryAdd(int amount)
        {
            if(amount < 0)
                return false;
            
            _amount += amount;
            OnAmountChanged?.Invoke(_amount);
            OnStateChanged?.Invoke();
            return true;
        }
        
        public bool TryGet(int amount)
        {
            if (amount <= 0 || _amount < amount)
                return false;

            _amount -= amount;
            OnAmountChanged?.Invoke(_amount);
            OnStateChanged?.Invoke();
            return true;
        }
        
        public void Change(int amount)
        {
            if(_amount != amount)
            {
                _amount = amount;
                OnAmountChanged?.Invoke(_amount);
                OnStateChanged?.Invoke();
            }
        }
    }
}