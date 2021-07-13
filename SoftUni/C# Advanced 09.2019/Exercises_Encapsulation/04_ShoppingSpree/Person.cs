using System;
using System.Collections.Generic;

namespace _04_ShoppingSpree
{
    public class Person
    {
        private string name;

        private decimal money;

        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public decimal Money
        {
            get { return this.money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> BagOfProducts
        {
            get { return this.bagOfProducts.AsReadOnly(); }
        }

        public void BuyProduct(Product product)
        {
            if (product.Cost > this.Money)
            {
                throw new ArgumentException($"{this.Name} can't afford {product.Name}");
            }
            this.bagOfProducts.Add(product);
            this.Money -= product.Cost;
            Console.WriteLine($"{this.Name} bought {product.Name}");
        }

        public override string ToString()
        {
            return this.bagOfProducts.Count != 0 ? $"{this.Name} - {string.Join(", ", this.BagOfProducts)}" 
                                                 : $"{this.Name} - Nothing bought";
        }
    }
}
