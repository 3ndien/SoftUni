using System;

namespace PizzaCalories
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] firstRow = Console.ReadLine().Split();
            string[] secondRow = Console.ReadLine().Split();

            try
            {
                var dough = new Dough(secondRow[1], secondRow[2], double.Parse(secondRow[3]));
                var pizza = new Pizza(firstRow[1], dough);

                string toppingInput;
                while ((toppingInput = Console.ReadLine()) != "END")
                {
                    var toppingData = toppingInput.Split();
                    var topping = new Topping(toppingData[1], double.Parse(toppingData[2]));

                    pizza.AddTopping(topping);
                }

                var pizzaName = pizza.Name;
                var totalCalories = pizza.GetTotalCalories();

                Console.WriteLine($"{pizzaName} - {totalCalories:f2} Calories.");
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
