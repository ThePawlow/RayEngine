using System;
using System.IO;
using System.Numerics;
using RayEngine.Components;
using RayEngine.SceneControl;
using Raylib_CsLo;
using static Raylib_CsLo.Raylib;

namespace RayEngine.Components;

public class GameObject
{
    public string Name;

    private bool _isActive;

    public bool IsActive { get; private set; }

    public void Activate()
    {
        TraceLog(TraceLogLevel.LOG_INFO, $"Object {Name} activated");
        IsActive = true;
    }

    public void Deactivate()
    {
        TraceLog(TraceLogLevel.LOG_INFO, $"Object {Name} deactivated");
        IsActive = false;
    }

    public void Destroy()
    {
        Deactivate();
        TraceLog(TraceLogLevel.LOG_INFO, $"Object {Name} destroyed");
    }
}