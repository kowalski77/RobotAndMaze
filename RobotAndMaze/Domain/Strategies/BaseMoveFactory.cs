using RobotAndMaze.Domain.Models;
using RobotAndMaze.Domain.Models.Abstractions;
using RobotAndMaze.Support;

namespace RobotAndMaze.Domain.Strategies;

public abstract class BaseMoveFactory : IRobotMoveFactory
{
    protected BaseMoveFactory(IRobot robot)
    {
        this.Robot = robot ?? throw new ArgumentNullException(nameof(robot));
    }

    protected IRobot Robot { get; }

    public RobotType RobotType => this.Robot.RobotType;

    public abstract Result<Coordinates> CheckCoordinates(Matrix matrix, Direction direction);
}