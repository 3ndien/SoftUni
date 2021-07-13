using System;
using System.Collections.Generic;
using System.Linq;

namespace SummerCocktails
{
    class Program
    {
        static void Main(string[] args)
        {
            var ingredientsInput = Console.ReadLine().Split().Select(int.Parse);
            var freshnessInput = Console.ReadLine().Split().Select(int.Parse);

            var ingredients = new Queue<int>(ingredientsInput);
            var freshness = new Stack<int>(freshnessInput);

            var cocktailsValues = new int[] { 150, 250, 300, 400 };
            var cocktails = new Dictionary<string, int>();
            cocktails.Add("Mimosa", 0);
            cocktails.Add("Daiquiri", 0);
            cocktails.Add("Sunshine", 0);
            cocktails.Add("Mojito", 0);

            while (true)
            {
                if (ingredients.Count <= 0)
                {
                    break;
                }

                if (freshness.Count <= 0)
                {
                    break;
                }

                if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }

                int mix = ingredients.Peek() * freshness.Peek();
                
                if (cocktailsValues.Any(c => c == mix))
                {
                    switch (mix)
                    {
                        case 150: cocktails["Mimosa"]++; break;
                        case 250: cocktails["Daiquiri"]++; break;
                        case 300: cocktails["Sunshine"]++; break;
                        case 400: cocktails["Mojito"]++; break;
                    }
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else
                {
                    freshness.Pop();
                    ingredients.Enqueue(ingredients.Dequeue() + 5);
                }

            }

            if (cocktails.Any(c => c.Value == 0))
            {
                Console.WriteLine($"What a pity! You didn't manage to prepare all cocktails.");

                if (ingredients.Count != 0)
                {
                    Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
                }
                foreach (var cocktail in cocktails.OrderBy(n => n.Key))
                {
                    if (cocktail.Value == 0)
                    {
                        continue;
                    }
                    Console.WriteLine($"# {cocktail.Key} --> {cocktail.Value}");
                }
            }
            else
            {
                Console.WriteLine($"It's party time! The cocktails are ready!");

                foreach (var cocktail in cocktails.OrderBy(n => n.Key))
                {
                    Console.WriteLine($"# {cocktail.Key} --> {cocktail.Value}");
                }
            }
        }
    }
}
