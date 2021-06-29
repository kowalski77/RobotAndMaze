using System;
using RobotAndMaze.Domain.Models;

namespace RobotAndMaze.Domain.Factories
{
    public class MachineProviderFactory : IMachineProviderFactory
    {
        public MachineProvider CreateMachineProvider(MachineType machineType)
        {
            return machineType switch
            {
                MachineType.Rover => new RobotMachineProvider(new BasicRobot("Max")),
                MachineType.Helicopter => new HelicopterMachineProvider(),
                MachineType.Unknown =>  throw new InvalidOperationException($"{nameof(MachineType.Unknown)} is not a valid type"),
                _ => throw new ArgumentOutOfRangeException(nameof(machineType), machineType, null)
            };
        }
    }
}