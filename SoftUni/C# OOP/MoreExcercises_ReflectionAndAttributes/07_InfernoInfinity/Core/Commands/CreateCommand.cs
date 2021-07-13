using _07_InfernoInfinity.Core.Attributes;
using _07_InfernoInfinity.Core.Contracts;
using _07_InfernoInfinity.Core.Data.Contracts;
using _07_InfernoInfinity.Core.Factories.Contracts;
using _07_InfernoInfinity.Models.Contracts;

namespace _07_InfernoInfinity.Core.Commands
{
    public class CreateCommand : Command
    {
        [Inject]
        private IWeaponFactory weaponFactory;

        [Inject]
        private IWeaponRepository weaponRepository;

        public CreateCommand(string[] data, IWeaponFactory weaponFactory, IWeaponRepository weaponRepository) 
            : base(data)
        {
            this.weaponFactory = weaponFactory;
            this.weaponRepository = weaponRepository;
        }

        public override void Execute()
        {
            string[] weaponData = this.Data[0].Split();
            string weaponRarity = weaponData[0];
            string weaponType = weaponData[1];
            string weaponName = Data[1];

            IWeapon weapon = this.weaponFactory.Create(weaponRarity, weaponType, weaponName);
            this.weaponRepository.AddWeapon(weapon);

        }
    }
}
