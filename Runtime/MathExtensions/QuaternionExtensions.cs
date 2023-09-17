using UnityEngine;

namespace Dre0Dru.MathExtensions
{
    public static class QuaternionExtensions
    {
        public static Vector3 ToVector3(this Quaternion quaternion)
        {
            return quaternion * Vector3.forward;
        }
    }
}
