using System;
using System.Collections.Generic;
using Dre0Dru.Collections;
using UnityEngine;
using UnityEngine.Scripting;

namespace Dre0Dru.DynamicContext
{
    [Serializable]
    public class DynamicContext<TKey, TKvp> : IDynamicContext<TKey>
        where TKvp : IKvp<TKey, IDynamicValue>, new()
    {
        [SerializeField]
        private UDictionary<TKey, IDynamicValue, TKvp> _values;

        [RequiredMember]
        public DynamicContext()
        {
            _values = new UDictionary<TKey, IDynamicValue, TKvp>();
        }

        public DynamicContext(IDictionary<TKey, IDynamicValue> values)
        {
            _values = new UDictionary<TKey, IDynamicValue, TKvp>(values);
        }

        public void AddValue<TValue>(TKey key, TValue value)
            where TValue : class =>
            _values[key] = DynamicValue<TValue>.New(value);

        public void SetValue<TValue>(TKey key, TValue value)
            where TValue : class =>
            _values[key].SetValue(value);

        public TValue GetValue<TValue>(TKey key)
            where TValue : class =>
            _values[key].GetValue<TValue>();

        public bool HasValue<TValue>(TKey key)
            where TValue : class =>
            TryGetValue<TValue>(key, out _);

        public bool TryGetValue<TValue>(TKey key, out TValue value)
            where TValue : class
        {
            if (_values.TryGetValue(key, out var dynamicValue))
            {
                value = dynamicValue.GetValue<TValue>();
                return value != null;
            }

            value = default;
            return false;
        }

        public bool RemoveValue(TKey key) =>
            _values.Remove(key);
    }

    #if SER_REF_SELECTOR_SUPPORT

    [Serializable]
    public class DynamicContext<TKey> : DynamicContext<TKey, DynamicValueKvp<TKey>>
    {
    }
    
    #endif
}
