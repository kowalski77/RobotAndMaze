namespace RobotAndMaze.Domain.Models
{
    public class BasicRobot : IRobot
    {
        public BasicRobot(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public MachineType MachineType => MachineType.Rover;

        public Step Forward => Step.CreateInstance(1);

        public Step Back  => Step.CreateInstance(1);

        public Step Left  => Step.CreateInstance(1);

        public Step Right  => Step.CreateInstance(1);
    }
}