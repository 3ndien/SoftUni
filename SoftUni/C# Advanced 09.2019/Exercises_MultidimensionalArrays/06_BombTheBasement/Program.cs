using System;

namespace _06_BombTheBasement
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var rowSize = int.Parse(sizes[0]);
            var colSize = int.Parse(sizes[1]);

            var coords = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var rowIndex = int.Parse(coords[0]);
            var colIndex = int.Parse(coords[1]);
            var radius = int.Parse(coords[2]);

            var matrix = new int[rowSize, colSize];

            for (int row = 0; row < rowSize; row++)
            {
                for (int col = 0; col < colSize; col++)
                {
                    int a = rowIndex - row;
                    int b = colIndex - col;

                    double distance = Math.Sqrt(a * a + b * b);

                    if (distance <= radius)
                    {
                        matrix[row, col] = 1;
                    }
                }
            }

            //for (int row = 0; row < rowSize; row++)
            //{
            //    for (int col = 0; col < colSize; col++)
            //    {
            //        Console.Write(matrix[row, col]);
            //    }
            //    Console.WriteLine();
            //}

            int count = 0;

            for (int col = 0; col < colSize; col++)
            {
                for (int row = 0; row < rowSize; row++)
                {
                    if (matrix[row, col] == 1)
                    {
                        matrix[row, col] = 0;
                        count++;
                    }
                }

                if (count != 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        matrix[i, col] = 1;
                    }
                    count = 0;
                }
            }



            for (int row = 0; row < rowSize; row++)
            {
                for (int col = 0; col < colSize; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
