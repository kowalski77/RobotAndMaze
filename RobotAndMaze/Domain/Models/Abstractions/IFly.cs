namespace RobotAndMaze.Domain.Models.Abstractions
{
    public interface IFly
    {
        Step UpRight { get; }

        Step UpLeft { get; }

        Step DownRight { get; }

        Step DownLeft { get; }
    }
}