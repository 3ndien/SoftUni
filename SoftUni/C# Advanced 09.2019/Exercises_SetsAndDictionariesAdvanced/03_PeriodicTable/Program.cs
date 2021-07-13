using System;
using System.Collections.Generic;

namespace _03_PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var set = new SortedSet<string>();

            for (int i = 0; i < count; i++)
            {
                string[] elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < elements.Length; j++)
                {
                    set.Add(elements[j]);
                }
            }

            Console.WriteLine(string.Join(" ", set));
        }
    }
}
