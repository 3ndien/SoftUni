using _07_InfernoInfinity.Models;
using _07_InfernoInfinity.Models.Contracts;

namespace _07_InfernoInfinity.Core.Data.Contracts
{
    public interface IWeaponRepository
    {
        void AddWeapon(IWeapon weapon);

        IWeapon GetWeapon(string name);

        string PrintWeapon(string weaponName);
    }
}
