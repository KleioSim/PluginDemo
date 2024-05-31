using Godot;
using System.Threading.Tasks;

namespace DongGuan.Engine.Godot.EventDialog;

[Tool]
public partial class DialogFacade : Control
{
    public DialogFacade()
    {
        var controlPanel = GD.Load<PackedScene>("res://addons/DongGuan.Engine.Godot/EventDialog/EventDialogRoot.tscn").Instantiate();
        this.AddChild(controlPanel, true);
    }

    [Signal]
    public delegate void TurnStartEventHandler();

    [Signal]
    public delegate void TurnEndEventHandler();

    public Global Global => GetNode<Global>("/root/DongGuan_Global");
    public InstancePlaceholder Dialog => GetNode<InstancePlaceholder>("EventDialogRoot/Dialog");


    public async void OnNextTurn()
    {
        EmitSignal(SignalName.TurnStart);

        foreach (var @event in Global.Session.OnNextTurn())
        {
            var dialog = Dialog.CreateInstance();

            GD.Print("Visible");

            await ToSignal(dialog, Control.SignalName.TreeExited);

            GD.Print("await");

        }

        EmitSignal(SignalName.TurnEnd);
    }
}