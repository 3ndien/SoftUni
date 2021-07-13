
using _07_InfernoInfinitySimple.Models;

namespace _07_InfernoInfinitySimple.Model
{
    public class Knife : Weapon
    {
        public Knife(Rarity rarity, string name)
        : base(rarity, name, 3, 4, 2)
        {
        }
    }
}
