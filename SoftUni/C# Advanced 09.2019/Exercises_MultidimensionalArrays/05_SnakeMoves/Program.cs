using System;

namespace _05_SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimentions = Console.ReadLine().Split();
            var rowSize = int.Parse(dimentions[0]);
            var colSize = int.Parse(dimentions[1]);

            var snake = Console.ReadLine().ToCharArray();
            var matrix = new char[rowSize, colSize];
            var currIndex = 0;

            for (int row = 0; row < rowSize; row++)
            {
                for (int col = 0; col < colSize; col++)
                {
                    if (currIndex >= snake.Length)
                    {
                        currIndex = 0;
                    }

                    matrix[row, col] = snake[currIndex];
                    currIndex++;
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
