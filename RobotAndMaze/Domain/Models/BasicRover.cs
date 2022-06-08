using RobotAndMaze.Domain.Models.Abstractions;

namespace RobotAndMaze.Domain.Models;

public class BasicRover : IRover
{
    public BasicRover(string name)
    {
        this.Name = name;
    }

    public string Name { get; }

    public RobotType RobotType => RobotType.BasicRover;

    public int Forward => 1;

    public int Back => 1;

    public int Left => 1;

    public int Right => 1;
}