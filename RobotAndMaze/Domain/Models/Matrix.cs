using System;
using System.Globalization;
using RobotAndMaze.Support;

namespace RobotAndMaze.Domain.Models
{
    public class Matrix
    {
        public Matrix(Cell[,] cells, Coordinates currentCoordinates)
        {
            this.Cells = cells;
            this.CurrentCoordinates = currentCoordinates;
        }

        public Cell[,] Cells { get; }

        public Coordinates CurrentCoordinates { get; }

        public Result<Coordinates> CheckCoordinates(int xPos, int yPos)
        {
            try
            {
                var cell = this.Cells[xPos, yPos];

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
            return this.Cells[coordinates.XPos, coordinates.YPos].Last;
        }

        public Matrix WithUpdatedCurrentCell(Coordinates newCoordinates)
        {
            this.Cells[this.CurrentCoordinates.XPos, this.CurrentCoordinates.YPos].SetCurrent(false);
            this.Cells[newCoordinates.XPos, newCoordinates.YPos].SetCurrent(true);

            return new(this.Cells, newCoordinates);
        }
    }
}