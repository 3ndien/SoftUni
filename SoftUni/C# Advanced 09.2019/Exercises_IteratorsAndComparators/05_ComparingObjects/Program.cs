using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_ComparingObjects
{
    class Program
    {
        static void Main()
        {
            var people = new List<Person>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var args = input.Split();

                string name = args[0];
                int age = int.Parse(args[1]);
                string town = args[2];

                var person = new Person { Name = name, Age = age, Town = town };
                people.Add(person);

            }
            int position = int.Parse(Console.ReadLine());

            Person thePerson = people[position - 1];
            people.RemoveAt(position - 1);

            int equals = people.Where(p => p.CompareTo(thePerson) == 0).Count();
            int notEquals = Math.Abs(people.Count - equals);
            people.Add(thePerson);

            if (equals == 0)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                equals++;
                Console.WriteLine($"{equals} {notEquals} {people.Count}");
            }
        }
    }
}
