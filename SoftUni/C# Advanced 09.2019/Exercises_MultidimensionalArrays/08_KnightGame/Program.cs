using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_KnightGame
{
    class Program
    {
        private static char[,] matrix;
        private static Dictionary<int[], int> dict = new Dictionary<int[], int>();

        private static void ReadInput()
        {
            var size = int.Parse(Console.ReadLine());

            matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                var line = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = line[col];
                }
            }
        }

        private static void Check(int row, int col, int[] position)
        {
            var DRR = new int[] { row + 1, col + 2 };
            var DLL = new int[] { row + 1, col - 2 };
            var DDR = new int[] { row + 2, col + 1 };
            var DDL = new int[] { row + 2, col - 1 };
            var URR = new int[] { row - 1, col + 2 };
            var ULL = new int[] { row - 1, col - 2 };
            var UUR = new int[] { row - 2, col + 1 };
            var UUL = new int[] { row - 2, col - 1 };

            if (OutSideOfMatrix(DRR[0], DRR[1]))
            {
                CountAttackedKnight(position);
            }
            if (OutSideOfMatrix(DLL[0], DLL[1]))
            {
                CountAttackedKnight(position);
            }
            if (OutSideOfMatrix(DDR[0], DDR[1]))
            {
                CountAttackedKnight(position);
            }
            if (OutSideOfMatrix(DDL[0], DDL[1]))
            {
                CountAttackedKnight(position);
            }

            if (OutSideOfMatrix(URR[0], URR[1]))
            {
                CountAttackedKnight(position);
            }
            if (OutSideOfMatrix(ULL[0], ULL[1]))
            {
                CountAttackedKnight(position);
            }
            if (OutSideOfMatrix(UUR[0], UUR[1]))
            {
                CountAttackedKnight(position);
            }
            if (OutSideOfMatrix(UUL[0], UUL[1]))
            {
                CountAttackedKnight(position);
            }
        }

        private static void CountAttackedKnight(int[] position)
        {
            if (!dict.ContainsKey(position))
            {
                dict.Add(position, 1);
            }
            else
            {
                dict[position]++;
            }
        }

        private static bool OutSideOfMatrix(int row, int col)
        {
            return (row >= 0 && row < matrix.GetLength(0)) && (col >= 0 && col < matrix.GetLength(1)) && (matrix[row, col] == 'K');
        }

        static void Main(string[] args)
        {
            ReadInput();

            var count = 0;

            while (true)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            var position = new int[] { row, col };

                            Check(row, col, position);
                        }
                    }
                }

                var mostBeatingKnight = dict.OrderByDescending(k => k.Value).Take(1).ToList();

                if (dict.Count == 0)
                {
                    Console.WriteLine(count);
                    break;
                }
                else
                {
                    var knightPosition = mostBeatingKnight[0].Key;
                    matrix[knightPosition[0], knightPosition[1]] = '0';

                    count++;

                    dict.Clear();
                }
            }
        }
    }
}
