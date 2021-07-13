
using _07_InfernoInfinitySimple.Models;

namespace _07_InfernoInfinitySimple.Model
{
    public class Sword : Weapon
    {
        public Sword(Rarity rarity, string name)
        : base(rarity, name, 4, 6, 3)
        {
        }
    }
}
