namespace RayEngine.Extensions;

public static class DoubleExtensions
{
        public static bool IsPositive(this double f)
        {
                return f > 0;
        }

        public static bool IsNegative(this double f)
        {
                return f < 0;
        }
}