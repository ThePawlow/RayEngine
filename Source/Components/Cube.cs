using System.Numerics;
using Raylib_CsLo;
using static Raylib_CsLo.Raylib;


namespace RayEngine.Components;

public class Cube
{
        public readonly Vector3 Position;
        
        public readonly Vector3 Scale;

        public Cube(Vector3 position, Vector3 scale, Color color, bool outlined = true)
        {
                Position = position;
                Scale = new Vector3(scale.X, scale.Y, scale.Z);
                DrawCube(position, Scale.X, Scale.Y, Scale.Z, color);
                if (outlined)
                {
                        DrawCubeWires(Position, Scale.X, Scale.Y, Scale.Z, BLACK);
                }
        }
}