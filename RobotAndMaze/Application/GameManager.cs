using System;
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
                switch (key)
                {
                    case ConsoleKey.X:
                        this.gameDisplay.PrintEnd();
                        return;
                    case ConsoleKey.W:
                        matrix = this.MakeMovement(matrix, Direction.Forward, robotType);
                        break;
                    case ConsoleKey.S:
                        matrix = this.MakeMovement(matrix, Direction.Back, robotType);
                        break;
                    case ConsoleKey.A:
                        matrix = this.MakeMovement(matrix, Direction.Left, robotType);
                        break;
                    case ConsoleKey.D:
                        matrix = this.MakeMovement(matrix, Direction.Right, robotType);
                        break;
                    default:
                        this.gameDisplay.PrintUnknownOption();
                        break;
                }

                this.gameDisplay.PrintMatrix(matrix);

                if (!this.moveService.CheckFinish(matrix))
                {
                    continue;
                }

                this.gameDisplay.PrintEnd();
                return;
            }
        }

        private Matrix MakeMovement(Matrix matrix, Direction direction, IRobotType robotType)
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