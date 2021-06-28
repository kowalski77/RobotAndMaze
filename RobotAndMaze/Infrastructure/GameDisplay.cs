using RobotAndMaze.Domain.Models;
using RobotAndMaze.Support;
using System;

namespace RobotAndMaze.Infrastructure
{
    public class GameDisplay : IGameDisplay
    {
        public void Print(Result<Matrix> result)
        {
            Console.WriteLine("-------START-------");
 
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
                    Console.Write($"{result.Value.Cells[i, j]} ");
                }
 
                Console.Write(Environment.NewLine + Environment.NewLine);
            }

            Console.WriteLine("------END---------");
        }
    }
}