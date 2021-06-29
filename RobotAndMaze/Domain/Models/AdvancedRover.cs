namespace RobotAndMaze.Domain.Models
{
    public class AdvancedRover : IRover
    {
        public AdvancedRover(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public IRobotType MachineType => IRobotType.AdvancedRover;

        public Step Forward => Step.CreateInstance(2);

        public Step Back  => Step.CreateInstance(2);

        public Step Left  => Step.CreateInstance(1);

        public Step Right  => Step.CreateInstance(1);
    }
}