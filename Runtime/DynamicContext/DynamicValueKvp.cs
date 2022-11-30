#if SER_REF_SELECTOR_SUPPORT

using System;
using Dre0Dru.Collections;
using UnityEngine;

namespace Dre0Dru.DynamicContext
{
    [Serializable]
    public struct DynamicValueKvp<TKey> : IKvp<TKey, IDynamicValue>, IEquatable<DynamicValueKvp<TKey>>
    {
        [SerializeField]
        private TKey _key;

        [SerializeReference, SubclassSelector]
        private IDynamicValue _value;

        public TKey Key
        {
            get => _key;
            set => _key = value;
        }

        public IDynamicValue Value
        {
            get => _value;
            set => _value = value;
        }

        public bool Equals(DynamicValueKvp<TKey> other)
        {
            return Equals(_key, other._key) && Equals(_value, other._value);
        }

        public override bool Equals(object obj)
        {
            return obj is DynamicValueKvp<TKey> other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_key, _value);
        }
    }
}

#endif
