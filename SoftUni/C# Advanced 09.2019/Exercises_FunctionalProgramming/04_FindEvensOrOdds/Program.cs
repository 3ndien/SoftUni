using System;
using System.Linq;

namespace _04_FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] boundaries = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string typeEvenOrOdd = Console.ReadLine();

            var collection = Enumerable.Range(boundaries[0], boundaries[1] - boundaries[0] + 1);
            Func<int, bool> predicate = x => true;

            if (typeEvenOrOdd == "odd")
            {
                predicate = x => x % 2 != 0;
            }
            else if (typeEvenOrOdd == "even")
            {
                predicate = x => x % 2 == 0;
            }

            var filteredCollection = collection.Where(predicate);

            Console.WriteLine(string.Join(" ", filteredCollection));
        }
    }
}
