using System;
using System.Collections.Generic;

namespace _05_CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine().ToCharArray();

            var dict = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!dict.ContainsKey(text[i]))
                {
                    dict.Add(text[i], 0);
                }
                dict[text[i]]++;
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
