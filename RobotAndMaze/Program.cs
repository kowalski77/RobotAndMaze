using RobotAndMaze.Application;
using RobotAndMaze.Domain.Services;
using RobotAndMaze.Infrastructure;

namespace RobotAndMaze
{
    internal static class Program
    {
        private static void Main()
        {
            var gameManager = new GameManager(new GameDisplay(), new GameService());
            gameManager.Run();
        }
    }
}