using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    class RawData
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = parameters[0];
                
                int engineSpeed = int.Parse(parameters[1]);
                int enginePower = int.Parse(parameters[2]);
                var engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(parameters[3]);
                string cargoType = parameters[4];
                var cargo = new Cargo(cargoWeight, cargoType);

                var tiresData = parameters.Skip(5).ToArray();
                var tires = new List<Tire>();

                for (int t = 0; t < tiresData.Length; t += 2)
                {
                    tires.Add(new Tire(double.Parse(tiresData[t]), int.Parse(tiresData[t + 1])));
                }

                cars.Add(new Car(model, engine, cargo, tires));
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }
    }
}
