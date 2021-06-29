using RobotAndMaze.Domain.Models;
using RobotAndMaze.Support;
using System;

namespace RobotAndMaze.Infrastructure
{
    public class GameDisplay : IGameDisplay
    {
        public void PrintMatrix(Matrix matrix)
        {
            Console.WriteLine("===============");

            var rowLength = matrix.Cells.GetLength(0);
            var colLength = matrix.Cells.GetLength(1);

            for (var j = colLength -1 ; j >= 0; j--)
            {
                for (var i = 0; i < rowLength; i++)
                {
                    var icon = GetIcon(matrix.Cells[i, j]);
                    Console.Write(icon);
                }
                Console.Write(Environment.NewLine);
            }

            Console.WriteLine("===============");
        }

        public void PrintResult(Result result)
        {
            Console.WriteLine();

            if (!result.Success)
            {
                Console.WriteLine(result.Error);
                return;
            }

            Console.WriteLine("Success!");
        }

        public void PrintStart()
        {
            Console.WriteLine("== Start Game ==");
            Console.WriteLine();
        }

        public void PrintEnd()
        {
            Console.WriteLine("== End Game ==");
            Console.WriteLine();
        }

        public void PrintOptions()
        {
            Console.WriteLine("---- Select a movement ----");
            Console.WriteLine("[w] - Move forward");
            Console.WriteLine("[s] - Move back");
            Console.WriteLine("[a] - Move left");
            Console.WriteLine("[d] - Move right");
            Console.WriteLine("[x] - Exit game");
        }

        public void PrintUnknownOption()
        {
            Console.WriteLine("Unknown option");
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
}