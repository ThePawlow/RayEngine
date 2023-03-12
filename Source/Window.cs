using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using RayEngine.Components;
using RayEngine.SceneControl;
using Raylib_CsLo;
using static Raylib_CsLo.Raylib;

namespace RayEngine;

public class Window
{
        public bool IsActive = false;
        public int FPS
        {
                get => _fps;
                set => SetTargetFPS(value);
        }
        private int _fps;

        public Vector2 Size; 

        public string Title;

        public Window(Vector2 size, string title = "RayEngine")
        {
                Title = title;
                Size = size;
                RayGui.GuiLoadStyleDefault();

                FPS = 60;
        }

        public void Activate()
        {
                IsActive = true;
                InitWindow((int) Size.X, (int) Size.Y, Title);
        }
}