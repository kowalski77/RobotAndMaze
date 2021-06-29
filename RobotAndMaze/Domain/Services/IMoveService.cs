using RobotAndMaze.Domain.Models;
using RobotAndMaze.Domain.Models.Abstractions;
using RobotAndMaze.Support;

namespace RobotAndMaze.Domain.Services
{
    public interface IMoveService
    {
        Result<Coordinates> CanMove(Matrix matrix, Direction direction, RobotType machineType);
        
        Matrix Move(Matrix matrix, Direction direction, RobotType machineType);

        bool CheckFinish(Matrix matrix);
    }
}