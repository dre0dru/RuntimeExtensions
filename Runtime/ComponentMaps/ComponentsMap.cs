using Dre0Dru.Collections;
using UnityEngine;

namespace Dre0Dru.ComponentMaps
{
    public class ComponentsMap<TKey, TComponent> : UDictionaryMono<TKey, TComponent>
        where TComponent : Component
    {
    
    }
}
