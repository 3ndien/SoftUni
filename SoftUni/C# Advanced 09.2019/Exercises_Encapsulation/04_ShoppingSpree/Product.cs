
using System;

namespace _04_ShoppingSpree
{
    public class Product
    {
        private string name;

        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can not be empty!");
                }
                this.name = value;
            }
        }

        public decimal Cost
        {
            get { return this.cost; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.cost = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
