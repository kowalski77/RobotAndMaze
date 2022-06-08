using RobotAndMaze.Domain.Models;
using RobotAndMaze.Properties;
using RobotAndMaze.Support;

namespace RobotAndMaze.Infrastructure;

public class GameDisplay : IGameDisplay
{
    public void PrintMatrix(Matrix matrix)
    {
        ArgumentNullException.ThrowIfNull(matrix);

        Console.WriteLine(Resources.Separator);

        for (var j = matrix.ColumnLength - 1; j >= 0; j--)
        {
            for (var i = 0; i < matrix.RowLength; i++)
            {
                var icon = GetIcon(matrix.GetCell(i, j));
                Console.Write(icon);
            }

            Console.Write(Environment.NewLine);
        }

        Console.WriteLine(Resources.Separator);
    }

    public void PrintResult(Result result)
    {
        ArgumentNullException.ThrowIfNull(result);

        Console.WriteLine();

        if (!result.Success)
        {
            Console.WriteLine(result.Error);
            return;
        }

        Console.WriteLine(Resources.Success);
    }

    public void PrintStart()
    {
        Console.WriteLine(Resources.StartGame);
        Console.WriteLine();
    }

    public void PrintEnd()
    {
        Console.WriteLine(Resources.EndGame);
        Console.WriteLine();
    }

    public void PrintOptions()
    {
        Console.WriteLine(Resources.SelectMovement);
        Console.WriteLine(Resources.MoveForward);
        Console.WriteLine(Resources.MoveBack);
        Console.WriteLine(Resources.MoveLeft);
        Console.WriteLine(Resources.MoveRight);
        Console.WriteLine(Resources.MoveUpLeft);
        Console.WriteLine(Resources.MoveUpRight);
        Console.WriteLine(Resources.MoveDownLeft);
        Console.WriteLine(Resources.MoveDownRight);
        Console.WriteLine(Resources.ExitGame);
    }

    public void PrintUnknownOption()
    {
        Console.WriteLine(Resources.UnknownOption);
    }

    private static string GetIcon(Cell cell)
    {
        return cell switch
        {
            { Current: true } => "C",
            { Last: true } => "E",
            { Blocked: true } => "X",
            _ => "_"
        };
    }
}