using System;
using RobotAndMaze.Domain.Models;
using RobotAndMaze.Support;

namespace RobotAndMaze.Domain.Services
{
    public class GameService : IGameService
    {
        public Result Move(Matrix matrix, Movement movement)
        {
            var currentCoordinates = matrix.GetCurrentCoordinates();

            var result = movement.Direction switch
            {
                Direction.Forward => matrix.CheckCoordinates(currentCoordinates.XPosition, currentCoordinates.YPosition + movement.Steps),
                Direction.Back => matrix.CheckCoordinates(currentCoordinates.XPosition, currentCoordinates.YPosition - movement.Steps),
                Direction.Left => matrix.CheckCoordinates(currentCoordinates.XPosition - 1, currentCoordinates.YPosition),
                Direction.Right => matrix.CheckCoordinates(currentCoordinates.XPosition + 1, currentCoordinates.YPosition),
                _ => throw new ArgumentOutOfRangeException()
            };

            if (result.Success)
            {
                matrix.SetCurrentCoordinates(result.Value);
            }

            return result;
        }
    }
}