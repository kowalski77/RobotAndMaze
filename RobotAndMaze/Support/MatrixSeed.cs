using RobotAndMaze.Domain.Models;

namespace RobotAndMaze.Support;

public static class MatrixSeed
{
    public static Cell[,] Create6X6Cells()
    {
        var coordinates = new Cell[6, 6];
        for (var i = 0; i < coordinates.GetLength(0); i++)
        {
            for (var j = 0; j < coordinates.GetLength(1); j++)
            {
                coordinates[i, j] = new Cell(false, false, false);
            }
        }

        coordinates[0, 0].SetCurrent(true);
        coordinates[0, 2].SetBlocked();
        coordinates[0, 3].SetBlocked();
        coordinates[3, 5].SetBlocked();
        coordinates[2, 2].SetBlocked();
        coordinates[2, 3].SetBlocked();
        coordinates[3, 1].SetBlocked();
        coordinates[3, 3].SetBlocked();
        coordinates[4, 3].SetBlocked();
        coordinates[5, 0].SetBlocked();
        coordinates[5, 1].SetBlocked();
        coordinates[5, 4].SetLast();

        return coordinates;
    }
}