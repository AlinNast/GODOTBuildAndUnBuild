using Godot;
using System;

public partial class Cube : Area3D
{
	[Export]
	MeshInstance3D theCube;

	private bool canBeClicked = false;
	private bool isActive = true;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("leftClick") && canBeClicked && !isActive)
		{
			Activate();
		}
        if (Input.IsActionPressed("rightClick") && canBeClicked && isActive)
        {
            Deactivate();
        }
    }

	public void OnHover()
	{
		canBeClicked = true;
	}

    public void OnNotHover()
    {
        canBeClicked = false;
    }

	public void Activate()
	{
		isActive = true;
		theCube.Visible = true;
	}

    public void Deactivate()
    {
        isActive = false;
        theCube.Visible = false;
    }
}
