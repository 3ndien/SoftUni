using System;
using System.Linq;

namespace _04_Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(',', ' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var lake = new Lake(input);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
