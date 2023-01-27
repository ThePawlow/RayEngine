using System;
using System.Numerics;

namespace RayEngine.Extensions;

public static class Vector3Extension
{
        // UP           // Down
        // 0f, 1f, 0f   // 0f, -1f, 0f 
                
        // Forward      // Backwards
        // 1f, 0f, 0f   // -1f, 0f, 0f
                
        // Right         // Left
        // 0f, 0f, 1f   // 0f, 0f, -1f

        // Causes weird syntax like Vector3.Zero.Up();
        // Rethink this
        public static Vector3 Up(this Vector3 vector3, float factor = 1f)
        {
                if (factor.IsNegative())
                {
                        throw new ArgumentException("Cannot assign negative values to Vector3.Up()");
                }
                
                return new Vector3(0f, 1f, 0f);
        }

        // Causes weird syntax like Vector3.Zero.Down();
        // Rethink this
        public static Vector3 Down(this Vector3 vector3, float factor = 1f)
        {
                if (factor.IsPositive())
                {
                        throw new ArgumentException("Cannot assign positive values to Vector3.Down()");
                }

                return new Vector3(0f, -1f, 0f);
        }

        // Causes weird syntax like Vector3.Zero.Forward();
        // Rethink this
        public static Vector3 Forward(this Vector3 vector3, float factor = 1f)
        {
                if (factor.IsNegative())
                {
                        throw new ArgumentException("Cannot assign negative values to Vector3.Forwards()");
                }

                return new Vector3(factor, 0f, 0f);
        }

        // Causes weird syntax like Vector3.Zero.Backwards();
        // Rethink this
        public static Vector3 Backwards(this Vector3 vector3, float factor = -1f)
        {
                if (factor.IsPositive())
                {
                        throw new ArgumentException("Cannot assign positive values to Vector3.Backwards()");
                }

                return new Vector3(factor, 0f, 0f);
        }

        // Causes weird syntax like Vector3.Zero.Right();
        // Rethink this
        public static Vector3 Right(this Vector3 vector3, float factor = 1f)
        {
                if (factor.IsNegative())
                {
                        throw new ArgumentException("Cannot assign negative values to Vector3.Right()");
                }

                return new Vector3(0f, 0f, 1f);
        }

        // Causes weird syntax like Vector3.Zero.Left();
        // Rethink this
        public static Vector3 Left(this Vector3 vector3, float factor = 1f)
        {
                if (factor.IsPositive())
                {
                        throw new ArgumentException("Cannot assign positive values to Vector3.Left()");
                }

                return new Vector3(0f, 0f, -1f);
        }

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