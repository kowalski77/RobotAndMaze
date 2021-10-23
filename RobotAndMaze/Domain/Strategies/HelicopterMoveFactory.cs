using System;
using RobotAndMaze.Domain.Models;
using RobotAndMaze.Domain.Models.Abstractions;
using RobotAndMaze.Support;

namespace RobotAndMaze.Domain.Strategies
{
    public class HelicopterMoveFactory : BaseMoveFactory
    {
        public HelicopterMoveFactory(IRobot robot) : base(robot)
        {
        }

        private IHelicopter Helicopter => (IHelicopter) this.Robot;

        public override Result<Coordinates> CheckCoordinates(Matrix matrix, Direction direction)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            var coordinates = matrix.CurrentCoordinates;

            var result = direction switch
            {
                Direction.Forward => matrix.CheckCoordinates(coordinates.XPos, coordinates.YPos + this.Helicopter.Forward),
                Direction.Back => matrix.CheckCoordinates(coordinates.XPos, coordinates.YPos - this.Helicopter.Back),
                Direction.Left => matrix.CheckCoordinates(coordinates.XPos - this.Helicopter.Left, coordinates.YPos),
                Direction.Right => matrix.CheckCoordinates(coordinates.XPos + this.Helicopter.Right, coordinates.YPos),
                Direction.UpRight => matrix.CheckCoordinates(coordinates.XPos + this.Helicopter.UpRight, coordinates.YPos + this.Helicopter.UpRight),
                Direction.UpLeft => matrix.CheckCoordinates(coordinates.XPos - this.Helicopter.UpLeft, coordinates.YPos + this.Helicopter.UpLeft),
                Direction.DownRight => matrix.CheckCoordinates(coordinates.XPos + this.Helicopter.DownRight, coordinates.YPos - this.Helicopter.DownRight),
                Direction.DownLeft => matrix.CheckCoordinates(coordinates.XPos - this.Helicopter.DownLeft, coordinates.YPos - this.Helicopter.DownLeft),
                _ => Result.Fail<Coordinates>(
                    $"Direction {nameof(direction)} not available for type: {nameof(IHelicopter)}")
            };

            return result.Success
                ? Result.Ok(result.Value)
                : Result.Fail<Coordinates>($"Invalid coordinates for movement, cause: {result.Error}");
        }
    }
}