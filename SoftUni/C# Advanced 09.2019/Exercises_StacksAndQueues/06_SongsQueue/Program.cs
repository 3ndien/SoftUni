using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var songs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            var queue = new Queue<string>(songs);

            while (true)
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine("No more songs!");
                    break;
                }

                var inputCmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = inputCmd[0];
                string song = string.Join(" ", inputCmd.Skip(1));

                switch (command)
                {
                    case "Play": queue.Dequeue(); break;
                    case "Add":
                        if (inputCmd.Length < 2) break;
                        if (!queue.Contains(song)) queue.Enqueue(song);
                        else Console.WriteLine($"{song} is already contained!");
                        break;
                    case "Show": Console.WriteLine(string.Join(", ", queue)); break;
                }
            }

        }
    }
}
