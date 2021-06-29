﻿using System;
using RobotAndMaze.Domain.Models;
using RobotAndMaze.Domain.Services;
using RobotAndMaze.Infrastructure;

namespace RobotAndMaze.Application
{
    public class GameManager
    {
        private readonly IGameDisplay gameDisplay;
        private readonly IMatrixProvider matrixProvider;
        private readonly IMoveService moveService;

        public GameManager(
            IMatrixProvider matrixProvider,
            IGameDisplay gameDisplay, 
            IMoveService moveService)
        {
            this.matrixProvider = matrixProvider;
            this.moveService = moveService;
            this.gameDisplay = gameDisplay;
        }

        public void Run(IRobotType robotType)
        {
            this.gameDisplay.PrintStart();

            var matrix = this.matrixProvider.GetBasic();
            this.gameDisplay.PrintMatrix(matrix);
            
            while (true)
            {
                this.gameDisplay.PrintOptions();

                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.X)
                {
                    return;
                }

                matrix = this.MakeMovement(key, robotType, matrix);

                this.gameDisplay.PrintMatrix(matrix);

                if (!this.moveService.CheckFinish(matrix))
                {
                    continue;
                }

                this.gameDisplay.PrintEnd();
                return;
            }
        }

        private Matrix MakeMovement(ConsoleKey key, IRobotType robotType, Matrix matrix)
        {
            switch (key)
            {
                case ConsoleKey.W:
                    matrix = this.MakeMovement(robotType, matrix, Direction.Forward);
                    break;
                case ConsoleKey.S:
                    matrix = this.MakeMovement(robotType, matrix, Direction.Back);
                    break;
                case ConsoleKey.A:
                    matrix = this.MakeMovement(robotType, matrix, Direction.Left);
                    break;
                case ConsoleKey.D:
                    matrix = this.MakeMovement(robotType, matrix, Direction.Right);
                    break;
                default:
                    this.gameDisplay.PrintUnknownOption();
                    break;
            }

            return matrix;
        }

        private Matrix MakeMovement(IRobotType robotType, Matrix matrix, Direction direction)
        {
            var result = this.moveService.CanMove(matrix, direction, robotType);
            if (result.Success)
            {
                matrix = this.moveService.Move(matrix, direction, robotType);
            }

            this.gameDisplay.PrintResult(result);

            return matrix;
        }
    }
}