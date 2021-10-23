using System;
using RobotAndMaze.Domain.Models;
using RobotAndMaze.Domain.Strategies;
using RobotAndMaze.Support;

namespace RobotAndMaze.Domain.Services
{
    public class MoveService : IMoveService
    {
        private readonly IMoveStrategy moveStrategy;

        public MoveService(IMoveStrategy moveStrategy)
        {
            this.moveStrategy = moveStrategy ?? throw new ArgumentNullException(nameof(moveStrategy));
        }

        public Result<Coordinates> CanMove(Matrix matrix, Direction direction, RobotType machineType)
        {
            var result = this.moveStrategy.CanMove(matrix, direction, machineType);

            return result;
        }

        public Matrix Move(Matrix matrix, Direction direction, RobotType machineType)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            var result = this.CanMove(matrix, direction, machineType);
            if (!result.Success)
            {
                throw new InvalidOperationException($"Can not move due to: {result.Error}");
            }

            var newlyMatrix = matrix.WithUpdatedCurrentCell(result.Value);

            return newlyMatrix;
        }

        public bool CheckFinish(Matrix matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            return matrix.CheckFinish(matrix.CurrentCoordinates);
        }
    }
}