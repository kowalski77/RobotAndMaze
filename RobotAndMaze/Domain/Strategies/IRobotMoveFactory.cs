using RobotAndMaze.Domain.Models;
using RobotAndMaze.Support;

namespace RobotAndMaze.Domain.Strategies
{
    public interface IRobotMoveFactory
    {
        public RobotType RobotType { get;  }

        Result<Coordinates> CheckCoordinates(Matrix matrix, Direction direction);
    }
}