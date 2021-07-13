using System;
using System.Linq;

namespace _06_ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int divider = int.Parse(Console.ReadLine());

            var result = numbers.Where(x => x % divider != 0).Reverse();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
