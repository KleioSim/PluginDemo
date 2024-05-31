using DongGuan.Engine.Core;
using DongGuan.Engine.Godot;
using Godot;
using System;
using System.Collections.Generic;

public partial class Test : Control
{
    public override void _Ready()
    {
        var global = GetNode<Global>("/root/DongGuan_Global");

        global.Modder = new TestMod();
        global.Session = new TestSession();
    }
}

public class TestSession : Session
{
    public TestSession()
    {
        Entities = new List<Entity>()
        {
            new TestEntity()
        };
    }
}

public class TestMod : IModder
{
    public Dictionary<Type, IEnumerable<IEventDef>> EventDefs { get; }

    public TestMod()
    {
        EventDefs = new Dictionary<Type, IEnumerable<IEventDef>>()
        {
            { typeof(TestEntity), new [] { new TesEntityEventDef() } }
        };
    }
}

public class TestEntity : Entity
{

}

[DefTo(typeof(TestEntity))]
public class TesEntityEventDef : IEventDef
{
    public ICondition Condition { get; init; }

    public ITargetFinder TargetFinder { get; }


    public TesEntityEventDef()
    {
        Condition = new TrueCondtion();
    }
}