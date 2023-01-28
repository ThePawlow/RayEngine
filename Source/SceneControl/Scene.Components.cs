using System;
using System.Collections.ObjectModel;
using System.Linq;
using RayEngine.Components;
using Raylib_CsLo;
using static Raylib_CsLo.Raylib;

namespace RayEngine.SceneControl;

public partial class Scene
{
        private readonly Collection<Text2D> _text2DCollection = new();
        private readonly Collection<Rectangle2D> _rectangle2DCollection = new();

        public void Add<T>(T component)
        {
                switch (component)
                {
                        case Text2D text2D:
                                TraceLog(TraceLogLevel.LOG_INFO, "Applying Text2D");

                                if (_text2DCollection.Contains(text2D))
                                {
                                        TraceLog(TraceLogLevel.LOG_ERROR, "Cannot apply already existing Text2D");
                                        break;
                                }

                                _text2DCollection.Add(text2D);
                                break;

                        case Rectangle2D rectangle2D:
                                TraceLog(TraceLogLevel.LOG_INFO, "Applying Rectangle2D");

                                if (_rectangle2DCollection.Contains(rectangle2D))
                                {
                                        TraceLog(TraceLogLevel.LOG_ERROR, "Cannot apply already existing Rectangle2D");
                                        break;
                                }

                                _rectangle2DCollection.Add(rectangle2D);
                                break;

                        default:
                                throw new ArgumentException("Given Component is not supported - " + component.GetType());
                }
        }

        public T Get<T>(T component) where T : class
        {
                switch (component)
                {
                        case Text2D text2D:
                                TraceLog(TraceLogLevel.LOG_INFO, "Found Text2D");
                                return _text2DCollection.First(filter => filter.GetHashCode() == text2D.GetHashCode()) as T;

                        case Rectangle2D rectangle2D:
                                TraceLog(TraceLogLevel.LOG_INFO, "Found Text2D");
                                return _rectangle2DCollection.First(filter => filter.GetHashCode() == rectangle2D.GetHashCode()) as T;

                        default:
                                throw new ArgumentException("Given Component is not supported - " + component.GetType());
                }
        }
}