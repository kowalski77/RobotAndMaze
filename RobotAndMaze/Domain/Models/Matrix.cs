using System;
using RobotAndMaze.Support;

namespace RobotAndMaze.Domain.Models
{
    public class Matrix
    {
        public Matrix(Cell[,] cells)
        {
            this.Cells = cells;
        }

        public Cell[,] Cells { get; }

        public Coordinates GetCurrentCoordinates()
        {
            for (var i = 0; i < this.Cells.GetLength(0); i++)
            {
                for (var j = 0; j < this.Cells.GetLength(1); j++)
                {
                    if (this.Cells[i, j].Current)
                    {
                        return new Coordinates
                        {
                            XPos = i,
                            YPos = j
                        };
                    }
                }
            }
            
            throw new IndexOutOfRangeException();
        }

        public Result<Coordinates> CheckCoordinates(int xPos, int yPos)
        {
            try
            {
                var coordinates = this.Cells[xPos, yPos];

                return coordinates.Blocked
                    ? Result.Fail<Coordinates>($"Coordinates x:{xPos}, y:{yPos} is blocked")
                    : Result.Ok(new Coordinates
                    {
                        XPos = xPos,
                        YPos = yPos
                    });
            }
            catch (IndexOutOfRangeException)
            {
                return Result.Fail<Coordinates>($"Coordinates x:{xPos}, y:{yPos} out of the matrix limits");
            }
        }

        public Matrix SetCurrentCell(Coordinates oldCoordinates, Coordinates newCoordinates)
        {
            this.Cells[oldCoordinates.XPos, oldCoordinates.YPos].RemoveCurrent();
            this.Cells[newCoordinates.XPos, newCoordinates.YPos].SetCurrent();

            return new Matrix(this.Cells);
        }
    }
}