using RobotAndMaze.Domain.Models;
using RobotAndMaze.Support;

namespace RobotAndMaze.Infrastructure
{
    public interface IGameDisplay
    {
        void PrintMatrix(Matrix matrix);

        void PrintMatrix(Result<Matrix> result);

        void PrintStart();

        void PrintEnd();

        void PrintOptions();

        void PrintUnknownOption();
    }
}