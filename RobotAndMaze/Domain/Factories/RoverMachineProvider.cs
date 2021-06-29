using System;
using RobotAndMaze.Domain.Models;
using RobotAndMaze.Support;

namespace RobotAndMaze.Domain.Factories
{
    public class RoverMachineProvider : MachineProvider
    {
        private readonly IRover robot;

        public RoverMachineProvider(IRover robot)
        {
            this.robot = robot ?? throw new ArgumentNullException(nameof(robot));
        }

        public override Result<Coordinates> CheckCoordinates(Matrix matrix, Direction direction)
        {
            var coordinates = matrix.CurrentCoordinates;

            var result = direction switch
            {
                Direction.Forward => matrix.CheckCoordinates(coordinates.XPos, coordinates.YPos + this.robot.Forward.Value),
                Direction.Back => matrix.CheckCoordinates(coordinates.XPos, coordinates.YPos - this.robot.Back.Value),
                Direction.Left => matrix.CheckCoordinates(coordinates.XPos - this.robot.Left.Value, coordinates.YPos),
                Direction.Right => matrix.CheckCoordinates(coordinates.XPos + this.robot.Right.Value, coordinates.YPos),
                _ => Result.Fail<Coordinates>($"Direction {nameof(direction)} not available for type: {nameof(IRover)}")
            };

            return result.Success
                ? Result.Ok(result.Value)
                : Result.Fail<Coordinates>($"Invalid coordinates for movement, cause: {result.Error}");
        }
    }
}