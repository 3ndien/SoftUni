using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var result = new List<int>();
            List<Predicate<int>> predicates = new List<Predicate<int>>();

            for (int d = 0; d < dividers.Length; d++)
            {
                var divider = dividers[d];
                predicates.Add(x => x % divider == 0); 
            }

            for (int i = 1; i <= n; i++)
            {
                bool isDivisible = true;
                var element = i;
                for (int p = 0; p < predicates.Count; p++)
                {
                    if (!predicates[p](element))
                    {
                        isDivisible = false;
                        break;
                    }
                }
                if (isDivisible)
                {
                    result.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
