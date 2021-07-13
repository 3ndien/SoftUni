using System;
using System.Collections.Generic;
using System.Linq;

namespace _11_KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            sbyte bulletPrice = sbyte.Parse(Console.ReadLine());
            short gunBarrelSize = short.Parse(Console.ReadLine());
            sbyte[] bulletsInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(sbyte.Parse)
                .ToArray();
            sbyte[] locksInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(sbyte.Parse)
                .ToArray();
            int intelValue = int.Parse(Console.ReadLine());

            Stack<sbyte> bullets = new Stack<sbyte>(bulletsInput);
            Queue<sbyte> locks = new Queue<sbyte>(locksInput);
            int barrelCounter = 0;

            while (true)
            {
                if (bullets.Count != 0 && barrelCounter == gunBarrelSize)
                {
                    barrelCounter = 0;
                    Console.WriteLine("Reloading!");
                }

                if (locks.Count == 0 || bullets.Count == 0)
                {
                    break;
                }

                if (bullets.Peek() <= locks.Peek())
                {
                    intelValue -= bulletPrice;
                    bullets.Pop();
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                    barrelCounter++;
                }
                else 
                {
                    intelValue -= bulletPrice;
                    bullets.Pop();  
                    Console.WriteLine("Ping!");
                    barrelCounter++;
                }
            }

            if (bullets.Count == 0 && locks.Count != 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else 
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelValue}");
            }
        }
    }
}
