using RobotAndMaze.Domain.Models;
using RobotAndMaze.Support;

namespace RobotAndMaze.Domain.Services
{
    public interface IMoveService
    {
        Result<Coordinates> CanMove(Matrix matrix, Direction direction, IRobotType machineType);
        
        Matrix Move(Matrix matrix, Direction direction, IRobotType machineType);

        bool CheckFinish(Matrix matrix);
    }
}