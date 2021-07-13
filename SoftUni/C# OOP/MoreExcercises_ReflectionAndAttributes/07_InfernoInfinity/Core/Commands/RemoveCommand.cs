
using _07_InfernoInfinity.Core.Attributes;
using _07_InfernoInfinity.Core.Data.Contracts;

namespace _07_InfernoInfinity.Core.Commands
{
    public class RemoveCommand : Command
    {
        [Inject]
        private IWeaponRepository weaponRepository;

        public RemoveCommand(string[] data, IWeaponRepository weaponRepository)
            : base(data)
        {
            this.weaponRepository = weaponRepository;
        }

        public override void Execute()
        {
            var weaponName = this.Data[0];
            var index = int.Parse(this.Data[1]);
            var weapon = this.weaponRepository.GetWeapon(weaponName);

            weapon.RemoveSocked(index);
        }
    }
}
