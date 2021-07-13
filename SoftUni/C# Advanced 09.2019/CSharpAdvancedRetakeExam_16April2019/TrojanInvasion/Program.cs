using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static int plate;
        static int warr;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var plates = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> wave = null;

            int everyThird = 0;
            bool isInCity = false;

            for (int i = 0; i < n; i++)
            {
                if (isInCity)
                {
                    break;
                }

                var warrs = Console.ReadLine().Split().Select(int.Parse);
                wave = new Stack<int>(warrs);
                everyThird++;

                if (everyThird == 3)
                {
                    int additionalyPlate = int.Parse(Console.ReadLine());
                    plates.Enqueue(additionalyPlate);
                    everyThird = 0;
                }
                bool isDead = false;

                if (warr <= 0)
                {
                    isDead = true;
                }

                bool isDestroyed = false;

                if (plate <= 0)
                {
                    isDestroyed = true;
                }

                while (true)
                {
                    if (isDead)
                    {
                        if (wave.Count <= 0)
                        {
                            break;
                        }
                        warr = wave.Pop();
                        isDead = false;
                    }

                    if (isDestroyed)
                    {
                        if (plates.Count <= 0)
                        {
                            isInCity = true;
                            break;
                        }
                        plate = plates.Dequeue();
                        isDestroyed = false;
                    }

                    int temp = plate;
                    plate -= warr;
                    warr -= temp;

                    if (plate <= 0)
                    {
                        isDestroyed = true;
                    }
                    if (warr <= 0)
                    {
                        isDead = true;
                    }
                }
            }

            if (isInCity)
            {
                Console.WriteLine($"The Trojans successfully destroyed the Spartan defense.");

                if (wave.Count != 0 || warr > 0)
                {
                    if (wave.Count != 0)
                    {
                        if (warr > 0)
                        {
                            Console.Write($"Warriors left: {warr}" + ", ");
                            Console.WriteLine(string.Join(", ", wave));
                        }
                        else
                        {
                            Console.WriteLine($"Warriors left: {string.Join(", ", wave)}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Warriors left: {warr}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"The Spartans successfully repulsed the Trojan attack.");
                if (plates.Count != 0 || plate > 0)
                {
                    if (plates.Count != 0)
                    {
                        if (plate > 0)
                        {
                            Console.Write($"Plates left: {plate}" + ", ");
                            Console.WriteLine(string.Join(", ", plates));
                        }
                        else
                        {
                            Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Plates left: {plate}");
                    }
                }
            }
        }
    }
}
