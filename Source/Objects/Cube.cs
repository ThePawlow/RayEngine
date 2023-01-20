using System.Numerics;
using Raylib_CsLo;
using static Raylib_CsLo.Raylib;


namespace RayEngine.Objects;

public class Cube
{
        /// <summary>
        /// Readonly, as there's no DrawPool yet
        /// </summary>
        public readonly Vector3 Size;
        
        /// <summary>
        /// Readonly, as there's no DrawPool yet
        /// </summary>
        public readonly Vector3 Position;

        public Cube(Vector3 position, Vector3 size, Color color, bool outlined = true)
        {
                Position = position;
                Size = new Vector3(size.X, size.Y, size.Z);
                DrawCube(position, Size.X, Size.Y, Size.Z, color);
                if (outlined)
                {
                        DrawCubeWires(Position, Size.X, Size.Y, Size.Z, BLACK);
                }
        }
}