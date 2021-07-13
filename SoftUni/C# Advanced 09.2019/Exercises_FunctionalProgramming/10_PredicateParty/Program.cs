using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, string, bool> filter = (x, c) => true;

            var guests = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> guestsToAdd = new List<string>();

            while (true)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "Party!")
                {
                    break;
                }

                string command = input[0];
                string criteria = input[1];
                string param = input[2];

                if (command == "Double")
                {
                    filter = GetFunc(criteria, param);
                    guestsToAdd = guests.Where(x => filter(x, param)).ToList();

                    foreach (var guest in guestsToAdd)
                    {
                        int index = guests.ToList().IndexOf(guest);
                        guests.Insert(index, guest);
                    }
                }
                else if (command == "Remove")
                {
                    filter = GetFunc(criteria, param);
                    guests.RemoveAll(x => filter(x, param));
                }
            }
                
            Console.WriteLine(guests.Any() ? $"{string.Join(", ", guests)} are going to the party!" : "Nobody is going to the party!");
        }

        private static Func<string, string, bool> GetFunc(string criteria, string param)
        {
            switch (criteria)
            {
                case "StartsWith":
                    return (x, c) => x.StartsWith(c);
                case "EndsWith":
                    return (x, c) => x.EndsWith(c);
                case "Length":
                    return (x, c) => x.Length == int.Parse(c);
                default:
                    return (x, c) => true;
            }
        }
    }
}
