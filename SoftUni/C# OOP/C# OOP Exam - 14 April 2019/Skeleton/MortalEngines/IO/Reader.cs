namespace MortalEngines.IO
{
    using Contracts;
    using Core.Contracts;

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Reader : IReader
    {
        private IList<ICommand> commands;

        private IMachinesManager machinesManager;

        public Reader(IMachinesManager machinesManager)
        {
            this.machinesManager = machinesManager;
            this.commands = new List<ICommand>();
        }

        public IList<ICommand> ReadCommands()
        {
            string input;

            while ((input = Console.ReadLine()) != "Quit")
            {
                string[] inputArgs = input.Split();
                string[] data = inputArgs.Skip(1).ToArray();

                ICommand command = new Command(machinesManager, inputArgs[0], data);
                this.commands.Add(command);
            }

            return this.commands;
        }
    }
}
