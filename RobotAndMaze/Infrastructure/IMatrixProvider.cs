using RobotAndMaze.Domain.Models;

namespace RobotAndMaze.Infrastructure;

public interface IMatrixProvider
{
    Matrix GetBasic();
}