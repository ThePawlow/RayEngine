global using Camera = Raylib_CsLo.Camera3D;
global using RenderTexture2D = Raylib_CsLo.RenderTexture;
global using Texture2D = Raylib_CsLo.Texture;
global using TextureCubemap = Raylib_CsLo.Texture;
global using Matrix = System.Numerics.Matrix4x4;

using System;
using System.IO;
using System.Numerics;
using RayEngine.Components;
using RayEngine.SceneControl;
using Raylib_CsLo;
using static Raylib_CsLo.Raylib;

namespace RayEngine;

public static class Engine
{
    public static readonly float DEG2RAD = MathF.PI / 180.0f;
    public static readonly  float RAD2DEG = 180.0f / MathF.PI;
    public static readonly Uri ResourceUrl = new(AppContext.BaseDirectory + "resources");
    public static readonly bool IsResourceFolderValid = Directory.Exists(ResourceUrl.LocalPath);

    public static unsafe int Main()
    {
        var scene = new Scene("Main");

        InitWindow(1240, 800, $"RayEngine - Scene [{scene.Name}]");
        RayGui.GuiLoadStyleDefault();

        var camera = new Camera3D
        {
            position = Vector3.Zero,
            target = Vector3.Zero,
            up = new(0.0f, 1.0f, 0.0f), // Camera up vector (rotation towards target)
            fovy = 45.0f, // Camera field-of-view Y
            projection = (int) CameraProjection.CAMERA_PERSPECTIVE
        };

        SetCameraMode(camera, CameraMode.CAMERA_FREE);
        SetCameraPanControl((int) MouseButton.MOUSE_BUTTON_RIGHT);
        SetTargetFPS(60);
        SetWindowState(ConfigFlags.FLAG_WINDOW_RESIZABLE);

        if (!IsResourceFolderValid)
        {
            scene.Add(new Text2D("Something went wrong initializing the resources\n" + ResourceUrl.LocalPath,
                new Vector2(10, 10), 20, BLACK));
        }

        scene.Add(new Text2D("RayEngine", new Vector2(20, 20), 11, BLACK));
        // DrawRectangle(10, 10, 500, 140, Fade(Color.SKYBLUE, 0.5f));
        scene.Add(new Rectangle2D(new Vector2(10, 10), new Vector2(500, 140), Fade(SKYBLUE, 0.5f)));

        // Game Loop
        var rubberDuck = new GameModel("RubberDuck_LOD0.obj");

        while (!WindowShouldClose() && IsWindowReady())
        {
            #region Drawing

            BeginDrawing();
            ClearBackground(RAYWHITE);
            
            RayGui.GuiMessageBox(new Rectangle(GetScreenHeight() /2 ,GetScreenWidth() / 2, 200, 400), "awd", "awdawd", "awdawd");

            scene.DrawableTexts();
            scene.DrawableRectangles();
            
            if (IsResourceFolderValid)
            {
                #region Mode3D

                UpdateCamera(&camera);

                if (IsKeyDown(KeyboardKey.KEY_Z))
                {
                    camera.target = Vector3.Zero;
                }

                if (IsKeyDown(KeyboardKey.KEY_Q))
                {
                    rubberDuck.Rotate(-10f);
                }

                if (IsKeyDown(KeyboardKey.KEY_E))
                {
                    rubberDuck.Rotate(10f);
                }

                // Begin Drawing 3D once all models etc are loaded

                BeginMode3D(camera);

                // Gets replaced by Objects.Cube
                // var cube = new Cube(Vector3.Zero, new Vector3(2f, 2f, 2f), Color.DARKBLUE);
                var enemyText = "Enemy: 100/100 HP";
                DrawModel(rubberDuck.Model, Vector3.Zero, 0.1f, WHITE);
                // var rubberDuckScreenPosition = GetWorldToScreen(rubberDuck.transform.Translation, camera);
                // rubberDuckScreenPosition.X -= (float) MeasureText(enemyText, 20) / 2;


                DrawGrid(32, 1.0f);

                EndMode3D();

                #endregion

                // REF https://www.raylib.com/examples/core/loader.html?name=core_3d_picking
                // DrawText(enemyText, rubberDuck.transform.Translation, 20, Color.BLACK);
                // DrawText(enemyText, (int) rubberDuck.transform.Translation.X, (int) rubberDuck.transform.Translation.Y, 20, Color.BLACK);

                scene.DrawableRectangles();
                scene.DrawableTexts();

                DrawFPS(10, GetScreenHeight() - 20);
            }

            EndDrawing();
            scene.Deactivate();

            #endregion
        }

        UnloadModel(rubberDuck.Model);
        scene.Destroy();
        // UnloadTexture(rubberDuckTex);
        CloseWindow(); // Close window and OpenGL context

        return 0;
    }
}