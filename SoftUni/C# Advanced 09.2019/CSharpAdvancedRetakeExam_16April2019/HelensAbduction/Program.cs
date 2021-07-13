using System;
using System.Linq;

namespace _02_HelensAbduction
{
    class Program
    {
        static char[][] field;

        static int parisRow;
        static int parisCol;
        static int helenRow;
        static int helenCol;

        static int energy;
        static bool isFoundHer = false;
        static bool isDead = false;

        static void Main(string[] args)
        {
            energy = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());

            field = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                field[row] = Console.ReadLine().ToCharArray();

                if (field[row].Any(c => c == 'P'))
                {
                    parisRow = row;
                    parisCol = field[row].ToList().IndexOf('P');
                }

                if (field[row].Any(c => c == 'H'))
                {
                    helenRow = row;
                    helenCol = field[row].ToList().IndexOf('H');
                }
            }

            while (true)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string direction = input[0];

                int spawnRow = int.Parse(input[1]);
                int spawnCol = int.Parse(input[2]);

                switch (direction)
                {
                    case "up":
                        field[spawnRow][spawnCol] = 'S';
                        Move(-1, 0);
                        break;
                    case "down":
                        field[spawnRow][spawnCol] = 'S';
                        Move(1, 0);
                        break;
                    case "left":
                        field[spawnRow][spawnCol] = 'S';
                        Move(0, -1);
                        break;
                    case "right":
                        field[spawnRow][spawnCol] = 'S';
                        Move(0, 1);
                        break;
                }

                if (isFoundHer)
                {
                    Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");

                    for (int row = 0; row < rows; row++)
                    {
                        Console.WriteLine(string.Join("", field[row]));
                    }

                    return;
                }
                if (isDead)
                {
                    Console.WriteLine($"Paris died at {parisRow};{parisCol}.");

                    for (int row = 0; row < rows; row++)
                    {
                        Console.WriteLine(string.Join("", field[row]));
                    }

                    return;
                }
            }
        }

        private static void Move(int row, int col)
        {
            int nextRow = parisRow + row;
            int nextCol = parisCol + col;

            energy--;

            if (energy <= 0)
            {
                if (IsInside(nextRow, nextCol))
                {
                    if (nextRow == helenRow && nextCol == helenCol)
                    {
                        field[parisRow][parisCol] = '-';
                        field[nextRow][nextCol] = '-';

                        isFoundHer = true;
                    }
                    else
                    {
                        field[parisRow][parisCol] = '-';
                        field[nextRow][nextCol] = 'X';
                        parisRow = nextRow;
                        parisCol = nextCol;

                        isDead = true;
                    }                    
                }
                else
                {
                    field[parisRow][parisCol] = 'X';

                    isDead = true;
                }
            }
            else
            {
                if (IsInside(nextRow, nextCol))
                {
                    if (IsGuard(nextRow, nextCol))
                    {
                        energy -= 2;

                        if (energy <= 0)
                        {
                            field[parisRow][parisCol] = '-';
                            field[nextRow][nextCol] = 'X';
                            parisRow = nextRow;
                            parisCol = nextCol;

                            isDead = true;
                        }
                        else
                        {
                            field[parisRow][parisCol] = '-';
                            field[nextRow][nextCol] = 'P';
                            parisRow = nextRow;
                            parisCol = nextCol;

                        }
                    }
                    else if (nextRow == helenRow && nextCol == helenCol)
                    {
                        field[parisRow][parisCol] = '-';
                        field[nextRow][nextCol] = '-';
                        parisRow = nextRow;
                        parisCol = nextCol;

                        isFoundHer = true;
                    }
                    else
                    {
                        field[parisRow][parisCol] = '-';
                        field[nextRow][nextCol] = 'P';
                        parisRow = nextRow;
                        parisCol = nextCol;
                    }

                }
            }
        }

        private static bool IsGuard(int row, int col)
        {
            return field[row][col] == 'S';
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < field.Length &&
                   col >= 0 && col < field[row].Length;
        }
    }
}
