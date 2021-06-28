namespace RobotAndMaze.Domain.Models
{
    public class Robot : IRobot
    {
        public Robot(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public Step Forward => Step.CreateInstance(1);

        public Step Back  => Step.CreateInstance(1);

        public Step Left  => Step.CreateInstance(1);

        public Step Right  => Step.CreateInstance(1);
    }
}