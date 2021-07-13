using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquariumAdventure
{
    public class Aquarium
    {
        private List<Fish> fishInPool;

        public Aquarium(string name, int capacity, int size)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Size = size;
            this.fishInPool = new List<Fish>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Size { get; set; }
    
        public void Add(Fish fish)
        {
            if (this.fishInPool.Any(f => f.Name == fish.Name))
            {
                return;
            }

            if (this.Capacity <= fishInPool.Count)
            {
                return;
            }

            this.fishInPool.Add(fish);

        }

        public bool Remove(string name)
        {
            Fish fish = this.fishInPool.FirstOrDefault(f => f.Name == name);

            return this.fishInPool.Remove(fish);
        }
        
        public Fish FindFish(string name)
        {
            return this.fishInPool.FirstOrDefault(f => f.Name == name);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Aquarium: {this.Name} ^ Size: {this.Size}");

            foreach (var fish in this.fishInPool)
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
