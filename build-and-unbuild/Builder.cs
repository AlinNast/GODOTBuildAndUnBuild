using Godot;
using System;



public partial class Builder : Node
{
    // The static reference to the one and only instance
    public static Builder Instance { get; private set; }

    public override void _Ready()
    {
        // Singleton Enforcement
        if (Instance == null)
        {
            Instance = this;
        }
    }


    public void BuildCube(Cube cube)
    {
        GiveCubeColour(cube);

        if (GD.Randf() > 0.5f)
        {
            GiveCubeEmmision(cube);
        }
        if (GD.Randf() > 0.3f)
        {
            GiveCubeMetal(cube);
        }
        if (GD.Randf() > 0.7f)
        {
            GiveCubeGrow(cube);
        }
        if (GD.Randf() > 0.7f)
        {
            GiveCubeOutline(cube);
        }
    }

    private void GiveCubeColour(Cube cube)
    {
        // Make random colour
        float r = GD.Randf();
        float g = GD.Randf();
        float b = GD.Randf();

        // Create material
        StandardMaterial3D m = new StandardMaterial3D();
        m.AlbedoColor = new Color(r, g, b);

        cube.theCube.SetSurfaceOverrideMaterial(0, m);
    }

    private void GiveCubeEmmision(Cube cube)
    {
        float r = GD.Randf();
        float g = GD.Randf();
        float b = GD.Randf();

        // Make an emmision
        StandardMaterial3D m = (StandardMaterial3D)cube.theCube.GetSurfaceOverrideMaterial(0);

        m.EmissionEnabled = true;
        m.Emission = new Color(r, g, b);
        m.EmissionEnergyMultiplier = (float)GD.RandRange(0.0, 20.0);

        cube.theCube.SetSurfaceOverrideMaterial(0, m);
    }

    private void GiveCubeMetal(Cube cube)
    {
        StandardMaterial3D m = (StandardMaterial3D)cube.theCube.GetSurfaceOverrideMaterial(0);

        m.Roughness = 0.5f;
        m.Metallic = 1;

        cube.theCube.SetSurfaceOverrideMaterial(0, m);

    }

    private void GiveCubeGrow(Cube cube)
    {
        StandardMaterial3D m = (StandardMaterial3D)cube.theCube.GetSurfaceOverrideMaterial(0);

        m.Grow = true;
        m.GrowAmount = -0.5f;

        cube.theCube.SetSurfaceOverrideMaterial(0, m);
    }

    private void GiveCubeOutline(Cube cube)
    {
        float r = GD.Randf();
        float g = GD.Randf();
        float b = GD.Randf();

        StandardMaterial3D m = (StandardMaterial3D)cube.theCube.GetSurfaceOverrideMaterial(0);

        m.StencilMode = BaseMaterial3D.StencilModeEnum.Outline;
        m.StencilColor = new Color(r, g, b);

        cube.theCube.SetSurfaceOverrideMaterial(0, m);
    }
}
