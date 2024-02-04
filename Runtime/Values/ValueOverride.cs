using System;
using UnityEngine;

namespace Dre0Dru.Values
{
    //TODO overrides queue/stack? with IDisposable for overrides release?
    //TODO move to collections?
    [Serializable]
    public class ValueOverride<T>
    {
        public event Action<T> ValueChanged;

        [SerializeField]
        private T _value;

        [SerializeField]
        private T _override;

        [SerializeField]
        private bool _hasOverride;

        public T Value => _hasOverride ? _override : _value;

        public bool HasOverride => _hasOverride;

        public T DefaultValue
        {
            get => _value;
            set
            {
                _value = value;

                if (!HasOverride)
                {
                    ValueChanged?.Invoke(_value);
                }
            }
        }

        public T OverrideValue
        {
            get => _override;
            set
            {
                _override = value;
                _hasOverride = true;

                ValueChanged?.Invoke(_override);
            }
        }

        public ValueOverride(T value)
        {
            _value = value;
        }

        public void ClearOverride()
        {
            _override = default;
            _hasOverride = false;
            ValueChanged?.Invoke(_value);
        }

        public static implicit operator T(ValueOverride<T> valueOverride)
        {
            return valueOverride.Value;
        }
    }
}
