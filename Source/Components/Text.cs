using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace RayEngine.Components;

public interface IRayText
{
        string text {get; set;}
        int posX {get; set;}
        int posY {get; set;}
        int fontSize {get; set;}
        Color color {get; set;}
}

public class Text
{
        public string Content;
        public readonly Vector2 Pos;
        public int FontSize;
        public Color Color;

        public Text(string content, Vector2 pos, int fontSize, Color color)
        {
                var dpi = GetWindowScaleDPI();
                
                Content = content;
                Pos = pos;
                FontSize = (int) (fontSize * dpi.X);
                Color = color;
        }

        public IRayText Drawable()
        {
                IRayText rayText = new object() as IRayText;
                rayText.text = Content;
                rayText.posX = (int) Pos.X;
                rayText.posY = (int) Pos.Y;
                rayText.fontSize = FontSize;
                rayText.color = Color;

                return rayText;
        }
}