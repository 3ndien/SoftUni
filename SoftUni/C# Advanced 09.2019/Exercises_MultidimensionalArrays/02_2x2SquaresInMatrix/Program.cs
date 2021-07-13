using System;
using System.Linq;

namespace _02_2x2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rowSize = sizes[0];
            var colSize = sizes[1];

            var matrix = new string[rowSize, colSize];

            for (int row = 0; row < rowSize; row++)
            {
                var line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < colSize; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            var counter = 0;

            for (int row = 0; row < rowSize - 1; row++)
            {
                for (int col = 0; col < colSize - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] 
                        && matrix[row, col + 1] == matrix[row + 1, col] 
                        && matrix[row + 1, col] == matrix[row + 1, col + 1])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
