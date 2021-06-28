using System;
using RobotAndMaze.Domain.Models;
using RobotAndMaze.Domain.Services;
using RobotAndMaze.Infrastructure;
using RobotAndMaze.Support;

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

        public void Run()
        {
            this.gameDisplay.PrintStart();

            var matrix = this.matrixProvider.GetBasic();
            this.gameDisplay.PrintMatrix(matrix);

            while (true)
            {
                this.gameDisplay.PrintOptions();

                var option = Console.ReadLine();
                var result = new Result<Matrix>(matrix, true, string.Empty);
                switch (option)
                {
                    case "x":
                        this.gameDisplay.PrintEnd();
                        return;
                    case "w":
                        result = this.moveService.Move(matrix, Direction.Forward);
                        break;
                    case "s":
                        result = this.moveService.Move(matrix, Direction.Back);
                        break;
                    case "a":
                        result = this.moveService.Move(matrix, Direction.Left);
                        break;
                    case "d":
                        result = this.moveService.Move(matrix, Direction.Right);
                        break;
                    default:
                        this.gameDisplay.PrintUnknownOption();
                        break;
                }

                this.gameDisplay.PrintMatrix(result);

                if (!this.moveService.CheckFinish(matrix))
                {
                    continue;
                }

                this.gameDisplay.PrintEnd();
                return;
            }
        }
    }
}