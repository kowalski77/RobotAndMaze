namespace RobotAndMaze.Domain.Models
{
    public interface IMachine: IMove
    {
        string Name { get; }
    }
}