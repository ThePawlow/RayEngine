using System.Numerics;

namespace RayEngine.Extensions;

public static class Vector2Extension
{
        public static Vector2 Add(this Vector2 vector2, Vector2 value)
        {
                vector2.X += value.X;
                vector2.Y += value.Y;

                return vector2;
        }

        public static Vector2 Sub(this Vector2 vector2, Vector2 value)
        {
                vector2.X -= value.X;
                vector2.Y -= value.Y;

                return vector2;
        }
}