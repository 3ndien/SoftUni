using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var dict = new Dictionary<int, int>();


            for (int i = 0; i < count; i++)
            {
                int key = int.Parse(Console.ReadLine());

                if (!dict.ContainsKey(key))
                {
                    dict.Add(key, 0);
                }
                dict[key]++;
            }

            KeyValuePair<int, int> number = dict.First(kvp => kvp.Value % 2 == 0);

            Console.WriteLine(number.Key);
        }
    }
}
