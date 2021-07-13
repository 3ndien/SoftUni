using System;
using System.Linq;

namespace _03_CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> getSmallestInt = x => x.Min();

            Console.WriteLine(getSmallestInt(Console.ReadLine().Split().Select(int.Parse).ToArray()));
        }
    }
}
