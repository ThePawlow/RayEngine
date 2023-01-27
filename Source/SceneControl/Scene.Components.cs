using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Numerics;
using RayEngine.Components;
using RayEngine.SceneControl;
using Raylib_CsLo;
using static Raylib_CsLo.Raylib;

namespace RayEngine.SceneControl;

public partial class Scene
{
        private readonly Collection<Text2D> _text2DCollection = new();
        private readonly Collection<Rectangle2D> _rectangle2DCollection = new();

        // public void Add(Text2D component)
        // {
        //         if (_text2DCollection.Contains(component))
        //         {
        //                 TraceLog(TraceLogLevel.LOG_DEBUG, "Attempt to register existing Text2D; Passing");
        //                 return;
        //         }
        //
        //         _text2DCollection.Add(component);
        // }
        //
        // public void Add(Rectangle2D component)
        // {
        //         if (_rectangle2DCollection.Contains(component))
        //         {
        //                 TraceLog(TraceLogLevel.LOG_DEBUG, "Attempt to register existing Rectangle2D; Passing");
        //                 return;
        //         }
        //
        //         _rectangle2DCollection.Add(component);
        // }

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

        // public T Get<T>(T component)
        // {
        //         switch (component)
        //         {
        //                 case Text2D text2D:
        //                         TraceLog(TraceLogLevel.LOG_INFO, "Found Text2D");
        //                         break;
        //
        //                 case Rectangle2D rectangle2D:
        //                         TraceLog(TraceLogLevel.LOG_INFO, "Found Text2D");
        //                         break;
        //                 
        //                 default:
        //                         throw new ArgumentException("Given Component is not supported - " + component.GetType());
        //         }
        // }
}