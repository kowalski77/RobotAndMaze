using RobotAndMaze.Domain.Models;
using RobotAndMaze.Support;

namespace RobotAndMaze.Domain.Services
{
    public interface IGameService
    {
        Result Move(Matrix matrix, Movement movement);
    }
}