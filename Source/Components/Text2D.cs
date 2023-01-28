using System.Numerics;
using Raylib_CsLo;
using static Raylib_CsLo.Raylib;

namespace RayEngine.Components;

public class Text2D: GameObject
{
        public string Content;
        public readonly Vector2 Pos;
        public int FontSize;
        public Color Color;

        public Text2D(string content, Vector2 pos, int fontSize, Color color)
        {
                var dpi = GetWindowScaleDPI();
                
                Content = content;
                Pos = pos;
                FontSize = (int) (fontSize * dpi.X);
                Color = color;
        }

        public void Draw()
        {
                DrawText(Content, (int) Pos.X, (int) Pos.Y, FontSize, Color);
        }
}