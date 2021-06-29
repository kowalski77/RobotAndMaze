using RobotAndMaze.Domain.Models;
using RobotAndMaze.Domain.Models.Abstractions;

namespace RobotAndMaze.Domain.Factories
{
    public interface IMachineProviderFactory
    {
        MachineProvider CreateMachineProvider(RobotType robotType);
    }
}