using System;
using UnityEngine;

namespace Dre0Dru.Values
{
    [Serializable]
    public class ValueChangeBuffer<T>
    {
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
            }
        }

        public T PreviousValue => _previousValue;

        public ValueChangeBuffer(T defaultValue = default)
        {
            Reset(defaultValue);
        }

        public void Reset(T defaultValue = default)
        {
            _currentValue = defaultValue;
            _previousValue = defaultValue;
        }

        public static implicit operator T(ValueChangeBuffer<T> valueChangeBuffer)
        {
            return valueChangeBuffer.CurrentValue;
        }
    }
}
