using Godot;


    public class ActivateCube : ICommandA
    {
        public Cube Cube;

        public ActivateCube(Cube cube)
        {
            this.Cube = cube;
        }

        public void Execute()
        {
        }

        public void Undo()
        {
            Cube.isActive = false;
            Cube.theCube.Visible = false;
        }
    }

