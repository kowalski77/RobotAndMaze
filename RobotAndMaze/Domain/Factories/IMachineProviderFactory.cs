﻿using RobotAndMaze.Domain.Models;

namespace RobotAndMaze.Domain.Factories
{
    public interface IMachineProviderFactory
    {
        MachineProvider CreateMachineProvider(IRobotType robotType);
    }
}