using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var clothes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);
            var box = new Stack<int>(clothes);
            int sum = 0;
            int racksCount = 1;
            int rackCapacity = int.Parse(Console.ReadLine());

            while (true)
            {
                if (box.Count == 0)
                {
                    Console.WriteLine(racksCount);
                    break;
                }

                if (sum + box.Peek() > rackCapacity)
                {
                    sum = 0;
                    racksCount++;
                }

                sum += box.Pop();

            }
        }
    }
}
