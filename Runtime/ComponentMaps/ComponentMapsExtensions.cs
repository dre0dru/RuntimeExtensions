using UnityEngine;

namespace Dre0Dru.ComponentMaps
{
    public static class ComponentMapsExtensions
    {
        public static bool TryGetComponentFromMap<TKey, TComponent>(this GameObject gameObject, 
            TKey key, out TComponent component)
            where TComponent : Component
        {
            if (gameObject.TryGetComponent<ComponentsMap<TKey, TComponent>>(out var componentsMap))
            {
                return componentsMap.TryGetValue(key, out component);
            }

            component = null;
            return false;
        }
    }
}