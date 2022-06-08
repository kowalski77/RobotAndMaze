using System;
using System.Linq;
using RobotAndMaze.Domain.Models;
using RobotAndMaze.Support;

namespace RobotAndMaze.Domain.Strategies;

public class MoveStrategy : IMoveStrategy
{
    private readonly IRobotMoveFactory[] robotMoveFactory;

    public MoveStrategy(IRobotMoveFactory[] robotMoveFactory)
    {
        this.robotMoveFactory = robotMoveFactory ?? throw new ArgumentNullException(nameof(robotMoveFactory));
    }

    public Result<Coordinates> CanMove(Matrix matrix, Direction direction, RobotType robotType)
    {
        var moveFactory = this.robotMoveFactory.FirstOrDefault(x => x.RobotType == robotType);
        if (moveFactory == null)
        {
            throw new InvalidOperationException($"Could not found any move strategy for robot of type: {nameof(robotType)}");
        }

        return moveFactory.CheckCoordinates(matrix, direction);
    }
}