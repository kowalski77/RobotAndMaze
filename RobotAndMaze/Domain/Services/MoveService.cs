﻿using System;
using RobotAndMaze.Domain.Factories;
using RobotAndMaze.Domain.Models;
using RobotAndMaze.Support;

namespace RobotAndMaze.Domain.Services
{
    public class MoveService : IMoveService
    {
        private readonly IMachineProviderFactory machineProviderFactory;

        public MoveService(IMachineProviderFactory machineProviderFactory)
        {
            this.machineProviderFactory = machineProviderFactory;
        }

        public Result<Coordinates> CanMove(Matrix matrix, Direction direction)
        {
            var machineProvider = this.machineProviderFactory.CreateMachineProvider(MachineType.Rover);

            return machineProvider.CheckCoordinates(matrix, direction);
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