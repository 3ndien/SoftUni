using _07_InfernoInfinity.Core.Contracts;
using _07_InfernoInfinity.Core.Factories.Contracts;
using _07_InfernoInfinity.Models;
using _07_InfernoInfinity.Models.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace _07_InfernoInfinity.Core.Factories
{
    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon Create(string weaponRarity, string weaponType, string weaponName)
        {
            Rarity rarity = (Rarity)Enum.Parse(typeof(Rarity), weaponRarity, true);

            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == weaponType.ToLower());

            if (type == null)
            {
                throw new ArgumentException($"Invalid weapon type!");
            }

            var weapon = (IWeapon)Activator.CreateInstance(type, new object[] { weaponName, rarity });

            return weapon;
        }
    }
}
