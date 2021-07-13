using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandEnding = "Command";

        public string Read(string args)
        {
            string commandName = args.Split().First();

            Type commandType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == commandName + CommandEnding);

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command type!");

            }

            ICommand command = Activator.CreateInstance(commandType) as ICommand;

            if (command == null)
            {
                throw new ArgumentException("Invalid command type!");

            }

            return command.Execute(args.Split().Skip(1).ToArray());
        }
    }
}
