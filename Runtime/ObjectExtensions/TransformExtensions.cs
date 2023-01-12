using UnityEngine;

namespace Dre0Dru.ObjectExtensions
{
    public static class TransformExtensions
    {
        public static void DestroyChildren(this Transform transform)
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                var child = transform.GetChild(i);
                child.Unparent();
                Object.Destroy(child.gameObject);
            }
        }

        public static void Unparent(this Transform transform) =>
            transform.SetParent(null);
    }
}
