using System;
using UnityEngine;

namespace Dre0Dru.Values
{
    [Serializable]
    public class ObservableValue<T>
    {
        public event Action<T> ValueChanged;
        
        [SerializeField]
        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                ValueChanged?.Invoke(_value);
            }
        }

        public ObservableValue() : this(default)
        {
            
        }

        public ObservableValue(T value)
        {
            _value = value;
        }

        public static implicit operator T(ObservableValue<T> observable) =>
            observable._value;
    }
}
