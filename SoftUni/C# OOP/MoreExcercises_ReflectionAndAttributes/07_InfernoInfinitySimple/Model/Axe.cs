
using _07_InfernoInfinitySimple.Models;

namespace _07_InfernoInfinitySimple.Model
{
    public class Axe : Weapon
    {
        public Axe(Rarity rarity, string name)
        : base(rarity, name, 5, 10, 4)
        {
        }
    }
}
