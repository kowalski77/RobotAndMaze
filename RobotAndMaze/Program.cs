using RobotAndMaze.Application;
using RobotAndMaze.Domain.Models;
using RobotAndMaze.Domain.Services;
using RobotAndMaze.Infrastructure;

namespace RobotAndMaze
{
    internal static class Program
    {
        private static void Main()
        {
            var gameManager = new GameManager(new MatrixProvider(), new GameDisplay(), new MoveService(), new Robot("Max"));
            gameManager.Run();
        }
    }
}