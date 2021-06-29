using RobotAndMaze.Domain.Models;
using RobotAndMaze.Support;

namespace RobotAndMaze.Domain.Factories
{
    public class HelicopterMachineProvider : MachineProvider
    {
        public override Result<Coordinates> CheckCoordinates(Matrix matrix, Direction direction)
        {
            throw new System.NotImplementedException();
        }
    }
}