using RobotAndMaze.Domain.Models;
using RobotAndMaze.Domain.Services;
using RobotAndMaze.Infrastructure;
using RobotAndMaze.Support;

namespace RobotAndMaze.Application
{
    public class GameManager
    {
        private readonly IGameDisplay gameDisplay;
        private readonly IGameService gameService;

        public GameManager(IGameDisplay gameDisplay, IGameService gameService)
        {
            this.gameService = gameService;
            this.gameDisplay = gameDisplay;
        }

        public void Run()
        {
            var matrix = new Matrix(MatrixSeed.Create3X3Cells());

            //var result = this.gameService.Move(matrix, this.machine.Left());
        }

    }
}