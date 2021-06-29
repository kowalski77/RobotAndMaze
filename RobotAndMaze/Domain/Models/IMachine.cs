namespace RobotAndMaze.Domain.Models
{
    public interface IMachine
    {
        string Name { get; }

        MachineType MachineType { get; }
    }
}