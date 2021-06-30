using RobotAndMaze.Domain.Models;
using RobotAndMaze.Domain.Models.Abstractions;
using RobotAndMaze.Support;

namespace RobotAndMaze.Domain.Strategies
{
    public class RoverMoveFactory : BaseMoveFactory
    {
        public RoverMoveFactory(IRobot robot) : base(robot)
        {
        }

        private IRover Rover => (IRover) this.Robot;

        public override Result<Coordinates> CheckCoordinates(Matrix matrix, Direction direction)
        {
            var coordinates = matrix.CurrentCoordinates;

            var result = direction switch
            {
                Direction.Forward => matrix.CheckCoordinates(coordinates.XPos, coordinates.YPos + this.Rover.Forward),
                Direction.Back => matrix.CheckCoordinates(coordinates.XPos, coordinates.YPos - this.Rover.Back),
                Direction.Left => matrix.CheckCoordinates(coordinates.XPos - this.Rover.Left, coordinates.YPos),
                Direction.Right => matrix.CheckCoordinates(coordinates.XPos + this.Rover.Right, coordinates.YPos),
                _ => Result.Fail<Coordinates>($"Direction {nameof(direction)} not available for type: {nameof(IRover)}")
            };

            return result.Success
                ? Result.Ok(result.Value)
                : Result.Fail<Coordinates>($"Invalid coordinates for movement, cause: {result.Error}");
        }
    }
}