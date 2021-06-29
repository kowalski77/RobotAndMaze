namespace RobotAndMaze.Domain.Models.Abstractions
{
    public interface IMove
    {
        int Forward { get; }
        
        int Back { get; }

        int Left { get; }

        int Right { get; }
    }
}