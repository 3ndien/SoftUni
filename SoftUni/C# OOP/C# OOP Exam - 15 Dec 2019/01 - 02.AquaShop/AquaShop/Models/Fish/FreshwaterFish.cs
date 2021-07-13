using AquaShop.Models.Fish.Contracts;

namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish, IFish
    {
        private const int InitialSize = 3;

        public FreshwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
        }

        public override int Size { get => InitialSize; protected set => base.Size = InitialSize; }

        public override void Eat()
        {
            this.Size += 3;
        }
    }
}
