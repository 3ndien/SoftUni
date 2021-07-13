using System;
using System.Linq;

namespace _05_AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {

            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int, int> operation = x => x;
            Action<int[]> print = x => Console.WriteLine(string.Join(" ", x));

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                switch (command)
                {
                    case "add": 
                        operation = x => x += 1;
                        numbers = ApplyArithmetucs(numbers, operation);
                        break;
                    case "multiply": 
                        operation = x => x *= 2;
                        numbers = ApplyArithmetucs(numbers, operation);
                        break;
                    case "subtract": 
                        operation = x => x -= 1;
                        numbers = ApplyArithmetucs(numbers, operation);
                        break;
                    case "print": print(numbers); break;
                    default: return;
                }
                
            }
        }

        private static int[] ApplyArithmetucs(int[] numbers, Func<int, int> operation)
        {
            return numbers.Select(operation).ToArray();
        }
    }
}
