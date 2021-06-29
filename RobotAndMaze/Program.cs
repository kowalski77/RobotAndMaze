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

            gameManager.Run();
        }

        private static readonly Dictionary<MachineType, MachineProvider> MachineProviders = new()
        {
            { MachineType.BasicRover, new RobotMachineProvider(new BasicRover("Max")) },
            { MachineType.AdvancedRover, new RobotMachineProvider(new AdvancedRover("Arthur")) }
        };
    }
}