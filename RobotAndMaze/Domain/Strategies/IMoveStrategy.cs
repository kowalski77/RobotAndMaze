using RobotAndMaze.Domain.Models;
using RobotAndMaze.Support;

namespace RobotAndMaze.Domain.Strategies;

public interface IMoveStrategy
{
    Result<Coordinates> CanMove(Matrix matrix, Direction direction, RobotType robotType);
}