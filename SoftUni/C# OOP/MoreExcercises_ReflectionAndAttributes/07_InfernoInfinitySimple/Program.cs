
using _07_InfernoInfinitySimple.Model;
using _07_InfernoInfinitySimple.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_InfernoInfinitySimple
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new Dictionary<string, IWeapon>();
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs= input.Split(';');
                string command = inputArgs[0];

                string[] data = inputArgs.Skip(1).ToArray();
                string weaponName;
                int index;
                IWeapon weapon;

                switch (command)
                {
                    case "Create":
                        weapon = CreateWeapon(data);
                        if (!repository.ContainsKey(weapon.Name))
                        {
                            repository.Add(weapon.Name, weapon);
                        }
                        break;
                    case "Add":
                        weaponName = data[0];
                        if (repository.ContainsKey(weaponName))
                        {
                            index = int.Parse(data[1]);
                            IGem gem = CreateGem(data);

                            repository[weaponName].AddGem(index, gem);
                        }
                        break;
                    case "Remove":
                        weaponName = data[0];
                        index = int.Parse(data[1]);
                        if (repository.ContainsKey(weaponName))
                        {
                            repository[weaponName].RemoveGem(index);
                        }
                        break;
                    case "Print":
                        weaponName = data[0];
                        if (repository.ContainsKey(weaponName))
                        {
                            weapon = repository[weaponName];
                            Console.WriteLine(weapon);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private static IGem CreateGem(string[] data)
        {
            string[] gemArgs = data[2].Split();
            Clarity gemClarity = (Clarity)Enum.Parse(typeof(Clarity), gemArgs[0], true);
            string gemType = gemArgs[1];

            switch (gemType)
            {
                case "Ruby": return new Ruby(gemClarity);
                case "Emerald": return new Emerald(gemClarity);
                case "Amethyst": return new Amethyst(gemClarity);
                default: throw new ArgumentException("Gem type is not suported");
            }
        }

        private static IWeapon CreateWeapon(string[] data)
        {
            string[] weaponArgs = data[0].Split();
            Rarity weaponRarity = (Rarity)Enum.Parse(typeof(Rarity), weaponArgs[0], true);
            string weaponType = weaponArgs[1];
            string weaponName = data[1];

            switch (weaponType)
            {
                case "Axe": return new Axe(weaponRarity, weaponName);
                case "Sword": return new Sword(weaponRarity, weaponName);
                case "Knife": return new Knife(weaponRarity, weaponName);
                default: throw new ArgumentException("Weapon type is not suported");
            }
        }
    }
}
