﻿using RobotAndMaze.Domain.Models;

namespace RobotAndMaze.Support
{
    public static class MatrixSeed
    {
        public static Cell[,] Create3X3Cells()
        {
            var coordinates = new Cell[3, 3];
            for (var i = 0; i < coordinates.GetLength(0); i++)
            {
                for (var j = 0; j < coordinates.GetLength(1); j++)
                {
                    coordinates[i, j] = new Cell(false, false);
                }
            }

            coordinates[0, 0].Current = true;
            coordinates[1, 1].Blocked = true;
            coordinates[2, 2].Exit = true;

            return coordinates;
        }
    }
}