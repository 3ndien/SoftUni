using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            var orders = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var queue = new Queue<int>(orders);

            int biggestOrder = queue.Max();
            Console.WriteLine(biggestOrder);

            while (true)
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine("Orders complete");
                    break;
                }

                if (queue.Peek() > foodQuantity)
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
                    break;
                }

                foodQuantity -= queue.Peek();
                queue.Dequeue();
            }
        }
    }
}
