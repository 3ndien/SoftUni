
using _07_InfernoInfinity.Core.Data.Contracts;
using _07_InfernoInfinity.Models;
using _07_InfernoInfinity.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_InfernoInfinity.Core.Data
{
    public class WeaponRepository : IWeaponRepository
    {
        IDictionary<string, IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new Dictionary<string, IWeapon>();
        }

        public void AddWeapon(IWeapon weapon)
        {
            if (!weapons.ContainsKey(weapon.Name))
            {
                weapons.Add(weapon.Name.ToLower(), weapon);
            }
        }

        public IWeapon GetWeapon(string name)
        {
            name = name.ToLower();
            if (!this.weapons.ContainsKey(name))
            {
                throw new ArgumentException("Weapon repository does not contain this weapon!");
            }
            return weapons[name];
        }

        public string PrintWeapon(string weaponName)
        {
            IWeapon weapon = this.weapons.FirstOrDefault(kvp => kvp.Key.ToLower() == weaponName.ToLower()).Value;
            return weapon.ToString();
        }
    }
}
