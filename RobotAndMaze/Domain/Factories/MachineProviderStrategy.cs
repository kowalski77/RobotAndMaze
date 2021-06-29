using System;
using System.Collections.Generic;
using RobotAndMaze.Domain.Models;

namespace RobotAndMaze.Domain.Factories
{
    public class MachineProviderStrategy : IMachineProviderFactory
    {
        private readonly Dictionary<IRobotType, MachineProvider> strategies;

        public MachineProviderStrategy(Dictionary<IRobotType, MachineProvider> strategies)
        {
            this.strategies = strategies ?? throw new ArgumentNullException(nameof(strategies));
        }

        public MachineProvider CreateMachineProvider(IRobotType machineType)
        {
            return this.strategies.TryGetValue(machineType, out var strategy) ? strategy : default;
        }
    }
}