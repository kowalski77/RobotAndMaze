using System;
using System.Collections.Generic;
using RobotAndMaze.Domain.Models;
using RobotAndMaze.Domain.Models.Abstractions;

namespace RobotAndMaze.Domain.Factories
{
    public class MachineProviderStrategy : IMachineProviderFactory
    {
        private readonly Dictionary<RobotType, MachineProvider> strategies;

        public MachineProviderStrategy(Dictionary<RobotType, MachineProvider> strategies)
        {
            this.strategies = strategies ?? throw new ArgumentNullException(nameof(strategies));
        }

        public MachineProvider CreateMachineProvider(RobotType robotType)
        {
            return this.strategies.TryGetValue(robotType, out var strategy) ? 
                strategy : 
                throw new InvalidOperationException($"Could not found any strategy for robot of type: {nameof(robotType)}");
        }
    }
}