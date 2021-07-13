using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var pumps = new Queue<int[]>();
            
            long truckTank = 0;
            int count = 0;

            for (int i = 0; i < lines; i++)
            {
                var data = new int[3];
                var input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                data[0] = input[0];
                data[1] = input[1];
                data[2] = i;

                pumps.Enqueue(data);
            }

            while (true)
            {
                if (count == pumps.Count)
                {
                    Console.WriteLine(pumps.Peek()[2]);
                    break;
                }

                truckTank += pumps.Peek()[0];

                if (truckTank < pumps.Peek()[1])
                {
                    count = 0;
                    truckTank = 0;
                    pumps.Enqueue(pumps.Dequeue());
                    continue;
                }

                truckTank -= pumps.Peek()[1];
                pumps.Enqueue(pumps.Dequeue());
                count++;

            }
        }
    }
}
