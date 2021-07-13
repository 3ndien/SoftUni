using System;
using System.Collections.Generic;

namespace _01_UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var set = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                set.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join(Environment.NewLine, set));
        }
    }
}
