using System;
using System.Collections.Generic;
using RobotAndMaze.Domain.Models;

namespace RobotAndMaze.Domain.Factories
{
    public class MachineProviderStrategy : IMachineProviderFactory
    {
        private readonly Dictionary<MachineType, MachineProvider> strategies;

        public MachineProviderStrategy(Dictionary<MachineType, MachineProvider> strategies)
        {
            this.strategies = strategies ?? throw new ArgumentNullException(nameof(strategies));
        }

        public MachineProvider CreateMachineProvider(MachineType machineType)
        {
            return this.strategies.TryGetValue(machineType, out var strategy) ? strategy : default;
        }
    }
}