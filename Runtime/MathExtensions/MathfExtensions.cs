using UnityEngine;

namespace Dre0Dru.MathExtensions
{
    public static class MathfExtensions
    {
        public static float Remap(float from1, float from2, float to1, float to2, float value)
        {
            return Mathf.Lerp(to1, to2, Mathf.InverseLerp(from1, from2, value));
        }
    }
}
