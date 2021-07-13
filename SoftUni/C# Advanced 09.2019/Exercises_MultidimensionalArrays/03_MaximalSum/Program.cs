using System;
using System.Linq;

namespace _03_MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rowSize = sizes[0];
            var colSize = sizes[1];

            var matrix = new int[rowSize, colSize];

            for (int row = 0; row < rowSize; row++)
            {
                var line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < colSize; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            
            var maxSum = int.MinValue;
            var resultMatrix = new int[3, 3];

            for (int row = 0; row < rowSize - 2; row++)
            {
                var sum = 0;
                for (int col = 0; col < colSize - 2; col++)
                {
                    sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] 
                        + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                        + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        for (int r = 0; r < 3; r++)
                        {
                            for (int c = 0; c < 3; c++)
                            {
                                resultMatrix[r, c] = matrix[row + r, col + c];
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(resultMatrix[row, col] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
