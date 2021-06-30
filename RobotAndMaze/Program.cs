using RobotAndMaze.Application;
using RobotAndMaze.Domain.Models;
using RobotAndMaze.Domain.Services;
using RobotAndMaze.Domain.Strategies;
using RobotAndMaze.Infrastructure;

namespace RobotAndMaze
{
    internal static class Program
    {
        private static readonly IRobotMoveFactory[] RobotMoveFactories =
        {
            new RoverMoveFactory(new BasicRover("Jessie")),
            new RoverMoveFactory(new AdvancedRover("Walter")),
            new HelicopterMoveFactory(new BasicHelicopter("Skyler"))
        };

        private static void Main()
        {
            var gameManager = new GameManager(
                new MatrixProvider(),
                new GameDisplay(),
                new MoveService(
                    new MoveStrategy(RobotMoveFactories)));

            gameManager.Run(RobotType.BasicRover);
        }
    }
}