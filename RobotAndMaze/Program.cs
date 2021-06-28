using RobotAndMaze.Application;
using RobotAndMaze.Domain.Models;
using RobotAndMaze.Domain.Services;

namespace RobotAndMaze
{
    internal static class Program
    {
        private static void Main()
        {
            var gameManager = new GameManager(new GameService(), new Robot("Max"));
            gameManager.Run();
        }
    }
}