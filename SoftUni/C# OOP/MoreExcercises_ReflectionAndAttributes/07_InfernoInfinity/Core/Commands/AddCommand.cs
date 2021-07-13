
using _07_InfernoInfinity.Core.Attributes;
using _07_InfernoInfinity.Core.Contracts;
using _07_InfernoInfinity.Core.Data.Contracts;
using _07_InfernoInfinity.Core.Factories.Contracts;
using _07_InfernoInfinity.Models.Contracts;

namespace _07_InfernoInfinity.Core.Commands
{
    public class AddCommand : Command
    {
        [Inject]
        private IGemFactory gemFactory;
        [Inject]
        private IWeaponRepository weaponRepository;

        public AddCommand(string[] data, IGemFactory gemFactory, IWeaponRepository weaponRepository) 
            : base(data)
        {
            this.gemFactory = gemFactory;
            this.weaponRepository = weaponRepository;
        }

        public override void Execute()
        {
            string weaponName = this.Data[0];
            int index = int.Parse(this.Data[1]);

            var gemData = this.Data[2].Split();
            string clarity = gemData[0];
            string gemType = gemData[1];

            IGem gem = this.gemFactory.Create(clarity, gemType);
            IWeapon weapon = this.weaponRepository.GetWeapon(weaponName);
            weapon.AddSocked(gem, index);
        }
    }
}
