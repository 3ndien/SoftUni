using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;

            switch (aquariumType)
            {
                case "FreshwaterAquarium":
                    aquarium = new FreshwaterAquarium(aquariumName);
                    this.aquariums.Add(aquarium);
                    return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
                case "SaltwaterAquarium":
                    aquarium = new SaltwaterAquarium(aquariumName);
                    this.aquariums.Add(aquarium);
                    return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;

            switch (decorationType)
            {
                case "Ornament":
                    decoration = new Ornament();
                    this.decorations.Add(decoration);
                    return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
                case "Plant":
                    decoration = new Plant();
                    this.decorations.Add(decoration);
                    return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            //Posible exception

            IAquarium aquarium = this.aquariums.First(a => a.Name == aquariumName);
            
            IFish fish = null;
            
            switch (fishType)
            {
                case "FreshwaterFish":
                    fish = new FreshwaterFish(fishName, fishSpecies, price);
                    aquarium.AddFish(fish);

                    return aquarium.GetType().Name == "FreshwaterAquarium" 
                        ? string.Format(OutputMessages.FishAdded, fishType, aquariumName) 
                        : OutputMessages.UnsuitableWater;
                case "SaltwaterFish":
                    fish = new SaltwaterFish(fishName, fishSpecies, price);
                    aquarium.AddFish(fish);

                    return aquarium.GetType().Name == "SaltwaterAquarium"
                        ? string.Format(OutputMessages.FishAdded, fishType, aquariumName)
                        : OutputMessages.UnsuitableWater;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.First(a => a.Name == aquariumName);
            decimal priceOfDecor = aquarium.Decorations.Sum(d => d.Price);
            decimal priceOfFish = aquarium.Fish.Sum(f => f.Price);
            decimal totalPrice = priceOfDecor + priceOfFish;

            return string.Format(OutputMessages.AquariumValue, aquariumName, totalPrice);
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.First(a => a.Name == aquariumName);
            aquarium.Feed();

            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            //Posible exception

            IAquarium aquarium = this.aquariums.First(a => a.Name == aquariumName);

            IDecoration decoration = this.decorations.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            aquarium.AddDecoration(decoration);
            this.decorations.Remove(decoration);

            return string.Format(OutputMessages.DecorationAdded, decorationType, aquariumName);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());   
            }

            return sb.ToString().TrimEnd();
        }
    }
}
