namespace RobotAndMaze.Domain.Models
{
    public interface IRobot
    {
        string Name { get; }

        IRobotType MachineType { get; }
    }
}