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
                Direction.Forward => matrix.CheckCoordinates(coordinates.XPos, coordinates.YPos + this.helicopter.Forward.Value),
                Direction.Back => matrix.CheckCoordinates(coordinates.XPos, coordinates.YPos - this.helicopter.Back.Value),
                Direction.Left => matrix.CheckCoordinates(coordinates.XPos - this.helicopter.Left.Value, coordinates.YPos),
                Direction.Right => matrix.CheckCoordinates(coordinates.XPos + this.helicopter.Right.Value, coordinates.YPos),
                Direction.UpRight => matrix.CheckCoordinates(coordinates.XPos + this.helicopter.UpRight.Value, coordinates.YPos + this.helicopter.UpRight.Value),
                Direction.UpLeft => matrix.CheckCoordinates(coordinates.XPos - this.helicopter.UpLeft.Value, coordinates.YPos + this.helicopter.UpLeft.Value),
                Direction.DownRight => matrix.CheckCoordinates(coordinates.XPos + this.helicopter.DownRight.Value, coordinates.YPos - this.helicopter.DownRight.Value),
                Direction.DownLeft => matrix.CheckCoordinates(coordinates.XPos - this.helicopter.DownLeft.Value, coordinates.YPos - this.helicopter.DownLeft.Value),
                _ => Result.Fail<Coordinates>($"Direction {nameof(direction)} not available for type: {nameof(IHelicopter)}")
            };

            return result.Success
                ? Result.Ok(result.Value)
                : Result.Fail<Coordinates>($"Invalid coordinates for movement, cause: {result.Error}");
        }
    }
}