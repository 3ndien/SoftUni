namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int InitializeComfort = 5;
        private const int InitializePrice = 10;

        public Plant() : base(InitializeComfort, InitializePrice)
        {
        }
    }
}
