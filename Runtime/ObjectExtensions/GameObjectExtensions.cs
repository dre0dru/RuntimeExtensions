using System;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace Dre0Dru.ObjectExtensions
{
    public static class GameObjectExtensions
    {
        public static T GetOrAddComponent<T>(this GameObject gameObject)
            where T : Component
        {
            if (!gameObject.TryGetComponent<T>(out var component))
            {
                component = gameObject.AddComponent<T>();
            }

            return component;
        }
        
        public static bool RemoveComponent<T>(this GameObject gameObject)
            where T : Component
        {
            if (gameObject.TryGetComponent<T>(out var result))
            {
                Object.Destroy(result);

                return true;
            }

            return false;
        }

        public static void ExecuteDownwards<TComponent>(this GameObject root, Action<TComponent> action,
            bool includeInactive = false)
            where TComponent : Component
        {
            using (ListPool<TComponent>.Get(out var list))
            {
                root.GetComponentsInChildren<TComponent>(includeInactive, list);
                foreach (var component in list)
                {
                    action(component);
                }
            }
        }
        
        public static void ExecuteUpwards<TComponent>(this GameObject root, Action<TComponent> action,
            bool includeInactive = false)
            where TComponent : Component
        {
            using (ListPool<TComponent>.Get(out var list))
            {
                root.GetComponentsInParent<TComponent>(includeInactive, list);
                foreach (var component in list)
                {
                    action(component);
                }
            }
        }
    }
}
