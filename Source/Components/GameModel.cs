using System.Numerics;
using RayEngine.Extensions;
using Raylib_CsLo;
using static Raylib_CsLo.Raylib;

namespace RayEngine.Components;

public class GameModel
{
        public Vector3 Position;
        public float Yaw = 0;
        public Model Model;
        public float Scale;
        public float Speed;
        public bool Outline;

        public GameModel(string modelUri, float scale = 1f, bool outline = false)
        {
                Model = LoadModel(Engine.Resources.LocalPath + "/Models/" + modelUri);
                Scale = scale;
                Outline = outline;
        }

        public void Rotate(float degree)
        {
                Yaw += degree;
                Model.transform = Matrix4x4.CreateRotationY(Engine.DEG2RAD * Yaw);
        }
        
        public void MoveForward()
        {
                Position += Vector3.Zero.Forward();
        }
        
        public void MoveBackwards()
        {
                Position += Vector3.Zero.Backwards();
        }
        

        public void Draw()
        {
                DrawModel(Model, Position, Scale, WHITE);

                if (Outline)
                {
                        DrawModelWires(Model, Position, Scale, BLACK);
                }
        }

  
}