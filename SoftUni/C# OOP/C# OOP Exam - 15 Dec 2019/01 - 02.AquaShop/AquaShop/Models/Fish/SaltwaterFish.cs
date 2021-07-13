using AquaShop.Models.Fish.Contracts;

namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish, IFish
    {
        private const int InitialSize = 5;

        public SaltwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
        }

        public override int Size { get => InitialSize; protected set => base.Size = InitialSize; }

        public override void Eat()
        {
            this.Size += 2;
        }
    }
}
