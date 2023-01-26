using System.Collections.ObjectModel;
using RayEngine.Components;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace RayEngine.SceneControl;

public partial class Scene
{
        private readonly Collection<Text2D> _text2DCollection = new();
        private readonly Collection<Rectangle2D> _rectangle2DCollection = new();

        public void Add(Text2D component)
        {
                if (_text2DCollection.Contains(component))
                {
                        TraceLog(TraceLogLevel.LOG_DEBUG, "Attempt to register existing Text2D; Passing");
                        return;
                }

                _text2DCollection.Add(component);
        }

        public void Add(Rectangle2D component)
        {
                if (_rectangle2DCollection.Contains(component))
                {
                        TraceLog(TraceLogLevel.LOG_DEBUG, "Attempt to register existing Rectangle2D; Passing");
                        return;
                }

                _rectangle2DCollection.Add(component);
        }
        
        public Text2D Get()
}