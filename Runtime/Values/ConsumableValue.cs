using System;
using UnityEngine;

namespace Dre0Dru.Values
{
    [Serializable]
    public struct ConsumableValue<T>
    {
        [SerializeField]
        private T _value;

        [SerializeField]
        private bool _isConsumed;

        public T Value
        {
            readonly get => _value;
            set
            {
                _value = value;
                _isConsumed = false;
            }
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
