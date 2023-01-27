using System;
using System.IO;
using System.Numerics;
using RayEngine.Components;
using RayEngine.SceneControl;
using Raylib_CsLo;
using static Raylib_CsLo.Raylib;

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