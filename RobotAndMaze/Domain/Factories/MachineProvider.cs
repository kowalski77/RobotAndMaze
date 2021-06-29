using RobotAndMaze.Domain.Models;
using RobotAndMaze.Support;

namespace RobotAndMaze.Domain.Factories
{
    public abstract class MachineProvider
    {
        public abstract Result<Coordinates> CheckCoordinates(Matrix matrix, Direction direction);
    }
}