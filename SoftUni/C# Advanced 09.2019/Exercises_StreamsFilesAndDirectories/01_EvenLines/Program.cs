using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01_EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<string>();
            char[] replacingSymbols = { '-', ',', '.', '!', '?' };
            using (var reader = new StreamReader("text.txt"))
            {
                using (var writer = new StreamWriter("../../../output.txt"))
                {
                    int counter = 0;
                    while (!reader.EndOfStream)
                    {
                        string[] line = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < line.Length; i++)
                        {
                            for (int j = 0; j < line[i].Length; j++)
                            {
                                if (replacingSymbols.Any(s => s == line[i][j]))
                                {
                                    line[i] = line[i].Replace(line[i][j], '@');
                                }
                            }
                            stack.Push(line[i]);
                        }

                        if (counter % 2 == 0)
                        {
                            writer.WriteLine(string.Join(" ", stack));
                        }
                        counter++;
                        stack.Clear();
                    }
                }
            }
        }
    }
}
