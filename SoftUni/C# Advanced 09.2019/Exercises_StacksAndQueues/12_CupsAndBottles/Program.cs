using System;
using System.Collections.Generic;
using System.Linq;

namespace _12_CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCaps = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] filledBottles = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> bottles = new Stack<int>(filledBottles);
            Queue<int> cups = new Queue<int>(cupsCaps);

            bool isFiled = true;
            bool isEmpty = true;

            int wastedWater = 0;
            int cup = 0;
            int tempCup = 0;
            int bottle = 0;

            while (true)
            {
                if (bottles.Count == 0)
                {
                    break;
                }
                if (cups.Count == 0)
                {
                    break;
                }

                if (isEmpty)
                {
                    bottle = bottles.Peek();
                    isEmpty = false;
                }

                if (isFiled)
                {
                    cup = cups.Peek();
                    tempCup = cup;
                    isFiled = false;
                }

                while (true)
                {
                    if (cup <= 0)
                    {
                        break;
                    }

                    if (bottle <= 0)
                    {
                        break;
                    }
                    cup -= bottle;
                    bottle -= tempCup;
                    tempCup = cup;

                }

                if (cup <= 0)
                {
                    wastedWater += Math.Abs(cup);
                    cups.Dequeue();
                    bottles.Pop();
                    isFiled = true;
                    isEmpty = true;
                    continue;
                }

                if (bottle <= 0)
                {
                    bottles.Pop();
                    isEmpty = true;
                }
            }

            if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles.Reverse())}");
                Console.WriteLine($"Wasted litters of water: { wastedWater}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
        }
    }
}
