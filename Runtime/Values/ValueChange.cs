using System;
using UnityEngine;

namespace Dre0Dru.Values
{
    [Serializable]
    public class ValueChange<T>
    {
        public event Action<T, T> ValueChanged;

        [SerializeField]
        private T _currentValue;

        [SerializeField]
        private T _previousValue;

        public T CurrentValue
        {
            get => _currentValue;
            set
            {
                _previousValue = _currentValue;
                _currentValue = value;

                ValueChanged?.Invoke(_currentValue, _previousValue);
            }
        }

        public T PreviousValue => _previousValue;

        public ValueChange(T defaultValue = default)
        {
            Reset(defaultValue);
        }

        public void Reset(T defaultValue = default)
        {
            _currentValue = defaultValue;
            _previousValue = defaultValue;
        }

        public static implicit operator T(ValueChange<T> valueChange)
        {
            return valueChange.CurrentValue;
        }
    }
}
