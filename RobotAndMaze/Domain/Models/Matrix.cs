using System;
using RobotAndMaze.Support;

namespace RobotAndMaze.Domain.Models
{
    public class Matrix
    {
        public Matrix(Coordinates[,] coordinates)
        {
            this.Coordinates = coordinates;
        }

        public Coordinates[,] Coordinates { get; }

        public Coordinates GetCurrentCoordinates()
        {
            for (var i = 0; i < this.Coordinates.GetLength(0); i++)
            {
                for (var j = 0; j < this.Coordinates.GetLength(1); j++)
                {
                    if (this.Coordinates[i, j].Current)
                    {
                        return this.Coordinates[i, j];    
                    }
                }
            }
            
            throw new IndexOutOfRangeException();
        }

        public void SetCurrentCoordinates(Coordinates coordinates)
        {
            this.Coordinates[coordinates.XPosition, coordinates.YPosition].SetCurrent();
        }

        public Result<Coordinates> CheckCoordinates(int xPos, int yPos)
        {
            try
            {
                var coordinates = this.Coordinates[xPos, yPos];

                return coordinates.Blocked
                    ? Result.Fail<Coordinates>($"Coordinates x:{xPos}, y:{yPos} is blocked")
                    : Result.Ok(coordinates);
            }
            catch (ArgumentOutOfRangeException)
            {
                return Result.Fail<Coordinates>($"Coordinates x:{xPos}, y:{yPos} out of the matrix limits");
            }
        }
    }
}