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
        private readonly IRobot robot;

        public GameManager(
            IMatrixProvider matrixProvider,
            IGameDisplay gameDisplay, 
            IMoveService moveService, 
            IRobot robot)
        {
            this.matrixProvider = matrixProvider;
            this.moveService = moveService;
            this.gameDisplay = gameDisplay;
            this.robot = robot;
        }

        public void Run()
        {
            this.gameDisplay.PrintStart();

            var matrix = this.matrixProvider.GetBasic();

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
                        result = this.moveService.Move(matrix, this.robot.Forward());
                        break;
                    case "s":
                        result = this.moveService.Move(matrix, this.robot.Back());
                        break;
                    case "a":
                        result = this.moveService.Move(matrix, this.robot.Left());
                        break;
                    case "d":
                        result = this.moveService.Move(matrix, this.robot.Right());
                        break;
                    default:
                        this.gameDisplay.PrintUnknownOption();
                        break;
                }

                this.gameDisplay.PrintMatrix(result);
            }
        }
    }
}