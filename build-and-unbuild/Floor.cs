using Godot;
using System;

public partial class Floor : Node3D
{
	[Export]
	public Row[] rows;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SetUpScene();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}


	public void SetUpScene()
	{
		for (int i = 0; i < 10; i++)
		{
			rows[0].cubes[i].Activate();
			rows[^1].cubes[i].Activate();
		}
		for (int i = 1; i < 8; i++)
		{
			rows[i].cubes[0].Activate();
			rows[i].cubes[^1].Activate();
		}
		Commander.Instance.Commands.Clear();
	}
}
