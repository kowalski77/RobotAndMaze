namespace RobotAndMaze.Domain.Models
{
    public interface IMove
    {
        Movement Forward();
        
        Movement Back();
    }
}