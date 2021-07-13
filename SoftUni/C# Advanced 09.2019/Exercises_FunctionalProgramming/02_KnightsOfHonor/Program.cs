using System;
using System.Linq;

namespace _02_KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> appendSir = x => Console.WriteLine($"Sir {x}");

            Console.ReadLine().Split().ToList().ForEach(appendSir);
        }
    }
}
