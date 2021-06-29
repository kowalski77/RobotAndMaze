using RobotAndMaze.Domain.Models.Abstractions;

namespace RobotAndMaze.Domain.Models
{
    public class AdvancedRover : IRover
    {
        public AdvancedRover(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public RobotType RobotType => RobotType.AdvancedRover;

        public int Forward => 2;

        public int Back => 2;

        public int Left => 1;

        public int Right => 1;
    }
}