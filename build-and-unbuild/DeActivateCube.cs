using Godot;


    public class DeActivateCube : ICommandA
    {
        public Cube Cube;

        public DeActivateCube(Cube cube)
        {
            this.Cube = cube;
        }

        public void Execute()
        {
        }

        public void Undo()
        {
            Cube.isActive = true;
            Cube.theCube.Visible = true;
        }
    }

