using System;
using System.Collections.Generic;
using System.Linq;

namespace Book_Worm
{
    class Program
    {
        static Stack<char> word;
        static char[,] field;
        static int playerRow;
        static int playerCol;

        static void Main(string[] args)
        {
            word = new Stack<char>(Console.ReadLine().ToCharArray());
            var n = int.Parse(Console.ReadLine());

            field = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                var line = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    if (line[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }

                    field[row, col] = line[col];
                }
            }

            string direction;
            while ((direction = Console.ReadLine()) != "end")
            {
                switch (direction)
                {
                    case "up":
                        Move(-1, 0);
                        break;
                    case "down":
                        Move(1, 0);
                        break;
                    case "left":
                        Move(0, -1);
                        break;
                    case "right":
                        Move(0, 1);
                        break;
                }
            }

            Console.WriteLine(string.Join("", word.Reverse()));
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void Move(int row, int col)
        {
            var nextRow = playerRow + row;
            var nextCol = playerCol + col;

            if (IsInside(nextRow, nextCol))
            {
                if (char.IsLetter(field[nextRow, nextCol]))
                {
                    var ch = field[nextRow, nextCol];
                    word.Push(ch);
                }
                
                field[playerRow, playerCol] = '-';
                playerRow = nextRow;
                playerCol = nextCol;
                field[playerRow, playerCol] = 'P';
            }
            else if(!IsInside(nextRow, nextCol))
            {
                if (word.Count > 0)
                {
                    word.Pop();
                }
            }
        }

        private static bool IsInside(int nextRow, int nextCol)
        {
            return nextRow >= 0 && nextRow < field.GetLength(0) &&
                   nextCol >= 0 && nextCol < field.GetLength(1); 
        }
    }
}
