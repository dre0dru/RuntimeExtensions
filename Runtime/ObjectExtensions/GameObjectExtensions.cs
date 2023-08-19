using System;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace Dre0Dru.ObjectExtensions
{
    public static class GameObjectExtensions
    {
        public static TComponent GetOrAddComponent<TComponent>(this GameObject gameObject)
            where TComponent : Component
        {
            if (!gameObject.TryGetComponent<TComponent>(out var component))
            {
                component = gameObject.AddComponent<TComponent>();
            }

            return component;
        }

        public static bool RemoveComponent<TComponent>(this GameObject gameObject)
            where TComponent : Component
        {
            if (gameObject.TryGetComponent<TComponent>(out var result))
            {
                result.Remove();

                return true;
            }

            return false;
        }

        public static bool TryGetComponentInParent<TComponent>(this GameObject gameObject, out TComponent component, bool includeInactive = false)
            where TComponent : Component
        {
            component = gameObject.GetComponentInParent<TComponent>(includeInactive);
            return component != null;
        }
        
        public static bool TryGetComponentInChildren<TComponent>(this GameObject gameObject, out TComponent component, bool includeInactive = false)
            where TComponent : Component
        {
            component = gameObject.GetComponentInChildren<TComponent>(includeInactive);
            return component != null;
        }

        public static bool TryFindComponent<TComponent>(this GameObject gameObject, out TComponent component,
            bool includeInactive = false)
            where TComponent : Component
        {
            return gameObject.TryGetComponent<TComponent>(out component) ||
                   gameObject.TryGetComponentInChildren<TComponent>(out component, includeInactive) ||
                   gameObject.TryGetComponentInParent<TComponent>(out component, includeInactive);
        }

        public static bool RemoveSingle<T>(this GameObject gameObject)
            where T : class
        {
            if (gameObject.TryGetComponent<T>(out var result) &&
                result is Component component)
            {
                component.Remove();

                return true;
            }

            return false;
        }

        public static void RemoveAllInChildren<T>(this GameObject gameObject, bool includeInactive = false)
            where T : class
        {
            using (ListPool<T>.Get(out var list))
            {
                gameObject.GetComponentsInChildren<T>(includeInactive, list);
                foreach (var result in list)
                {
                    if (result is Component component)
                    {
                        component.Remove();
                    }
                }
            }
        }

        public static void ExecuteForComponentsInChildren<TComponent>(this GameObject gameObject,
            Action<TComponent> action,
            bool includeInactive = false)
            where TComponent : Component
        {
            using (ListPool<TComponent>.Get(out var list))
            {
                gameObject.GetComponentsInChildren<TComponent>(includeInactive, list);
                foreach (var component in list)
                {
                    action(component);
                }
            }
        }

        public static void ExecuteForAllInChildren<T>(this GameObject gameObject, Action<T> action,
            bool includeInactive = false)
            where T : class
        {
            using (ListPool<T>.Get(out var list))
            {
                gameObject.GetComponentsInChildren<T>(includeInactive, list);
                foreach (var component in list)
                {
                    action(component);
                }
            }
        }

        public static void ExecuteForComponentsInParent<TComponent>(this GameObject gameObject,
            Action<TComponent> action,
            bool includeInactive = false)
            where TComponent : Component
        {
            using (ListPool<TComponent>.Get(out var list))
            {
                gameObject.GetComponentsInParent<TComponent>(includeInactive, list);
                foreach (var component in list)
                {
                    action(component);
                }
            }
        }

        public static void ExecuteForAllInParent<T>(this GameObject gameObject, Action<T> action,
            bool includeInactive = false)
            where T : class
        {
            using (ListPool<T>.Get(out var list))
            {
                gameObject.GetComponentsInParent<T>(includeInactive, list);
                foreach (var component in list)
                {
                    action(component);
                }
            }
        }

        public static void SetHideFlagsRecursive(this GameObject gameObject, HideFlags hideFlags)
        {
            gameObject.hideFlags = HideFlags.DontSaveInBuild | HideFlags.DontSaveInEditor;

            foreach (Transform child in gameObject.transform)
            {
                SetHideFlagsRecursive(child.gameObject, hideFlags);
            }
        }
    }
}
