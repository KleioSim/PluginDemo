#if TOOLS
using Godot;

namespace DongGuan.Engine.Godot;

[Tool]
public partial class Plugin : EditorPlugin
{
    public override void _EnterTree()
    {
        AddAutoloadSingleton("DongGuan_Global", "res://addons/DongGuan.Engine.Godot/Global.cs");

        var script = GD.Load<Script>("res://addons/DongGuan.Engine.Godot/EventDialog/DialogFacade.cs");
        var texture = GD.Load<Texture2D>("res://addons/DongGuan.Engine.Godot/Icon.png");
        AddCustomType("DongGuan.EventDialog", "Control", script, texture);
    }

    public override void _ExitTree()
    {
        RemoveCustomType("DongGuan.EventDialog");
    }
}
#endif