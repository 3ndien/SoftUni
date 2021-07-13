using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10_RadioactiveMutantVampireBunnies
{
    class Program
    {
        static char[][] matrix;
        static int playerRow = -1;
        static int playerCol = -1;

        static void Main()
        {
            var dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = dimentions[0];
            var cols = dimentions[1];

            matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
                if (matrix[row].Contains('P'))
                {
                    playerRow = row;
                    playerCol = Array.IndexOf(matrix[row], 'P');
                }
            }

            var directions = Console.ReadLine().ToCharArray();

            for (int turn = 0; turn < directions.Length; turn++)
            {
                int[] previousPosition = MovePlayer(directions[turn]);
                MultiplyBunnies();

                if (IsInMatrix())
                {
                    if (matrix[playerRow][playerCol] == 'B')
                    {
                        Die();
                    }
                    continue;
                }

                Win(previousPosition);

            }
        }

        private static void Win(int[] previousPosition)
        {
            PrintMatrix();
            Console.WriteLine($"won: {previousPosition[0]} {previousPosition[1]}");
            Environment.Exit(0);
        }

        private static void PrintMatrix()
        {
            Console.WriteLine(string.Join(Environment.NewLine, matrix.Select(r => string.Join("", r))));
        }

        private static void Die()
        {
            PrintMatrix();
            Console.WriteLine($"dead: {playerRow} {playerCol}");
            Environment.Exit(0);
        }

        private static void MultiplyBunnies()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'B')
                    {
                        if (row > 0)
                        {
                            MakeBunny(row - 1, col);
                        }

                        if (row < matrix.Length - 1)
                        {
                            MakeBunny(row + 1, col);
                        }

                        if (col > 0)
                        {
                            MakeBunny(row, col - 1);
                        }

                        if (col < matrix[row].Length - 1)
                        {
                            MakeBunny(row, col + 1);
                        }
                    }
                }
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'X')
                    {
                        matrix[row][col] = 'B';
                    }
                }
            }
        }

        private static void MakeBunny(int row, int col)
        {
            if (matrix[row][col] != 'B')
            {
                matrix[row][col] = 'X';
            }
        }

        private static int[] MovePlayer(char direction)
        {
            int[] prevPosition = { playerRow, playerCol };

            switch (direction)
            {
                case 'U': playerRow--; break;
                case 'D': playerRow++; break;
                case 'L': playerCol--; break;
                case 'R': playerCol++; break;
            }

            if (IsInMatrix() && matrix[playerRow][playerCol] != 'B')
            {
                matrix[playerRow][playerCol] = 'P';
            }

            matrix[prevPosition[0]][prevPosition[1]] = '.';

            return prevPosition;
        }

        private static bool IsInMatrix()
        {
            var validRow = playerRow >= 0 && playerRow < matrix.Length;
            var validCol = playerCol >= 0 && playerCol < matrix[0].Length;

            if (validRow && validCol)
            {
                return true;
            }
            return false;
        }
    }
}
