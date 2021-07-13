using System;
using System.Linq;

namespace _08_CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, bool> evenFilter = x => x % 2 == 0;
            Func<int, bool> oddFilter = x => x % 2 != 0;

            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var evens = nums.Where(evenFilter).ToArray();
            var odds = nums.Where(oddFilter).ToArray();
            Array.Sort(evens);
            Array.Sort(odds);

            int[] result = evens.Concat(odds).ToArray();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
