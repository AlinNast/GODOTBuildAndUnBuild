using Godot;
using System;
using System.Collections.Generic;
using System.Windows.Input;

public partial class Commander : Node
{
    // The static reference to the one and only instance
    public static Commander Instance { get; private set; }

    public List<ICommandA> Commands = new List<ICommandA>();

    public override void _Ready()
    {
        // Singleton Enforcement
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public override void _Process(double delta)
    {
        if(Input.IsActionJustPressed("Undo"))
        {
            Commands[^1].Undo();
            Commands.Remove(Commands[^1]);
        }
    }

    public void AddCommand(ICommandA command)
    {
        
        Commands.Add(command);
        
        GD.Print("Cube was added");
    }
}