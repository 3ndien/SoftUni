using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int firstSize = sizes[0];
            int secondSize = sizes[1];

            var set = new HashSet<int>();
            var set2 = new HashSet<int>();
            var list = new List<int>();

            for (int i = 0; i < firstSize + secondSize; i++)
            {
                int value = int.Parse(Console.ReadLine());

                if (i < firstSize)
                {
                    set.Add(value);
                }
                else
                {
                    set2.Add(value);
                }
            }

            Console.WriteLine(string.Join(" ", set.Intersect(set2)));
        }
    }
}
