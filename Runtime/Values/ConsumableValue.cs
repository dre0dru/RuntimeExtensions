using System;
using UnityEngine;

namespace Dre0Dru.Values
{
    public interface IConsumableValue<T>
    {
        T Value { get; set; }
        
        bool IsConsumed { get; set; }
    }
    
    [Serializable]
    public struct ConsumableValue<T> : IConsumableValue<T>
    {
        [SerializeField]
        private T _value;

        [SerializeField]
        private bool _isConsumed;

        public T Value
        {
            readonly get => _value;
            set => _value = value;
        }

        public bool IsConsumed
        {
            readonly get => _isConsumed;
            set => _isConsumed = value;
        }

        public ConsumableValue(T value) : this()
        {
            Value = value;
            _isConsumed = false;
        }

        public static implicit operator T(ConsumableValue<T> consumableValue)
        {
            return consumableValue.Value;
        }

        public static implicit operator ConsumableValue<T>(T value)
        {
            return new ConsumableValue<T>();
        }
    }
}
