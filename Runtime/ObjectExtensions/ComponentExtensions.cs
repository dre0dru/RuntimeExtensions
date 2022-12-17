using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Dre0Dru.ObjectExtensions
{
    public static class ComponentExtensions
    {
        public static T AddComponent<T>(this Component component)
            where T : Component =>
            component.gameObject.AddComponent<T>();

        public static T GetOrAddComponent<T>(this Component component)
            where T : Component =>
            component.gameObject.GetOrAddComponent<T>();

        public static bool RemoveComponent<T>(this Component component)
            where T : Component =>
            component.gameObject.RemoveComponent<T>();

        public static bool RemoveComponentCasted<T>(this Component component) =>
            component.gameObject.RemoveComponentCasted<T>();
        
        public static void Remove(this Component component) => 
            Object.Destroy(component);

        public static void ExecuteDownwards<TComponent>(this Component root, Action<TComponent> action,
            bool includeInactive = false)
            where TComponent : Component =>
            root.gameObject.ExecuteDownwards<TComponent>(action, includeInactive);

        public static void ExecuteUpwards<TComponent>(this Component root, Action<TComponent> action,
            bool includeInactive = false)
            where TComponent : Component =>
            root.gameObject.ExecuteUpwards<TComponent>(action, includeInactive);

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
