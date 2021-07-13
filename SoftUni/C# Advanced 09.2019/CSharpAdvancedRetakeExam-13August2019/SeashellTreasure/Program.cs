using System;
using System.Collections.Generic;
using System.Linq;

namespace SeashellTreasure
{
    class Program
    {
        static char[][] beach;
        static char[] seaShellTypes;
        static List<char> backpack;
        static int stolenShells;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            beach = new char[n][];
            seaShellTypes = "CMN".ToCharArray();
            backpack = new List<char>();
            stolenShells = 0;

            for (int row = 0; row < beach.Length; row++)
            {
                beach[row] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            }

            string input;

            while ((input = Console.ReadLine()) != "Sunset")
            {
                string[] commandData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = commandData[0];
                int row = int.Parse(commandData[1]);
                int col = int.Parse(commandData[2]);
                string direction = "";

                if (commandData.Length == 4)
                {
                    direction = commandData[3];
                }

                if (IsOnBeach(row, col))
                {
                    if (command == "Collect" && IsSeaShell(row, col))
                    {
                        backpack.Add(beach[row][col]);
                        beach[row][col] = '-';
                    }
                    else if (command == "Steal")
                    {
                        if (IsSeaShell(row, col))
                        {
                            stolenShells++;
                            beach[row][col] = '-';
                        }

                        for (int i = 1; i <= 3; i++)
                        {
                            switch (direction)
                            {
                                case "up": Move(row - i, col); break;
                                case "down": Move(row + i, col); break;
                                case "left": Move(row, col - i); break;
                                case "right": Move(row, col + i); break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }

            for (int row = 0; row < beach.Length; row++)
            {
                Console.WriteLine(string.Join(" ", beach[row]).TrimEnd());
            }
            string collectedSeashells = backpack.Count != 0 ? $"{backpack.Count} -> " + string.Join(", ", backpack) : "0";
            Console.WriteLine($"Collected seashells: {collectedSeashells}");
            Console.WriteLine($"Stolen seashells: {stolenShells}");
        }

        private static void Move(int row, int col)
        {
            if (IsOnBeach(row, col) && IsSeaShell(row, col))
            {
                stolenShells++;
                beach[row][col] = '-';
            }
        }

        private static bool IsSeaShell(int row, int col)
        {
            return seaShellTypes.Any(s => s == beach[row][col]);
        }

        private static bool IsOnBeach(int row, int col)
        {
            return row >= 0 && row < beach.Length &&
                    col >= 0 && col < beach[row].Length;
        }
    }
}
