using System;
using System.Linq;

namespace _12_TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> filter = (x, s) => x.Sum(c => c) >= s;

            string result = names.FirstOrDefault(x => filter(x, length));

            if (result != null)
            {
                Console.WriteLine(result);
            }

        }

    }
}
