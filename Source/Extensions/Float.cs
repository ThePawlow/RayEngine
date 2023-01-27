namespace RayEngine.Extensions;

public static class FloatExtensions
{
        public static bool IsPositive(this float f)
        {
                return f > 0;
        }

        public static bool IsNegative(this float f)
        {
                return f < 0;
        }
}