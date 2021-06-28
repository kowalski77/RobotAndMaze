namespace RobotAndMaze.Domain.Models
{
    public interface ITurn
    {
        Movement Left();

        Movement Right();
    }
}