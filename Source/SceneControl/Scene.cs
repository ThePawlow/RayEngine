using System.Collections.ObjectModel;
using System.Diagnostics;
using RayEngine.Components;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace RayEngine.SceneControl;

public class Scene
{
        public string Name;
        public bool IsActive;
        public readonly Collection<Text> TextCollection = new ();

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
        public void Add(Text component)
        {
                if (TextCollection.Contains(component))
                {
                        TraceLog(TraceLogLevel.LOG_DEBUG, "Attempt to register existing TextComponent; Passing");
                        return;
                }
                
                TextCollection.Add(component);
        }

        public void DrawableTexts()
        {
                foreach (var text in TextCollection)
                {
                        DrawText(text.Content, (int)text.Pos.X, (int) text.Pos.Y, text.FontSize, text.Color);
                }
        }
}