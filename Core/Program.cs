using System.Numerics;
using Core.Objects;
using Raylib_CsLo;
using static Raylib_CsLo.Raylib;

namespace Core
{
        public static class Program
        {
                public static unsafe int Main()
                {
                        // Initialization
                        InitWindow(1240, 800, "Игровой движок");

                        // Define the camera to look into our 3d world
                        Camera3D camera = new()
                        {
                                position = new(10.0f, 10.0f, 10.0f),// Camera position
                                target = new(0.0f, 0.0f, 0.0f),// Camera looking at point
                                up = new(0.0f, 1.0f, 0.0f),// Camera up vector (rotation towards target)
                                fovy = 45.0f,// Camera field-of-view Y
                                projection_ = CameraProjection.CAMERA_PERSPECTIVE// Camera mode type
                        };

                        SetCameraMode(camera, CameraMode.CAMERA_FREE);// Set a free camera mode

                        SetCameraPanControl((int) MouseButton.MOUSE_BUTTON_RIGHT);

                        SetTargetFPS(60);// Set our game to run at 60 frames-per-second

                        // Main game loop
                        while (!WindowShouldClose())// Detect window close button or ESC key
                        {
                                // Update
                                UpdateCamera(&camera);// Update camera

                                if (IsKeyDown('Z'))
                                {
                                        camera.target = new(0.0f, 0.0f, 0.0f);
                                }

                                // Draw
                                BeginDrawing();

                                ClearBackground(RAYWHITE);

                                BeginMode3D(camera);

                                // DrawCube(cubePosition, 2.0f, 2.0f, 2.0f, RED);
                                // DrawCubeWires(cubePosition, 2.0f, 2.0f, 2.0f, MAROON);
                                var cube = new Cube(Vector3.Zero, new Vector3(2f, 2f, 2f));
                                cube.Outline(DARKBLUE);

                                DrawGrid(32, 1.0f);

                                EndMode3D();

                                DrawRectangle(10, 10, 320, 133, Fade(SKYBLUE, 0.5f));
                                DrawRectangleLines(10, 10, 320, 133, BLUE);

                                DrawText("Free camera default controls:", 20, 20, 10, BLACK);
                                DrawText("- Mouse Wheel to Zoom in-out", 40, 40, 10, DARKGRAY);
                                DrawText("- Mouse Right Pressed to Pan", 40, 60, 10, DARKGRAY);
                                DrawText("- Alt + Mouse Right Pressed to Rotate", 40, 80, 10, DARKGRAY);
                                DrawText("- Alt + Ctrl + Mouse Right Pressed for Smooth Zoom", 40, 100, 10, DARKGRAY);
                                DrawText("- Z to zoom to (0, 0, 0)", 40, 120, 10, DARKGRAY);

                                EndDrawing();
                        }


                        CloseWindow();// Close window and OpenGL context

                        return 0;
                }
        }
}