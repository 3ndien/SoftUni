
using System;
using System.Linq;

namespace PizzaCalories
{
    public class Dough
    {
        private FlourType flourType;

        private BakingTecknique bakingTecknique;

        private double weight;

        private double calories;

        public Dough(string flourType, string backingTecknique, double weight)
        {
            try
            {
                this.flourType = (FlourType)Enum.Parse(typeof(FlourType), flourType, true);
                this.bakingTecknique = (BakingTecknique)Enum.Parse(typeof(BakingTecknique), backingTecknique, true);
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid type of dough.");
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
                    if (value < 1 || value > 200)
                    {
                        throw new ArgumentException("Dough weight should be in the range [1..200].");
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
            if (this.flourType == FlourType.White)
            {
                this.calories *= 1.5;
                switch (this.bakingTecknique)
                {
                    case BakingTecknique.Crispy:
                        return this.calories *= 0.9; 
                    case BakingTecknique.Chewy:
                        return this.calories *= 1.1;
                    case BakingTecknique.Homemade:
                        return this.calories *= 1.0;
                }
            }
            else
            {
                this.calories *= 1.0;
                switch (this.bakingTecknique)
                {
                    case BakingTecknique.Crispy:
                        return this.calories *= 0.9;
                    case BakingTecknique.Chewy:
                        return this.calories *= 1.1;
                    case BakingTecknique.Homemade:
                        return this.calories *= 1.0;
                }
            }
            throw new InvalidOperationException();
        }
    }
}
