using System;
using UnityEngine;

namespace Dre0Dru.Values
{
    [Serializable]
    public class ReferenceValue<TValue>
    {
        [SerializeField]
        private TValue _value;

        public TValue Value
        {
            get => _value;
            set => _value = value;
        }

        public ReferenceValue() : this(default)
        {
            
        }
        
        public ReferenceValue(TValue value)
        {
            _value = value;
        }

        public static implicit operator TValue(ReferenceValue<TValue> referenceValue)
        {
            return referenceValue._value;
        }
    }
}
