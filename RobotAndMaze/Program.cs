using System.Collections.Generic;
using RobotAndMaze.Application;
using RobotAndMaze.Domain.Factories;
using RobotAndMaze.Domain.Models;
using RobotAndMaze.Domain.Services;
using RobotAndMaze.Infrastructure;

namespace RobotAndMaze
{
    internal static class Program
    {
        private static void Main()
        {
            var gameManager = new GameManager(
                new MatrixProvider(),
                new GameDisplay(),
                new MoveService(
                    new MachineProviderStrategy(MachineProviders)));

            gameManager.Run(IRobotType.BasicRover);
        }

        private static readonly Dictionary<IRobotType, MachineProvider> MachineProviders = new()
        {
            { IRobotType.BasicRover, new RoverMachineProvider(new BasicRover("Max")) },
            { IRobotType.AdvancedRover, new RoverMachineProvider(new AdvancedRover("Arthur")) }
        };
    }
}