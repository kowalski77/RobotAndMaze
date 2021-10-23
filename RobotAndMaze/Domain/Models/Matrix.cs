using System;
using System.Globalization;
using RobotAndMaze.Support;

namespace RobotAndMaze.Domain.Models
{
    public class Matrix
    {
        private readonly Cell[,] cells;

        public Matrix(Cell[,] cells, Coordinates currentCoordinates)
        {
            this.cells = cells ?? throw new ArgumentNullException(nameof(cells));
            this.CurrentCoordinates = currentCoordinates;
        }

        public int RowLength => this.cells.GetLength(0);

        public int ColumnLength => this.cells.GetLength(1);

        public Cell GetCell(int xPos, int yPos)
        {
            return this.cells[xPos, yPos];
        }

        public Coordinates CurrentCoordinates { get; }

        public Result<Coordinates> CheckCoordinates(int xPos, int yPos)
        {
            try
            {
                var cell = this.cells[xPos, yPos];

                return cell.Blocked
                    ? Result.Fail<Coordinates>($"Coordinates x:{xPos.ToString(CultureInfo.InvariantCulture)}, y:{yPos.ToString(CultureInfo.InvariantCulture)} is blocked")
                    : Result.Ok(new Coordinates
                    {
                        XPos = xPos,
                        YPos = yPos
                    });
            }
            catch (IndexOutOfRangeException)
            {
                return Result.Fail<Coordinates>($"Coordinates x:{xPos.ToString(CultureInfo.InvariantCulture)}, y:{yPos.ToString(CultureInfo.InvariantCulture)} out of the matrix limits");
            }
        }

        public bool CheckFinish(Coordinates coordinates)
        {
            return this.cells[coordinates.XPos, coordinates.YPos].Last;
        }

        public Matrix WithUpdatedCurrentCell(Coordinates newCoordinates)
        {
            this.cells[this.CurrentCoordinates.XPos, this.CurrentCoordinates.YPos].SetCurrent(false);
            this.cells[newCoordinates.XPos, newCoordinates.YPos].SetCurrent(true);

            return new Matrix(this.cells, newCoordinates);
        }
    }
}