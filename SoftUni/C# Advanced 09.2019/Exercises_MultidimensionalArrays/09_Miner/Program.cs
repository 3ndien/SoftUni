using System;
using System.Linq;

namespace _09_Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());

            var commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            char[][] field = new char[size][];

            int playerRow = -1;
            int playerCol = -1;
            int coalLeft = 0;

            for (int row = 0; row < size; row++)
            {
                field[row] = Console.ReadLine().Replace(" ", "").ToCharArray();

                if (field[row].Contains('s'))
                {
                    playerRow = row;
                    playerCol = Array.IndexOf(field[row], 's');
                    field[row][playerCol] = '*';
                }
                coalLeft += field[row].Where(c => c == 'c').Count();
            }

            foreach (var command in commands)
            {
                switch (command)
                {

                    case "up": playerRow = playerRow - 1 < 0 ? playerRow : playerRow - 1; break;
                    case "down": playerRow = playerRow + 1 >= size ? playerRow : playerRow + 1; break;
                    case "left": playerCol = playerCol - 1 < 0 ? playerCol : playerCol - 1; break;
                    case "right": playerCol = playerCol + 1 >= size ? playerCol : playerCol + 1; break;
                }

                if (field[playerRow][playerCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({playerRow}, {playerCol})");
                    return;
                }
                else if (field[playerRow][playerCol] == 'c')
                {
                    field[playerRow][playerCol] = '*';
                    coalLeft--;
                    if (coalLeft == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({playerRow}, {playerCol})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{coalLeft} coals left. ({playerRow}, {playerCol})");
        }
    }
}
