using _07_InfernoInfinity.Models.Contracts;

namespace _07_InfernoInfinity.Core.Factories.Contracts
{
    public interface IWeaponFactory
    {
        IWeapon Create(string weaponRarity, string weaponType, string weaponName);
    }
}
