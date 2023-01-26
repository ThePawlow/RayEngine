using System.Collections.ObjectModel;
using RayEngine.Components;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace RayEngine.SceneControl;

public partial class Scene: GameObject
{
        public Scene(string name)
        {
                Name = name;
        }
        
        public void DrawableTexts()
        {
                foreach (var text in _text2DCollection)
                {
                        text.Draw();
                }
        }

        public void DrawableRectangles()
        {
                foreach (var rectangle2D in _rectangle2DCollection)
                {
                        rectangle2D.Draw();
                }
        }
}