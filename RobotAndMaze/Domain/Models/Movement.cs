namespace RobotAndMaze.Domain.Models
{
    public class Movement
    {
        public Movement(Direction direction, int steps)
        {
            this.Direction = direction;
            this.Steps = steps;
        }

        public Direction Direction { get; }

        public int Steps { get; }
    }
}