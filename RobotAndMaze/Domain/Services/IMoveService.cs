using RobotAndMaze.Domain.Models;
using RobotAndMaze.Support;

namespace RobotAndMaze.Domain.Services
{
    public interface IMoveService
    {
        Result<Matrix> Move(Matrix matrix, Movement movement);

        bool CheckFinish(Matrix matrix);
    }
}