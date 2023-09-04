using UnityEngine;

namespace Dre0Dru.MathExtensions
{
    public static class VectorExtensions
    {
        public static Vector3 Flatten(this Vector3 vector3)
        {
            vector3.y = 0;

            return vector3;
        }

        public static Vector2 ToLocalSpace(this Vector2 vector2, Transform transform)
        {
            var direction = vector2.ToVector3XZ();
            
            var result = transform.InverseTransformDirection(direction);

            return new Vector2(result.x, result.z);
        }

        public static Vector3 ToVector3XZ(this Vector2 vector2, float y = 0)
        {
            return new Vector3(vector2.x, y, vector2.y);
        }
        
        public static Vector3 ToVector3YZ(this Vector2 vector2, float x = 0)
        {
            return new Vector3(x, vector2.x, vector2.y);
        }
        
        public static Vector3 ToVector3XY(this Vector2 vector2, float z = 0)
        {
            return new Vector3(vector2.x, vector2.y, z);
        }
        
        public static Vector2 CalculateDirectionFromAngle2D(float angle)
        {
            var xDir = Mathf.Sin(angle * Mathf.Deg2Rad);
            var zDir = Mathf.Cos(angle * Mathf.Deg2Rad);

            return new Vector2(xDir, zDir).normalized;
        }
    }
}
