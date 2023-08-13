using UnityEngine;

namespace Dre0Dru.RigidbodyPhysics
{
    public static class PhysicsLayersExtensions
    {
        public static bool IsInLayerMask(this LayerMask layerMask, int layer)
        {
            return layerMask == (layerMask | (1 << layer));
        }

        public static bool HasNothing(this LayerMask layerMask)
        {
            return layerMask == 0;
        }
    }
}
