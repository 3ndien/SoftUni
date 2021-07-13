using System.Collections.Generic;
using _03BarracksFactory.Contracts;
using P03_BarraksWars.Core.Attributes;

namespace P03_BarraksWars.Core.Commands
{
    public class ReportCommand : Command
    {
        [Inject]
        private IRepository repository;

        public ReportCommand(string[] data, IRepository repository) 
            : base(data)
        {
            this.Repository = repository;
        }

        public IRepository Repository { get => this.repository; private set { this.repository = value; } }


        public override string Execute()
        {
            return this.Repository.Statistics;
        }
    }
}
