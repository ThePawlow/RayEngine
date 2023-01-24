using System;
using System.Collections.ObjectModel;
using Raylib_cs;

namespace RayEngine.SceneControl;

public class Scene
{
        public interface IText
        {
                string text {get; set;}
                int posX {get; set;}
                int posY {get; set;}
                int fontSize {get; set;}
                Color color {get; set;}   
        }

        public readonly Collection<IText> TextCollection = default;

        public Action OnReady { get; set; }
        public Action OnUpdate { get; set; }
}