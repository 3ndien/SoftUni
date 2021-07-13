using System;
using System.Collections.Generic;

namespace _06_Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < lines; i++)
            {
                var data = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = data[0];
                var clothes = data[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                for (int c = 0; c < clothes.Length; c++)
                {
                    if (!wardrobe[color].ContainsKey(clothes[c]))
                    {
                        wardrobe[color].Add(clothes[c], 0);
                    }
                    wardrobe[color][clothes[c]]++;
                }
            }

            var searchedItem = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var kvp in wardrobe)
            {
                string color = kvp.Key;
                Dictionary<string, int> clothes = kvp.Value;
                Console.WriteLine($"{color} clothes:");

                foreach (var kvp2 in clothes)
                {
                    string cloth = kvp2.Key;
                    int count = kvp2.Value;

                    if (color == searchedItem[0] && cloth == searchedItem[1])
                    {
                        Console.WriteLine($"* {cloth} - {count} (found!)");
                        continue;
                    }

                    Console.WriteLine($"* {cloth} - {count}");
                }
            }
        }
    }
}
