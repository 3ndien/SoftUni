
using System.Collections.Generic;
using _03BarracksFactory.Contracts;
using P03_BarraksWars.Core.Attributes;

namespace P03_BarraksWars.Core.Commands
{
    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data, IRepository repository) 
            : base(data)
        {
            this.Repository = repository;
        }

        public IRepository Repository { get => this.repository; private set { this.repository = value; } }

        public override string Execute()
        {
            string unitType = base.Data[1];

            this.Repository.RemoveUnit(unitType);

            return $"{unitType} retired!";
        }
    }
}
