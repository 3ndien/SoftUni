using System;
using System.Linq;

namespace _01_DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = line[col];
                }
            }


            var primarySum = 0;
            var secondarySum = 0;

            for (int row = 0; row < size; row++)
            {
                primarySum += matrix[row, row];
            }

            for (int row = 0, col = size - 1; row < size; row++, col--)
            {
                secondarySum += matrix[row, col];
            }

            var result = Math.Abs(primarySum - secondarySum);

            Console.WriteLine(result);
        }
    }
}
