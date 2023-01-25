using System.Collections.ObjectModel;
using RayEngine.Components;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace RayEngine.SceneControl;

public class Scene
{
        public string Name;
        public bool IsActive;
        public readonly Collection<Text2D> Text2DCollection = new();
        public readonly Collection<Rectangle2D> Rectangle2DCollection = new();

        public Scene(string name, bool isActive = false)
        {
                Name = name;
                IsActive = isActive;
        }

        public void SetActive()
        {
                TraceLog(TraceLogLevel.LOG_INFO, $"[SCENE]: Setting Scene {Name} active.");
                IsActive = true;
        }
        public void Add(Text2D component)
        {
                if (Text2DCollection.Contains(component))
                {
                        TraceLog(TraceLogLevel.LOG_DEBUG, "Attempt to register existing Text2D; Passing");
                        return;
                }

                Text2DCollection.Add(component);
        }

        public void Add(Rectangle2D component)
        {
                if (Rectangle2DCollection.Contains(component))
                {
                        TraceLog(TraceLogLevel.LOG_DEBUG, "Attempt to register existing Rectangle2D; Passing");
                        return;
                }

                Rectangle2DCollection.Add(component);
        }

        public void DrawableTexts()
        {
                foreach (var text in Text2DCollection)
                {
                        text.Draw();
                }
        }

        public void DrawableRectangles()
        {
                foreach (var rectangle2D in Rectangle2DCollection)
                {
                        rectangle2D.Draw();
                }
        }
        public void SetInactive()
        {
                TraceLog(TraceLogLevel.LOG_INFO, "SetInactive");
        }
        public void Destroy()
        {
                TraceLog(TraceLogLevel.LOG_INFO, "Destroy");
        }
}