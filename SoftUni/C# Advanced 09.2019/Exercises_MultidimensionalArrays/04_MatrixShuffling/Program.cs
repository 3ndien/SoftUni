using System;
using System.Linq;

namespace _04_MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rowSize = sizes[0];
            var colSize = sizes[1];

            var matrix = new string[rowSize, colSize];

            for (int row = 0; row < rowSize; row++)
            {
                var line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < colSize; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            string Input;
            while ((Input = Console.ReadLine()) != "END")
            {
                string[] tokens = Input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string command = tokens[0];

                var row1 = int.Parse(tokens[1]);
                var col1 = int.Parse(tokens[2]);
                var row2 = int.Parse(tokens[3]);
                var col2 = int.Parse(tokens[4]);

                if (command.ToLower() != "swap")
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                if ((row1 < 0 || row1 >= matrix.GetLength(0)) && (col1 < 0 || col1 >= matrix.GetLength(1)) 
                    && (row2 < 0 || row2 >= matrix.GetLength(0)) && (col2 < 0 || col2 >= matrix.GetLength(1)))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                var temp = matrix[row1, col1];
                matrix[row1, col1] = matrix[row2, col2];
                matrix[row2, col2] = temp;

                for (int row = 0; row < rowSize; row++)
                {
                    for (int col = 0; col < colSize; col++)
                    {
                        Console.Write(matrix[row, col] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
