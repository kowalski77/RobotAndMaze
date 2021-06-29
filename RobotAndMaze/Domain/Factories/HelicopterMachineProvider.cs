using System;
using RobotAndMaze.Domain.Models;
using RobotAndMaze.Domain.Models.Abstractions;
using RobotAndMaze.Support;

namespace RobotAndMaze.Domain.Factories
{
    public class HelicopterMachineProvider : MachineProvider
    {
        private readonly IHelicopter helicopter;

        public HelicopterMachineProvider(IHelicopter helicopter)
        {
            this.helicopter = helicopter ?? throw new ArgumentNullException(nameof(helicopter));
        }

        public override Result<Coordinates> CheckCoordinates(Matrix matrix, Direction direction)
        {
            var coordinates = matrix.CurrentCoordinates;

            var result = direction switch
            {
                Direction.Forward => matrix.CheckCoordinates(coordinates.XPos, coordinates.YPos + this.helicopter.Forward),
                Direction.Back => matrix.CheckCoordinates(coordinates.XPos, coordinates.YPos - this.helicopter.Back),
                Direction.Left => matrix.CheckCoordinates(coordinates.XPos - this.helicopter.Left, coordinates.YPos),
                Direction.Right => matrix.CheckCoordinates(coordinates.XPos + this.helicopter.Right, coordinates.YPos),
                Direction.UpRight => matrix.CheckCoordinates(coordinates.XPos + this.helicopter.UpRight, coordinates.YPos + this.helicopter.UpRight),
                Direction.UpLeft => matrix.CheckCoordinates(coordinates.XPos - this.helicopter.UpLeft, coordinates.YPos + this.helicopter.UpLeft),
                Direction.DownRight => matrix.CheckCoordinates(coordinates.XPos + this.helicopter.DownRight, coordinates.YPos - this.helicopter.DownRight),
                Direction.DownLeft => matrix.CheckCoordinates(coordinates.XPos - this.helicopter.DownLeft, coordinates.YPos - this.helicopter.DownLeft),
                _ => Result.Fail<Coordinates>($"Direction {nameof(direction)} not available for type: {nameof(IHelicopter)}")
            };

            return result.Success
                ? Result.Ok(result.Value)
                : Result.Fail<Coordinates>($"Invalid coordinates for movement, cause: {result.Error}");
        }
    }
}