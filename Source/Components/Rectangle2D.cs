using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;


namespace RayEngine.Components;

public class Rectangle2D
{
        public bool IsActive;

        public bool IsOutlined;

        public readonly Vector2 Position;

        public readonly Vector2 Size;

        public Color Color;

        public Rectangle2D(Vector2 position, Vector2 size, Color color, bool outlined = true)
        {
                var dpi = GetWindowScaleDPI();

                Position = position;
                Size = new Vector2(size.X * dpi.X, size.Y * dpi.Y);
                Color = color;
                IsActive = false;
                IsOutlined = outlined;
        }
        public void Draw()
        {
                IsActive = true;

                DrawRectangle((int) Position.X, (int) Position.Y, (int) Size.X, (int) Size.Y, Color);
                if (IsOutlined)
                {
                        DrawRectangleLines((int) Position.X, (int) Position.Y, (int) Size.X, (int) Size.Y, Color.BLACK);
                }
        }
}