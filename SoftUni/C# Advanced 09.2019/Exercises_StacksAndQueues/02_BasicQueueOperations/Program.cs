using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<int>();

            var input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var elements = Console.ReadLine().Split();

            int elementToPush = input[0];
            int amountToPop = input[1];
            int elementToCheck = input[2];

            for (int i = 0; i < elementToPush; i++)
            {
                int element = int.Parse(elements[i]);

                queue.Enqueue(element);
            }

            for (int i = 0; i < amountToPop; i++)
            {
                if (queue.Count == 0)
                {
                    break;
                }

                queue.Dequeue();
            }

            if (queue.Contains(elementToCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
        }
    }
    }
