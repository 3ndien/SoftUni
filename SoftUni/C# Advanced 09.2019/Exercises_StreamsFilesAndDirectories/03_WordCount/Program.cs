using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03_WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllLines("../../../words.txt");

            string[] text = File.ReadAllText("../../../text.txt")
                .Split(new [] { ",", ".", "!", "?", "-", " ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            
            using (var reader = new StreamReader("../../../text.txt"))
            {
                using (var writer = new StreamWriter("../../../actualResult.txt"))
                {
                    for (int w = 0; w < words.Length; w++)
                    {
                        int counter = 0;

                        foreach (var word in text)
                        {
                            if (words[w].ToLower() == word.ToLower())
                            {
                                counter++;
                            }
                        }
                        writer.WriteLine($"{words[w]} - {counter}");
                    }
                }
            }

            Dictionary<string, int> lines = File.ReadAllLines("../../../actualResult.txt")
                .Select(l => l.Split(" - ", StringSplitOptions.RemoveEmptyEntries)).ToDictionary(k => k[0], v => int.Parse(v[1]))
                .OrderByDescending(v => v.Value).ToDictionary(k => k.Key, v => v.Value);

            string[] result = lines.Select(l => l.Key + " - " + l.Value).ToArray();

            File.WriteAllLines("../../../expectedResult.txt", result);
        }
    }
}
