using _04_TrafficLights;
using System;
using System.Linq;

namespace _P04_TrafficLights
{
    class Program
    {
        static void Main(string[] args)
        {
            TrafficLights[] lights = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(s => (TrafficLights)Enum.Parse(typeof(TrafficLights), s))
                .ToArray();

            int rows = int.Parse(Console.ReadLine());

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < lights.Length; col++)
                {
                    var state = (int)lights[col];
                    lights[col] = (TrafficLights)(++state % lights.Length);
                }
                Console.WriteLine(string.Join(" ", lights));
            }

        }
    }
}
