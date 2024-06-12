using UnityEngine;

namespace Dre0Dru.MathExtensions
{
    public static class VectorExtensions
    {
        public const float MagnitudeZeroTolerance = 9.99999943962493E-11f;

        public static Vector3 FlattenX(this Vector3 vector3)
        {
            vector3.x = 0;

            return vector3;
        }

        public static Vector3 FlattenY(this Vector3 vector3)
        {
            vector3.y = 0;

            return vector3;
        }

        public static Vector3 FlattenZ(this Vector3 vector3)
        {
            vector3.z = 0;

            return vector3;
        }

        public static Vector2 ToVector2XZ(this Vector3 vector3)
        {
            return new Vector2(vector3.x, vector3.z);
        }

        public static Vector2 ToVector2YZ(this Vector3 vector3)
        {
            return new Vector2(vector3.y, vector3.z);
        }

        public static Vector2 ToVector2XY(this Vector3 vector3)
        {
            return new Vector2(vector3.x, vector3.y);
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

        public static (Vector3 vertical, Vector3 lateral) SplitIntoVerticalAndLateral(this Vector3 vector3, Vector3 up)
        {
            var vertical = Vector3.Project(vector3, up);
            var lateral = vector3 - vertical;

            return (vertical, lateral);
        }

        public static Quaternion ToLookRotation(this Vector3 vector3)
        {
            return Quaternion.LookRotation(vector3);
        }

        public static Quaternion ToLookRotation(this Vector3 vector3, Vector3 up)
        {
            return Quaternion.LookRotation(vector3, up);
        }

        /// <summary>
        /// Checks whether value is near to zero within a tolerance.
        /// </summary>
        public static bool IsCloseToZero(this Vector2 vector2)
        {
            return vector2.sqrMagnitude < MagnitudeZeroTolerance;
        }

        /// <summary>
        /// Checks whether value is near to zero within a tolerance.
        /// </summary>
        public static bool IsCloseToZero(this Vector3 vector3)
        {
            return vector3.sqrMagnitude < MagnitudeZeroTolerance;
        }

        /// <summary>
        /// Checks whether vector is exceeding the magnitude within a small error tolerance.
        /// </summary>
        public static bool IsExceeding(this Vector3 vector3, float magnitude)
        {
            // Allow 1% error tolerance, to account for numeric imprecision.
            const float kErrorTolerance = 1.01f;

            return vector3.sqrMagnitude > magnitude * magnitude * kErrorTolerance;
        }

        /// <summary>
        /// Returns a copy of given vector with a magnitude of 1,
        /// and outs its magnitude before normalization.
        ///
        /// If the vector is too small to be normalized a zero vector will be returned.
        /// </summary>
        public static Vector3 Normalized(this Vector3 vector3, out float magnitude)
        {
            magnitude = vector3.magnitude;
            //The same as Vector3 implementation
            if (magnitude > 9.99999974737875E-06)
                return vector3 / magnitude;

            magnitude = 0.0f;

            return Vector3.zero;
        }

        public static float Dot(this Vector3 vector3, Vector3 otherVector3)
        {
            return Vector3.Dot(vector3, otherVector3);
        }

        public static Vector3 ProjectOn(this Vector3 thisVector, Vector3 normal)
        {
            return Vector3.Project(thisVector, normal);
        }

        public static Vector3 ProjectOnPlane(this Vector3 thisVector, Vector3 planeNormal)
        {
            return Vector3.ProjectOnPlane(thisVector, planeNormal);
        }

        public static Vector3 ProjectPointOnPlane(Vector3 point, Vector3 planeOrigin, Vector3 planeNormal)
        {
            var toPoint = point - planeOrigin;
            var toPointProjected = Vector3.Project(toPoint, planeNormal);

            return point - toPointProjected;
        }

        public static Vector3 ClampMagnitude(this Vector3 vector3, float maxLength)
        {
            return Vector3.ClampMagnitude(vector3, maxLength);
        }

        /// <summary>
        /// Returns a copy of given vector perpendicular to other vector.
        /// </summary>
        public static Vector3 PerpendicularTo(this Vector3 vector3, Vector3 otherVector)
        {
            return Vector3.Cross(vector3, otherVector).normalized;
        }

        /// <summary>
        /// Returns a copy of given vector adjusted to be tangent to a specified surface normal relatively to given up axis.
        /// </summary>
        public static Vector3 TangentTo(this Vector3 vector3, Vector3 normal, Vector3 up)
        {
            return vector3.GetTangent(normal, up) * vector3.magnitude;
        }

        public static Vector3 GetTangent(this Vector3 direction, Vector3 normal, Vector3 up)
        {
            var right = direction.PerpendicularTo(up);

            return normal.PerpendicularTo(right);
        }

        /// <summary>
        /// Transforms a vector to be relative to given transform.
        /// If isPlanar == true, the transform will be applied on the plane defined by world up axis.
        /// </summary>
        public static Vector3 RelativeTo(this Vector3 vector3, Transform relativeTransform, bool isPlanar = true)
        {
            return vector3.RelativeTo(relativeTransform, Vector3.up, isPlanar);
        }

        /// <summary>
        /// Transforms a vector to be relative to given transform.
        /// If isPlanar == true, the transform will be applied on the plane defined by upAxis.
        /// </summary>
        public static Vector3 RelativeTo(this Vector3 vector3, Transform relativeTransform, Vector3 upAxis, bool isPlanar = true)
        {
            var forward = relativeTransform.forward;

            if (isPlanar)
            {
                forward = forward.ProjectOnPlane(upAxis);

                if (forward.IsCloseToZero())
                {
                    forward = relativeTransform.up.ProjectOnPlane(upAxis);
                }
            }

            return forward.ToLookRotation() * vector3;
        }
    }
}
