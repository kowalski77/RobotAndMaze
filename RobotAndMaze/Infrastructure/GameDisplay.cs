using RobotAndMaze.Domain.Models;
using RobotAndMaze.Support;
using System;

namespace RobotAndMaze.Infrastructure
{
    public class GameDisplay : IGameDisplay
    {
        public void PrintMatrix(Result<Matrix> result)
        {
            Console.WriteLine("===============");

            if (!result.Success)
            {
                Console.WriteLine(result.Error);
                return;
            }

            var rowLength = result.Value.Cells.GetLength(0);
            var colLength = result.Value.Cells.GetLength(1);

            for (var i = 0; i < rowLength; i++)
            {
                for (var j = 0; j < colLength; j++)
                {
                    var icon = GetIcon(result.Value.Cells[i, j]);
                    Console.Write(icon);
                }

                Console.Write(Environment.NewLine);
            }

            Console.WriteLine("===============");
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
            Console.WriteLine("[x] - Exit");
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
                { Exit: true } => "E",
                { Blocked: true } => "X",
                _ => "_"
            };
        }
    }
}