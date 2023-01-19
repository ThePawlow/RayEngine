using System.Numerics;
using Raylib_CsLo;
using static Raylib_CsLo.Raylib;


namespace RayEngineNet7.Objects;

public class Cube
{
        public Vector3 Size;
        public Vector3 Position;

        public Cube(Vector3 position, Vector3 size)
        {
                Position = position;
                Size = new Vector3(size.X, size.Y, size.Z);
                DrawCube(position, Size.X, Size.Y, Size.Z, BLUE);
        }
}

public static class CubeExtensions
{
        public static void Outline(this Cube cube, Color color)
        {
                DrawCubeWires(cube.Position, cube.Size.X, cube.Size.Y, cube.Size.Z, color);
        }
}