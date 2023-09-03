using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Dre0Dru.ObjectExtensions
{
    public static class ComponentExtensions
    {
        public static TComponent AddComponent<TComponent>(this Component component)
            where TComponent : Component =>
            component.gameObject.AddComponent<TComponent>();

        public static TComponent GetOrAddComponent<TComponent>(this Component component)
            where TComponent : Component =>
            component.gameObject.GetOrAddComponent<TComponent>();

        public static bool TryGetComponentInParent<TComponent>(this Component rootComponent, out TComponent component, bool includeInactive = false)
            where TComponent : Component =>
            rootComponent.gameObject.TryGetComponentInParent<TComponent>(out component, includeInactive);

        public static bool TryGetComponentInChildren<TComponent>(this Component rootComponent, out TComponent component, bool includeInactive = false)
            where TComponent : Component =>
            rootComponent.gameObject.TryGetComponentInChildren<TComponent>(out component, includeInactive);

        public static bool TryFindComponent<TComponent>(this Component rootComponent, out TComponent component,
            bool includeInactive = false)
            where TComponent : Component =>
            rootComponent.gameObject.TryFindComponent<TComponent>(out component, includeInactive);
        
        public static bool HasComponent<TComponent>(this Component component)
            where TComponent : Component
        {
            return component.gameObject.HasComponent<TComponent>();
        }
        
        public static bool HasComponentInParent<TComponent>(this Component component, bool includeInactive = false)
            where TComponent : Component
        {
            return component.gameObject.HasComponentInParent<TComponent>(includeInactive);
        }
        
        public static bool HasComponentInChildren<TComponent>(this Component component, bool includeInactive = false)
            where TComponent : Component
        {
            return component.gameObject.HasComponentInChildren<TComponent>(includeInactive);
        }

        public static bool RemoveComponent<TComponent>(this Component component)
            where TComponent : Component =>
            component.gameObject.RemoveComponent<TComponent>();

        public static bool RemoveSingle<T>(this Component component)
            where T : class =>
            component.gameObject.RemoveSingle<T>();

        public static void RemoveAllInChildren<T>(this Component component, bool includeInactive = false)
            where T : class =>
            component.gameObject.RemoveAllInChildren<T>();

        public static void Remove(this Component component) =>
            Object.Destroy(component);

        public static void ExecuteForComponentsInChildren<TComponent>(this Component component, Action<TComponent> action,
            bool includeInactive = false)
            where TComponent : Component =>
            component.gameObject.ExecuteForComponentsInChildren<TComponent>(action, includeInactive);

        public static void ExecuteForAllInChildren<T>(this Component component, Action<T> action,
            bool includeInactive = false)
            where T : class =>
            component.gameObject.ExecuteForAllInChildren<T>(action, includeInactive);

        public static void ExecuteForComponentsInParent<TComponent>(this Component component, Action<TComponent> action,
            bool includeInactive = false)
            where TComponent : Component =>
            component.gameObject.ExecuteForComponentsInParent<TComponent>(action, includeInactive);

        public static void ExecuteForAllInParent<T>(this Component component, Action<T> action,
            bool includeInactive = false)
            where T : class
        {
            component.gameObject.ExecuteForAllInParent<T>(action, includeInactive);
        }
        
        public static TBehaviour Enable<TBehaviour>(this TBehaviour behaviour)
            where TBehaviour : Behaviour
        {
            behaviour.enabled = true;
            return behaviour;
        }

        public static TBehaviour Disable<TBehaviour>(this TBehaviour behaviour)
            where TBehaviour : Behaviour
        {
            behaviour.enabled = false;
            return behaviour;
        }
    }
}
