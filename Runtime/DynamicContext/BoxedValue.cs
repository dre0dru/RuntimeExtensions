using System;
using UnityEngine;

namespace Dre0Dru.DynamicContext
{
    //TODO move to collections/values
    [Serializable]
    public class BoxedValue<TValue>
        where TValue : struct
    {
        [SerializeField]
        private TValue _value;

        //TODO as ref return?
        public TValue Value
        {
            get => _value;
            set => _value = value;
        }

        public BoxedValue(TValue value)
        {
            _value = value;
        }

        public static implicit operator TValue(BoxedValue<TValue> boxedValue)
        {
            return boxedValue._value;
        }

        public static implicit operator BoxedValue<TValue>(TValue value)
        {
            return new BoxedValue<TValue>(value);
        }
    }
}
