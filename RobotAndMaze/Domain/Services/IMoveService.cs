using RobotAndMaze.Domain.Models;
using RobotAndMaze.Support;

namespace RobotAndMaze.Domain.Services
{
    public interface IMoveService
    {
        Result<Coordinates> CanMove(Matrix matrix, Direction direction);
        
        Matrix Move(Matrix matrix, Direction direction);

        bool CheckFinish(Matrix matrix);
    }
}