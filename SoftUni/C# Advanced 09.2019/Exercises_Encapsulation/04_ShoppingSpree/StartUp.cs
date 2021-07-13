using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_ShoppingSpree
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var people = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            var persons = new List<Person>();

            for (int i = 0; i < people.Length; i++)
            {
                try
                {
                    var peopleData = people[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                    var person = new Person(peopleData[0], decimal.Parse(peopleData[1]));

                    persons.Add(person);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    if (e.Message == "Money cannot be negative" || e.Message == "Name cannot be empty")
                    {
                        return;
                    }
                }
            }

            var products = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            var productsList = new List<Product>();

            for (int i = 0; i < products.Length; i++)
            {
                try
                {
                    var productData = products[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                    var product = new Product(productData[0], decimal.Parse(productData[1]));

                    productsList.Add(product);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    if (e.Message == "Money cannot be negative" || e.Message == "Name cannot be empty")
                    {
                        return;
                    }
                }
            }

            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                var tokens = cmd.Split();
                var person = tokens[0];
                var product = tokens[1];

                var buyer = persons.FirstOrDefault(p => p.Name == person);

                if (buyer == null)
                {
                    Console.WriteLine("There no such input");
                }

                var productToBuy = productsList.FirstOrDefault(p => p.Name == product);
                if (productToBuy == null)
                {
                    Console.WriteLine("There no such product");
                }

                try
                {
                    buyer.BuyProduct(productToBuy);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach (var p in persons)
            {
                Console.WriteLine(p);
            }
        }
    }
}
