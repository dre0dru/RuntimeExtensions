using UnityEngine;

namespace Dre0Dru.MathExtensions
{
    public static class QuaternionExtensions
    {
        public static Vector3 ToVector3(this Quaternion quaternion)
        {
            return quaternion * Vector3.forward;
        }

        public static bool TryGetLookRotation(this Vector3 forward, out Quaternion rotation)
        {
            return forward.TryGetLookRotation(Vector3.up, out rotation);
        }

        public static bool TryGetLookRotation(this Vector3 forward, Vector3 up, out Quaternion rotation)
        {
            rotation = Quaternion.identity;

            if (forward == Vector3.zero)
            {
                return false;
            }

            rotation = Quaternion.LookRotation(forward, up);
            return true;
        }
    }
}
