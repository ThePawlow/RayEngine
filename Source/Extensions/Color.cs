using Raylib_CsLo;

namespace RayEngine.Extensions;

public static class ColorExtension
{
        public static Color Lighten(this Color color, Color value)
        {
                color.r = Clamp(color.r + value.r, 0, 255);
                color.g = Clamp(color.g + value.g, 0, 255);
                color.b = Clamp(color.b + value.b, 0, 255);

                return color;
        }

        public static Color Darken(this Color color, Color value)
        {
                color.r = Clamp(color.r - value.r, 0, 255);
                color.g = Clamp(color.g - value.g, 0, 255);
                color.b = Clamp(color.b - value.b, 0, 255);

                return color;
        }

        private static byte Clamp(int value, int min, int max)
        {
                return (byte) (value < min ? min : value > max ? max : value);
        }
}