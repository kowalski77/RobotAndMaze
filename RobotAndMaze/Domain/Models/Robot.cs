namespace RobotAndMaze.Domain.Models
{
    public class Robot : IRobot
    {
        public Robot(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public Step Forward()
        {
            return Step.CreateInstance(1);
        }

        public Step Back()
        {
            return Step.CreateInstance(1);
        }

        public Step Left()
        {
            return Step.CreateInstance(1);
        }

        public Step Right()
        {
            return Step.CreateInstance(1);
        }
    }
}