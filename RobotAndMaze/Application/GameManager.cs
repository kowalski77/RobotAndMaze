using RobotAndMaze.Domain.Models;
using RobotAndMaze.Domain.Services;

namespace RobotAndMaze.Application
{
    public class GameManager
    {
        private readonly IGameService gameService;
        private readonly IRobot machine;

        public GameManager(IGameService gameService, IRobot machine)
        {
            this.gameService = gameService;
            this.machine = machine;
        }

        public void Run()
        {
            var matrix = new Matrix(FillCoordinatesArray());

            var result = this.gameService.Move(matrix, this.machine.Right());
        }

        private static Cell[,] FillCoordinatesArray()
        {
            var coordinates = new Cell[3, 3];
            for (var i = 0; i < coordinates.GetLength(0); i++)
            {
                for (var j = 0; j < coordinates.GetLength(1); j++)
                {
                    coordinates[i, j] = new Cell(false, false);
                }
            }

            coordinates[0, 0].Current = true;
            coordinates[1, 1].Blocked = true;
            coordinates[2, 2].Exit = true;

            return coordinates;
        }
    }
}