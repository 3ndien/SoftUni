
using _07_InfernoInfinity.Core.Attributes;
using _07_InfernoInfinity.Core.Data.Contracts;
using System;

namespace _07_InfernoInfinity.Core.Commands
{
    public class PrintCommand : Command
    {
        [Inject]
        private IWeaponRepository weaponRepository;

        public PrintCommand(string[] data, IWeaponRepository weaponRepository) 
            : base(data)
        {
            this.weaponRepository = weaponRepository;
        }

        public override void Execute()
        {
            string weaponName = this.Data[0];
            Console.WriteLine(this.weaponRepository.PrintWeapon(weaponName));
        }
    }
}
