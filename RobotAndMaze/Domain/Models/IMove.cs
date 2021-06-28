namespace RobotAndMaze.Domain.Models
{
    public interface IMove
    {
        Step Forward();
        
        Step Back();

        Step Left();

        Step Right();
    }
}