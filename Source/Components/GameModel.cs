using System.Numerics;
using Raylib_CsLo;
using static Raylib_CsLo.Raylib;

namespace RayEngine.Components;

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
                Model.transform = Matrix4x4.CreateRotationY(Engine.DEG2RAD * Yaw);
        }
}