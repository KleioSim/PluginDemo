using DongGuan.Engine.Core;
using Godot;
using System;
using System.IO;

namespace DongGuan.Engine.Godot;

public partial class Global : Node
{
    public static string ModPath
    {
        get
        {
            var path = Path.Combine(Path.GetDirectoryName(OS.GetExecutablePath()), "mods");
            if (OS.HasFeature("editor"))
            {
                path = Path.Combine(ProjectSettings.GlobalizePath("res://"), ".mods");
            }

            return path;
        }
    }

    public ISession Session
    {
        get => session;
        set
        {
            session = value;
            session.Modder = Modder;
        }
    }

    public IModder Modder { get; set; } = new Modder(ModPath);

    private ISession session;
}
