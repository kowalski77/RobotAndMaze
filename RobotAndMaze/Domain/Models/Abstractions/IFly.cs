namespace RobotAndMaze.Domain.Models.Abstractions;

public interface IFly
{
    int UpRight { get; }

    int UpLeft { get; }

    int DownRight { get; }

    int DownLeft { get; }
}