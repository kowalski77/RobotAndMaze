using System;
using RobotAndMaze.Domain.Models;
using RobotAndMaze.Support;

namespace RobotAndMaze.Domain.Services
{
    public class MoveService : IMoveService
    {
        private readonly IRobot robot;

        public MoveService(IRobot robot)
        {
            this.robot = robot;
        }

        public Result<Matrix> Move(Matrix matrix, Direction direction)
        {
            var coordinates = matrix.GetCurrentCoordinates();

            var result = direction switch
            {
                Direction.Forward => matrix.CheckCoordinates(coordinates.XPos, coordinates.YPos + this.robot.Forward().Value),
                Direction.Back => matrix.CheckCoordinates(coordinates.XPos, coordinates.YPos - this.robot.Back().Value),
                Direction.Left => matrix.CheckCoordinates(coordinates.XPos - this.robot.Left().Value, coordinates.YPos),
                Direction.Right => matrix.CheckCoordinates(coordinates.XPos + this.robot.Right().Value, coordinates.YPos),
                _ => throw new ArgumentOutOfRangeException()
            };

            return result.Success ? 
                Result.Ok(matrix.SetCurrentCell(coordinates, result.Value)) : 
                Result.Fail<Matrix>($"Could not make a movement due to: {result.Error}");
        }

        public bool CheckFinish(Matrix matrix)
        {
            var coordinates = matrix.GetCurrentCoordinates();

            return matrix.CheckFinish(coordinates);
        }
    }
}