using System;
using System.Linq;

namespace _07_PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int namesLenght = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] filteredNames = names.Where(n => n.Length <= namesLenght).ToArray();

            foreach (var name in filteredNames)
            {
                Console.WriteLine(name);
            }
        }

    }
}
