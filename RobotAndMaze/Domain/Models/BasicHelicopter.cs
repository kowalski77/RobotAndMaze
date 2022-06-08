using RobotAndMaze.Domain.Models.Abstractions;

namespace RobotAndMaze.Domain.Models;

public class BasicHelicopter : IHelicopter
{
    public BasicHelicopter(string name)
    {
        this.Name = name;
    }

    public string Name { get; }

    public RobotType RobotType => RobotType.BasicHelicopter;

    public int UpRight => 1;

    public int UpLeft => 1;

    public int DownRight => 1;

    public int DownLeft => 1;

    public int Forward => 1;

    public int Back => 1;

    public int Left => 1;

    public int Right => 1;
}