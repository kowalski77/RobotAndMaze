using System;
using RobotAndMaze.Domain.Models;
using RobotAndMaze.Support;

namespace RobotAndMaze.Domain.Services
{
    public class GameService : IGameService
    {
        public Result Move(Matrix matrix, Movement movement)
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

            if (result.Success)
            {
                matrix.SetCurrentCell(coordinates, result.Value);
            }

            return result;
        }
    }
}