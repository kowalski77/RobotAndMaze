namespace RobotAndMaze.Domain.Models
{
    public interface IMove
    {
        Step Forward { get; }
        
        Step Back { get; }

        Step Left { get; }

        Step Right { get; }
    }
}