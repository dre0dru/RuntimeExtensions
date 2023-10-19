using System;
using UnityEngine;

namespace Dre0Dru.Values
{
    [Serializable]
    public class BoxedValue<TValue>
        where TValue : struct
    {
        [SerializeField]
        private TValue _value;

        public TValue Value
        {
            get => _value;
            set => _value = value;
        }

        public BoxedValue() : this(default)
        {
            
        }
        
        public BoxedValue(TValue value)
        {
            _value = value;
        }

        public static implicit operator TValue(BoxedValue<TValue> boxedValue)
        {
            return boxedValue._value;
        }
    }
}
