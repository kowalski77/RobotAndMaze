using RobotAndMaze.Domain.Models;
using RobotAndMaze.Support;

namespace RobotAndMaze.Infrastructure
{
    public interface IGameDisplay
    {
        void Print(Result<Matrix> result);
    }
}