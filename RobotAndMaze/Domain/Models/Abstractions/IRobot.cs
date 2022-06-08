namespace RobotAndMaze.Domain.Models.Abstractions;

public interface IRobot
{
    string Name { get; }

    RobotType RobotType { get; }
}