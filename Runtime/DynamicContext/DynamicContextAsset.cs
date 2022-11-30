using Dre0Dru.Collections;
using UnityEngine;

namespace Dre0Dru.DynamicContext
{
    public class DynamicContextAsset<TKey, TKvp> : ScriptableObject
        where TKvp : IKvp<TKey, IDynamicValue>, new()
    {
        [SerializeField]
        private DynamicContext<TKey, TKvp> _context;
    }
    
    #if SER_REF_SELECTOR_SUPPORT

    public class DynamicContextAsset<TKey> : DynamicContextAsset<TKey, DynamicValueKvp<TKey>>
    {
        
    }
    
    #endif
}
