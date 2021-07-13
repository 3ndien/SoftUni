using System;

namespace PizzaCalories
{
    public class Topping
    {
        private ToppingType toppingType;

        private double weight;

        private double calories;

        public Topping(string toppingType, double weight)
        {
            try
            {
                this.toppingType = (ToppingType)Enum.Parse(typeof(ToppingType), toppingType, true);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Cannot place {toppingType} on top of your pizza.");
                throw;
            }
            this.Weight = weight;
            this.calories = this.weight * 2;
        }

        private double Weight
        {
            set
            {
                try
                {
                    if (value < 1 || value > 50)
                    {
                        throw new ArgumentException($"{this.toppingType} weight should be in the range [1..50].");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
                this.weight = value;
            }
        }

        public double Calories
        {
            get { return this.GetCalories(); }
        }

        private double GetCalories()
        {
            switch (this.toppingType)
            {
                case ToppingType.Meat:
                    return this.calories *= 1.2;
                case ToppingType.Veggies:
                    return this.calories *= 0.8;
                case ToppingType.Cheese:
                    return this.calories *= 1.1;
                case ToppingType.Sauce:
                    return this.calories *= 0.9;
            }

            throw new InvalidOperationException();
        }
    }
}
