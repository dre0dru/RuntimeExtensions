using System;
using UnityEngine;

namespace Dre0Dru.Values
{
    //TODO очередь оверрайдов? с IDisposable для релиза оверрайда?
    [Serializable]
    public class ValueOverride<T>
    {
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
            set => _value = value;
        }

        public T OverrideValue
        {
            get => _override;
            set
            {
                _override = value;
                _hasOverride = true;
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
        }

        public static implicit operator T(ValueOverride<T> valueOverride)
        {
            return valueOverride.Value;
        }
    }
}
