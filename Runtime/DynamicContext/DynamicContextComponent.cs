using Dre0Dru.Collections;
using UnityEngine;

namespace Dre0Dru.DynamicContext
{
    public class DynamicContextComponent<TKey, TKvp> : MonoBehaviour, IDynamicContext<TKey>
        where TKvp : IKvp<TKey, IDynamicValue>, new()
    {
        [SerializeField]
        private DynamicContext<TKey, TKvp> _context;

        public void AddValue<TValue>(TKey key, TValue value)
            where TValue : class =>
            _context.AddValue(key, value);

        public void SetValue<TValue>(TKey key, TValue value)
            where TValue : class =>
            _context.SetValue(key, value);

        public TValue GetValue<TValue>(TKey key)
            where TValue : class =>
            _context.GetValue<TValue>(key);

        public bool HasValue<TValue>(TKey key)
            where TValue : class =>
            _context.HasValue<TValue>(key);

        public bool TryGetValue<TValue>(TKey key, out TValue value)
            where TValue : class =>
            _context.TryGetValue(key, out value);

        public bool RemoveValue(TKey key) =>
            _context.RemoveValue(key);
    }

    #if SER_REF_SELECTOR_SUPPORT

    public class DynamicContextComponent<TKey> : DynamicContextComponent<TKey, DynamicValueKvp<TKey>>
    {
        
    }
    
    #endif
}
