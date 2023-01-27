namespace RayEngine.Extensions;

public static class IntExtensions
{
        public static bool IsPositive(this int f)
        {
                return f > 0;
        }

        public static bool IsNegative(this int f)
        {
                return f < 0;
        }
}