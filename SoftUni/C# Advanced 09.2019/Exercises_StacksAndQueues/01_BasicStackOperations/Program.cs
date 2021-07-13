using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();

            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var elements = Console.ReadLine().Split();

            int elementToPush = input[0];
            int amountToPop = input[1];
            int elementToCheck = input[2];

            for (int i = 0; i < elementToPush; i++)
            {
                int element = int.Parse(elements[i]);

                stack.Push(element);
            }

            for (int i = 0; i < amountToPop; i++)
            {
                if (stack.Count == 0)
                {
                    break;
                }

                stack.Pop();
            }

            if (stack.Contains(elementToCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(stack.Peek());
                }
            }
        }
    }
}
