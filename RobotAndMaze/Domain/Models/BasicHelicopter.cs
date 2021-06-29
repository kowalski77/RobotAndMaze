using RobotAndMaze.Domain.Models.Abstractions;

namespace RobotAndMaze.Domain.Models
{
    public class BasicHelicopter : IHelicopter
    {
        public BasicHelicopter(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public RobotType RobotType => RobotType.BasicHelicopter;

        public Step UpRight  => Step.CreateInstance(1);

        public Step UpLeft  => Step.CreateInstance(1);

        public Step DownRight  => Step.CreateInstance(1);

        public Step DownLeft  => Step.CreateInstance(1);

        public Step Forward => Step.CreateInstance(1);

        public Step Back => Step.CreateInstance(1);

        public Step Left => Step.CreateInstance(1);

        public Step Right => Step.CreateInstance(1);
    }
}