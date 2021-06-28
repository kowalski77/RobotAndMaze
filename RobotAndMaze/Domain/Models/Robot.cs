namespace RobotAndMaze.Domain.Models
{
    public class Robot : IRobot
    {
        public Robot(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public Movement Forward()
        {
            return new(Direction.Forward, 1);
        }

        public Movement Back()
        {
            return new(Direction.Back, 1);
        }

        public Movement Left()
        {
            return new(Direction.Left, 1);
        }

        public Movement Right()
        {
            return new(Direction.Right, 1);
        }
    }
}