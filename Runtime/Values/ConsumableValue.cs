using System;
using UnityEngine;

namespace Dre0Dru.Values
{
    [Serializable]
    public class ConsumableValue<T>
    {
        [SerializeField]
        private T _value;

        [SerializeField]
        private bool _isConsumed;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                _isConsumed = false;
            }
        }

        public bool IsConsumed
        {
            get => _isConsumed;
            set => _isConsumed = value;
        }

        public ConsumableValue() : this(default)
        {
            
        }

        public ConsumableValue(T value)
        {
            _value = value;
        }

        public static implicit operator T(ConsumableValue<T> consumableValue)
        {
            return consumableValue.Value;
        }
    }
}
