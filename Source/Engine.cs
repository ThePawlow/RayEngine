using System;
using System.IO;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace RayEngine;

public static class Engine
{
        public static unsafe int Main()
        {
                var resourceURL = new Uri(AppContext.BaseDirectory + "resourcess");
                var isResourceFolderValid = Directory.Exists(resourceURL.ToString());
                // if (!)
                // {
                //         DrawText("Something went wrong, initializing the resources", GetScreenHeight() / 2, GetScreenWidth() / 2, 20, Color.BLACK);
                //
                //         return -1;
                // }

                Console.WriteLine(resourceURL.ToString());
                // var rubberDuck = LoadModel(resourceURL + "Models/RubberDuck_LOD0.obj");
                // var tex = LoadTexture(resourceURL + "Models/RubberDuck_BaseColor.png");
                // rubberDuck.materials[0].maps[0].texture = tex;

                InitWindow(1240, 800, "RayEngine");

                var camera = new Camera3D()
                {
                        position = Vector3.Zero,
                        target = Vector3.Zero,
                        up = new(0.0f, 1.0f, 0.0f),// Camera up vector (rotation towards target)
                        fovy = 45.0f,// Camera field-of-view Y
                        projection = CameraProjection.CAMERA_PERSPECTIVE
                };

                SetCameraMode(camera, CameraMode.CAMERA_FREE);// Set a free camera mode

                SetCameraPanControl((KeyboardKey) MouseButton.MOUSE_BUTTON_RIGHT);

                SetTargetFPS(60);

                // Game Loop
                while (!WindowShouldClose())
                {
                        #region Drawing

                        BeginDrawing();

                        if (!isResourceFolderValid)
                        {
                                DrawText($"Something went wrong initializing the resources\n{resourceURL}", GetScreenHeight() / 2, GetScreenWidth() / 2, 20, Color.BLACK);
                        }


                        ClearBackground(Color.RAYWHITE);

                        #region Mode3D
                        UpdateCamera(&camera);

                        if (IsKeyDown(KeyboardKey.KEY_Z))
                        {
                                camera.target = Vector3.Zero;
                        }

                        // Begin Drawing 3D once all models etc are loaded


                        BeginMode3D(camera);

                        // Gets replaced by Objects.Cube
                        // var cube = new Cube(Vector3.Zero, new Vector3(2f, 2f, 2f), Color.DARKBLUE);
                        var enemyText = "Enemy: 100/100 HP";
                        // DrawModel(rubberDuck, Vector3.Zero, 0.1f, Color.WHITE);
                        // var rubberDuckScreenPosition = GetWorldToScreen(rubberDuck.transform.Translation, camera);
                        // rubberDuckScreenPosition.X -= (float) MeasureText(enemyText, 20) / 2;


                        DrawGrid(32, 1.0f);

                        EndMode3D();

                        #endregion

                        // REF https://www.raylib.com/examples/core/loader.html?name=core_3d_picking
                        // DrawText(enemyText, rubberDuck.transform.Translation, 20, Color.BLACK);
                        // DrawText(enemyText, (int) rubberDuck.transform.Translation.X, (int) rubberDuck.transform.Translation.Y, 20, Color.BLACK);

                        DrawRectangle(10, 10, 500, 140, Fade(Color.SKYBLUE, 0.5f));
                        DrawRectangleLines(10, 10, 500, 140, Color.BLUE);

                        // FontSize 20 is default ~ 14 for 4k
                        DrawText("Free camera default controls:", 20, 20, 20, Color.BLACK);
                        DrawText("- Mouse Wheel to Zoom in-out", 40, 40, 20, Color.DARKGRAY);
                        DrawText("- Mouse Right Pressed to Pan", 40, 60, 20, Color.DARKGRAY);
                        DrawText("- Alt + Mouse Right Pressed to Rotate", 40, 80, 20, Color.DARKGRAY);
                        DrawText("- Alt + Ctrl + Mouse Right Pressed for Smooth Zoom", 40, 100, 20, Color.DARKGRAY);
                        DrawText("- Z to zoom to (0, 0, 0)", 40, 120, 20, Color.DARKGRAY);
                        DrawFPS(10, GetScreenHeight() - 20);

                        EndDrawing();

                        #endregion
                }

                // UnloadModel(rubberDuck);
                // UnloadTexture(tex);
                CloseWindow();// Close window and OpenGL context

                return 0;
        }
}