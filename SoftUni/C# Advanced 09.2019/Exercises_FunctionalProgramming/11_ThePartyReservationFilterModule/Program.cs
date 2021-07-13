using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11_ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            var filters = new Dictionary<string, Func<string, string, bool>>();
            while (true)
            {
                var input = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                var sb = new StringBuilder();

                if (input[0] == "Print")
                {
                    break;
                }

                string command = input[0];
                string criteria = input[1];
                string param = input[2];

                string filterType = criteria + param;

                if (command == "Add filter")
                {
                    Func<string, string, bool> filter = GetFunc(criteria, param);
                    filters[filterType] = filter;
                }
                else if (command == "Remove filter")
                {
                    if (filters.ContainsKey(filterType))
                    {
                        filters.Remove(filterType);
                    }
                }
            }

            foreach (var f in filters)
            {
                string criteria = new string(f.Key[f.Key.Length - 1], 1);
                var filter = f.Value;
                names.RemoveAll(x => filter(x, criteria));
            }

            Console.WriteLine(string.Join(" ", names));
        }

        private static Func<string, string, bool> GetFunc(string criteria, string param)
        {
            switch (criteria)
            {
                case "Starts with":
                    return (x, c) => x.StartsWith(c);
                case "Ends with":
                    return (x, c) => x.EndsWith(c);
                case "Length":
                    return (x, c) => x.Length == int.Parse(c);
                case "Contains":
                    return (x, c) => x.Contains(c);
                default:
                    return (x, c) => true;
            }
        }
    }
}
