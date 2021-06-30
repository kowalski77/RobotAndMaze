using System;
using RobotAndMaze.Domain.Models;
using RobotAndMaze.Domain.Models.Abstractions;
using RobotAndMaze.Support;

namespace RobotAndMaze.Domain.Strategies
{
    public class RoverMoveFactory : IRobotMoveFactory
    {
        private readonly IRover rover;

        public RoverMoveFactory(IRover rover)
        {
            this.rover = rover ?? throw new ArgumentNullException(nameof(rover));
        }

        public RobotType RobotType => this.rover.RobotType;

        public Result<Coordinates> CheckCoordinates(Matrix matrix, Direction direction)
        {
            var coordinates = matrix.CurrentCoordinates;

            var result = direction switch
            {
                Direction.Forward => matrix.CheckCoordinates(coordinates.XPos, coordinates.YPos + this.rover.Forward),
                Direction.Back => matrix.CheckCoordinates(coordinates.XPos, coordinates.YPos - this.rover.Back),
                Direction.Left => matrix.CheckCoordinates(coordinates.XPos - this.rover.Left, coordinates.YPos),
                Direction.Right => matrix.CheckCoordinates(coordinates.XPos + this.rover.Right, coordinates.YPos),
                _ => Result.Fail<Coordinates>($"Direction {nameof(direction)} not available for type: {nameof(IRover)}")
            };

            return result.Success
                ? Result.Ok(result.Value)
                : Result.Fail<Coordinates>($"Invalid coordinates for movement, cause: {result.Error}");
        }
    }
}