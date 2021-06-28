using System;
using RobotAndMaze.Domain.Models;
using RobotAndMaze.Support;

namespace RobotAndMaze.Domain.Services
{
    public class MoveService : IMoveService
    {
        public Result<Matrix> Move(Matrix matrix, Movement movement)
        {
            var coordinates = matrix.GetCurrentCoordinates();

            var result = movement.Direction switch
            {
                Direction.Forward => matrix.CheckCoordinates(coordinates.XPos, coordinates.YPos + movement.Steps),
                Direction.Back => matrix.CheckCoordinates(coordinates.XPos, coordinates.YPos - movement.Steps),
                Direction.Left => matrix.CheckCoordinates(coordinates.XPos - 1, coordinates.YPos),
                Direction.Right => matrix.CheckCoordinates(coordinates.XPos + 1, coordinates.YPos),
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