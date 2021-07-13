using _03BarracksFactory.Contracts;
using P03_BarraksWars.Core.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace P03_BarraksWars.Core.Commands
{
    public class AddCommand : Command
    {
        [Inject]
        private IRepository repository;

        [Inject]
        private IUnitFactory unitFactory;

        public AddCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data)
        {
            this.Repository = repository;
            this.UnitFactory = unitFactory;
        }

        public IRepository Repository { get => this.repository; private set { this.repository = value; } }

        public IUnitFactory UnitFactory { get => this.unitFactory; private set { this.unitFactory = value; } }

        public override string Execute()
        {
            var unitType = base.Data[1];
            IUnit unitToAdd = this.UnitFactory.CreateUnit(unitType);
            this.Repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}
