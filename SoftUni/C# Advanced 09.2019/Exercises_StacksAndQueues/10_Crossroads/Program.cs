using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            byte durationGreenLight = byte.Parse(Console.ReadLine());
            byte freeWindowDuration = byte.Parse(Console.ReadLine());
            var cars = new Queue<string>();
            int totalCarsPassed = 0;

            string input = string.Empty;
            while (true)
            {
                input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                if (input != "green")
                {
                    cars.Enqueue(input);
                    continue;
                }

                int currentGreenLight = durationGreenLight;
                string passingCar = null;

                while (currentGreenLight > 0 && cars.Any())
                {
                    passingCar = cars.Dequeue();
                    currentGreenLight -= passingCar.Length;
                    totalCarsPassed++;
                }

                int freeWindowLeft = currentGreenLight + freeWindowDuration;

                if (freeWindowLeft < 0)
                {
                    int symbolsThatDidntPassed = Math.Abs(freeWindowLeft);
                    int indexOfHitSymbol = passingCar.Length - symbolsThatDidntPassed;
                    char symbolHit = passingCar[indexOfHitSymbol];
                    Crash(passingCar, symbolHit);
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
        }

        private static void Crash(string car, char symbolHit)
        {
            Console.WriteLine("A crash happened!");
            Console.WriteLine($"{car} was hit at {symbolHit}.");
            Environment.Exit(0);
        }
    }
}
