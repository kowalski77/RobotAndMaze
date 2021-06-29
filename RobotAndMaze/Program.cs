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

            gameManager.Run(RobotType.BasicHelicopter);
        }

        private static readonly Dictionary<RobotType, MachineProvider> MachineProviders = new()
        {
            { RobotType.BasicRover, new RoverMachineProvider(new BasicRover("Jessie")) },
            { RobotType.AdvancedRover, new RoverMachineProvider(new AdvancedRover("Walter")) },
            { RobotType.BasicHelicopter, new HelicopterMachineProvider(new BasicHelicopter("Skyler")) }
        };
    }
}