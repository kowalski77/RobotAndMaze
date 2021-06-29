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
            this.robot = robot ?? throw new ArgumentNullException(nameof(robot));
        }
        
        public Result<Coordinates> CanMove(Matrix matrix, Direction direction)
        {
            var coordinates = matrix.CurrentCoordinates;

            var result = direction switch
            {
                Direction.Forward => matrix.CheckCoordinates(coordinates.XPos, coordinates.YPos + this.robot.Forward.Value),
                Direction.Back => matrix.CheckCoordinates(coordinates.XPos, coordinates.YPos - this.robot.Back.Value),
                Direction.Left => matrix.CheckCoordinates(coordinates.XPos - this.robot.Left.Value, coordinates.YPos),
                Direction.Right => matrix.CheckCoordinates(coordinates.XPos + this.robot.Right.Value, coordinates.YPos),
                _ => throw new ArgumentOutOfRangeException($"{nameof(direction)} not available.")
            };
            
            return result.Success ? 
                Result.Ok(result.Value) : 
                Result.Fail<Coordinates>($"Could not make a movement due to: {result.Error}");
        } 

        public Matrix Move(Matrix matrix, Direction direction)
        {
            var result = this.CanMove(matrix, direction);
            if (!result.Success)
            {
                throw new InvalidOperationException($"Can not move due to: {result.Error}");
            }
            
            var newlyMatrix = matrix.WithUpdatedCurrentCell(result.Value);

            return newlyMatrix;
        }

        public bool CheckFinish(Matrix matrix)
        {
            return matrix.CheckFinish(matrix.CurrentCoordinates);
        }
    }
}