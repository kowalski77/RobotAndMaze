using RobotAndMaze.Domain.Models;
using RobotAndMaze.Support;

namespace RobotAndMaze.Infrastructure
{
    public class MatrixProvider : IMatrixProvider
    {
        public Matrix GetBasic()
        {
            return new(MatrixSeed.Create3X3Cells());
        }
    }
}