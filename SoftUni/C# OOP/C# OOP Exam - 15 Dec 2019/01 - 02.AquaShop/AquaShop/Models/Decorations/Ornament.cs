namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int InitializeComfort = 1;
        private const int InitializePrice = 5;

        public Ornament() : base(InitializeComfort, InitializePrice)
        {
        }
    }
}
