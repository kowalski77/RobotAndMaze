namespace RobotAndMaze.Domain.Models
{
    public class BasicRover : IRover
    {
        public BasicRover(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public MachineType MachineType => MachineType.BasicRover;

        public Step Forward => Step.CreateInstance(1);

        public Step Back  => Step.CreateInstance(1);

        public Step Left  => Step.CreateInstance(1);

        public Step Right  => Step.CreateInstance(1);
    }
}