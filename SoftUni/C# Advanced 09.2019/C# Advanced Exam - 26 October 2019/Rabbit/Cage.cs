using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> data;

        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Rabbit>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Rabbit rabbit)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name)
        {
            var rabbit = this.data.FirstOrDefault(r => r.Name == name);

            return this.data.Remove(rabbit);
        }

        public void RemoveSpecies(string species)
        {
            this.data.RemoveAll(r => r.Species == species);
        }

        public Rabbit SellRabbit(string name)
        {
            var rabbit = this.data.FirstOrDefault(r => r.Name == name);

            if (rabbit != null)
            {
                rabbit.Available = false;
            }

            return rabbit;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            var result = new List<Rabbit>();

            foreach (var rabbit in this.data)
            {
                if (rabbit.Species == species)
                {
                    rabbit.Available = false;
                    result.Add(rabbit);
                }
            }

            return result.ToArray();
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Rabbits available at {this.Name}:");
            foreach (var rabbit in this.data.Where(r => r.Available != false))
            {
                sb.AppendLine(rabbit.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
