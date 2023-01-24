using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace RayEngine.Objects;

public class GameModel
{
        public float Yaw = 0;
        public Model Model;

        public GameModel(string modelPath)
        {
                Model = LoadModel(Engine.ResourceUrl.LocalPath + "/Models/" + modelPath);
        }

        public void Rotate(float degree)
        {
                Yaw += degree;
                Model.transform = Matrix4x4.CreateRotationY(DEG2RAD * Yaw);
        }
}