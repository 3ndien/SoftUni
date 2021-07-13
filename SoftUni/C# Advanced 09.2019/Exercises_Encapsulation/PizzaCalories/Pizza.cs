using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;

        private List<Topping> toppings;

        private Dough dough;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                try
                {
                    if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length > 15)
                    {
                        throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                    }
                    this.name = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
        }

        public IReadOnlyCollection<Topping> Toppings
        {
            get { return this.toppings.AsReadOnly(); }
        }

        public void AddTopping(Topping topping)
        {
            try
            {
                if (toppings.Count() >= 10)
                {
                    throw new InvalidOperationException("Number of toppings should be in range [0..10].");
                }
                this.toppings.Add(topping);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public double GetTotalCalories()
        {
            var doughCal = this.dough.Calories;
            var toppingsCal = this.toppings.Select(t => t.Calories).Sum();
            var totalCalories = doughCal + toppingsCal;

            return totalCalories;
        }
    }
}
