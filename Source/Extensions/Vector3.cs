using System.Numerics;

namespace RayEngine.Extensions;

public static class Vector3Extension
{
        public static Vector3 Add(this Vector3 vector3, Vector3 value)
        {
                vector3.X += value.X;
                vector3.Y += value.Y;
                vector3.Z += value.Z;

                return vector3;
        }

        public static Vector3 Sub(this Vector3 vector3, Vector3 value)
        {
                vector3.X -= value.X;
                vector3.Y -= value.Y;
                vector3.Z -= value.Z;

                return vector3;
        }
}