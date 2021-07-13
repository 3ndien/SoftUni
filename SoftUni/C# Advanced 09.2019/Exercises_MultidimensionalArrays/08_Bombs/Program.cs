using System;
using System.Linq;

namespace _08_Bombs
{
    class Program
    {
        private static int[,] matrix;
        private static int[,] coords;

        static void Main(string[] args)
        {
            ReadMatrix();
            ReadBombCoords();

            for (int i = 0; i < coords.GetLength(0); i++)
            {
                BombExplode(coords[i, 0], coords[i, 1]);
            }

            var count = 0;
            var sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        count++;
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {count}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var space = col != matrix.GetLength(1) - 1 ? " " : null;
                    Console.Write(matrix[row, col] + space);
                }
                Console.WriteLine();
            }
        }

        private static void BombExplode(int row, int col)
        {
            var damage = matrix[row, col];
            if (damage <= 0)
            {
                return;
            }
            matrix[row, col] = 0;

            

            //UR
            if (IsInsideOfMatrix(row - 1, col + 1))
            {
                matrix[row - 1, col + 1] -= damage;
            }
            //U
            if (IsInsideOfMatrix(row - 1, col))
            {
                matrix[row - 1, col] -= damage;
            }
            //LU
            if (IsInsideOfMatrix(row - 1, col - 1))
            {
                matrix[row - 1, col - 1] -= damage;
            }
            //L
            if (IsInsideOfMatrix(row, col - 1))
            {
                matrix[row, col - 1] -= damage;
            }
            //LD
            if (IsInsideOfMatrix(row + 1, col - 1))
            {
                matrix[row + 1, col - 1] -= damage;
            }
            //D
            if (IsInsideOfMatrix(row + 1, col))
            {
                matrix[row + 1, col] -= damage;
            }
            //DR
            if (IsInsideOfMatrix(row + 1, col + 1))
            {
                matrix[row + 1, col + 1] -= damage;
            }
            //R
            if (IsInsideOfMatrix(row, col + 1))
            {
                matrix[row, col + 1] -= damage;
            }
        }

        private static bool IsInsideOfMatrix(int v1, int v2)
        {
            return (v1 >= 0 && v1 < matrix.GetLength(0)) && (v2 >= 0 && v2 < matrix.GetLength(1)) && matrix[v1, v2] > 0;
        }

        private static void ReadBombCoords()
        {
            var coordsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            coords = new int[coordsInput.Length, 2];

            for (int i = 0; i < coordsInput.Length; i++)
            {
                var coordinates = coordsInput[i].Split(",", StringSplitOptions.RemoveEmptyEntries);
                coords[i, 0] = int.Parse(coordinates[0]);
                coords[i, 1] = int.Parse(coordinates[1]);
            }
        }

        private static void ReadMatrix()
        {
            var size = int.Parse(Console.ReadLine());

            matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                var inputLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = inputLine[col];
                }
            }
        }
    }
}
