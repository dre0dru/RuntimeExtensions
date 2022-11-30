using System;
using UnityEngine;

namespace Dre0Dru.DynamicContext
{
    [Serializable]
    public class DynamicValue<TActual> : IDynamicValue
        where TActual : class
    {
        public static DynamicValue<TActual> New(TActual value) =>
            new DynamicValue<TActual>()
            {
                _value = value
            };

        [SerializeField]
        private TActual _value;

        public TValue GetValue<TValue>()
            where TValue : class =>
            _value as TValue;

        public void SetValue<TValue>(TValue value)
            where TValue : class =>
            _value = value as TActual;

        public static implicit operator TActual(DynamicValue<TActual> value) =>
            value._value;

        public static implicit operator DynamicValue<TActual>(TActual value) =>
            New(value);
    }
}
